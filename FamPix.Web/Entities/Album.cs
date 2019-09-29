using System.Collections.Generic;
using System.Linq;

namespace FamPix.Web.Entities
{
    public class Album
    {
        public int Id { get; set; }

        public string Name { get; set; }

        internal ICollection<PhotoAlbum> PhotoAlbums { get; set; } = new List<PhotoAlbum>();

        public IEnumerable<Photo> Images => PhotoAlbums.Select(photoAlbum => photoAlbum.Photo);
    }
}
