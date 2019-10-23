using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FamPix.Web.Data;
using FamPix.Web.Entities;
using FamPix.Web.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FamPix.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly FamPixDbContext _context;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(FamPixDbContext context, ILogger<IndexModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IList<Photo> Photos { get; set; }

        public async Task OnGetAsync()
        {
            Photos = await _context.Photos.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync(IFormFile file)
        {
            using var stream = file.OpenReadStream();
            var base64Thumbnail = await SkiaSharpUtils.GenerateImageType(SkiaSharpUtils.ImageType.Thumbnail, stream);
            var base64Cover = await SkiaSharpUtils.GenerateImageType(SkiaSharpUtils.ImageType.Cover, stream);
            var base64Full = await SkiaSharpUtils.GenerateImageType(SkiaSharpUtils.ImageType.Full, stream);
            
            _context.Photos.Add(new Photo()
            {
                Name = Path.GetFileNameWithoutExtension(file.FileName),
                Thumbnail = $"data:image/png;base64,{base64Thumbnail}",
                Cover = $"data:image/png;base64,{base64Cover}",
                Full = $"data:image/png;base64,{base64Full}"
            });

            await _context.SaveChangesAsync();

            return new OkResult();
        }
    }
}
