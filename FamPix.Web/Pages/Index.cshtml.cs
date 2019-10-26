using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bogus;
using FamPix.Data.Repositories;
using FamPix.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace FamPix.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly PhotoRepository _repo;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(PhotoRepository repo, ILogger<IndexModel> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public ICollection<Photo> Photos { get; set; }

        public async Task OnGetAsync()
        {
            Photos = await _repo.GetAll().ToListAsync();
        }

        public async Task<IActionResult> OnPostUpdateAsync(int id)
        {
            var photo = await _repo.GetAsync(id);
            await _repo.UpdateAsync(photo);
            return RedirectToPage(nameof(Index));
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _repo.RemoveAsync(id);
            return RedirectToPage(nameof(Index));
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var photo = new Faker<Photo>()
                .RuleFor(p => p.Name, e => e.Name.FullName())
                .RuleFor(p => p.Url, e => e.Image.LoremFlickrUrl())
                .Generate();

            await _repo.AddAsync(photo);

            return RedirectToPage(nameof(Index));
        }
    }
}
