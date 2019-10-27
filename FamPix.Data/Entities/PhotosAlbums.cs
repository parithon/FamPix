using System;
using System.Collections.Generic;
using System.Text;

namespace FamPix.Data.Entities
{
    public class PhotosAlbums
    {
        public int PhotoId { get; set; }
        public int AlbumId { get; set; }

        public PhotoDAO Photo { get; set; }

        public AlbumDAO Album { get; set; }
    }
}
