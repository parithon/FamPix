using System.Collections.Generic;

namespace FamPix.Data.Entities
{
    public class PhotoDAO : EntityDAO
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public ICollection<PhotosAlbums> Albums { get; set; } = new List<PhotosAlbums>();
    }
}
