using SkiaSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FamPix.Web.Utils
{
    public static class SkiaSharpUtils
    {
        public enum ImageType
        {
            Thumbnail = 190,
            Cover = 375,
            Full = 960
        }

        public static async Task<string> GenerateImageType(ImageType type, Stream imageStream)
        {
            return await Task.Run(async () =>
            {
                using var ms = new MemoryStream();
                await imageStream.CopyToAsync(ms);
                imageStream.Position = ms.Position = 0;

                using var codec = SKCodec.Create(ms);
                var info = codec.Info;

                var desiredWidth = (int)type;

                var supportedScale = codec.GetScaledDimensions((float)desiredWidth / info.Width);

                var nearest = new SKImageInfo(supportedScale.Width, supportedScale.Height);
                var bmp = SKBitmap.Decode(codec, nearest);

                var realScale = (float)info.Height / info.Width;
                var desired = new SKImageInfo(desiredWidth, (int)(realScale * desiredWidth));
                bmp = bmp.Resize(desired, SKFilterQuality.High);

                using var img = SKImage.FromBitmap(bmp);
                using var data = img.Encode(SKEncodedImageFormat.Png, 80);

                return Convert.ToBase64String(data.ToArray());
            });
        }
    }
}
