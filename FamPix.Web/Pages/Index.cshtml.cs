using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bogus;
using FamPix.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using FamPix.Data.Abstracts;
using System.Linq;

namespace FamPix.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IRepository<Photo> _photos;
        private readonly IRepository<Album> _albums;
        private readonly IFamPixDbContext _context;

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(IRepository<Photo> photos, IRepository<Album> albums, IFamPixDbContext context, ILogger<IndexModel> logger)
        {
            _photos = photos;
            _albums = albums;
            _context = context;
            _logger = logger;
        }

        public ICollection<Photo> Photos { get; set; }
        public ICollection<Album> Albums { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Photos = await _photos.GetAll().Take(21).ToListAsync();
            Albums = await _albums.GetAll().ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnGetLoadImagesAsync(int skip)
        {
            var photos = await _photos.GetAll().Skip(skip).Take(21).ToListAsync();
            return Partial("_ImagesCardPartial", photos);
        }

        public async Task<IActionResult> OnPostUpdateAsync(int id)
        {
            var photo = await _photos.GetAsync(id);
            await _photos.UpdateAsync(photo);
            return RedirectToPage(nameof(Index));
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _photos.RemoveAsync(id);
            return RedirectToPage(nameof(Index));
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //var photo = new Faker<Photo>()
            //    .RuleFor(p => p.Name, e => e.Name.FullName())
            //    .RuleFor(p => p.Url, e => e.Image.LoremFlickrUrl())
            //    .Generate();

            //await _photos.AddAsync(photo);

            var photos = await Task.Run(() => new Faker()
                .Make(1000, () =>
                {
                    var photo = new Faker<Photo>()
                        .RuleFor(p => p.Name, v => v.Name.FullName())
                        .RuleFor(p => p.Url, v => v.Image.LoremFlickrUrl(400, 300));

                    return photo.Generate();
                })
            );

            await _photos.AddRangeAsync(photos);

            return RedirectToPage(nameof(Index));
        }

        public async Task<IActionResult> OnPostResetAsync()
        {
            await _context.ResetDb();
            return RedirectToPage(nameof(Index));
        }
    }
}
