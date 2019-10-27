using System.Collections.Generic;

namespace FamPix.Data.Entities
{
    public class AlbumDAO : EntityDAO
    {
        public string Name { get; set; }

        public ICollection<PhotosAlbums> Photos { get; set; } = new List<PhotosAlbums>();
    }
}
