using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FamPix.Web.Data;
using FamPix.Web.Entities;
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
            using var codec = SkiaSharp.SKCodec.Create(file.OpenReadStream());
            var info = codec.Info;

            var desiredWidth = 190;

            var supportedScale = codec.GetScaledDimensions((float)desiredWidth / info.Width);

            var nearest = new SkiaSharp.SKImageInfo(supportedScale.Width, supportedScale.Height);
            var bmp = SkiaSharp.SKBitmap.Decode(codec, nearest);

            var realScale = (float)info.Height / info.Width;
            var desired = new SkiaSharp.SKImageInfo(desiredWidth, (int)(realScale * desiredWidth));
            bmp = bmp.Resize(desired, SkiaSharp.SKFilterQuality.High);

            using var ms = new MemoryStream();
            using var img = SkiaSharp.SKImage.FromBitmap(bmp);
            using var data = img.Encode(SkiaSharp.SKEncodedImageFormat.Png, 80);
            data.SaveTo(ms);

            var base64image = Convert.ToBase64String(ms.ToArray());

            _context.Photos.Add(new Photo()
            {
                Name = Path.GetFileNameWithoutExtension(file.FileName),
                Thumbnail = $"data:image/jpg;base64,{base64image}"
            });

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
