using System.Collections.Generic;
using System.Linq;

namespace FamPix.Web.Entities
{
    public class Photo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Thumbnail { get; set; }

        public string Cover { get; set; }

        public string Full { get; set; }

        internal ICollection<PhotoAlbum> PhotoAlbums { get; set; } = new List<PhotoAlbum>();

        internal ICollection<PhotoTag> PhotoTags { get; set; } = new List<PhotoTag>();

        public IEnumerable<Album> Albums => PhotoAlbums.Select(photoAlbum => photoAlbum.Album);

        public IEnumerable<Tag> Tags => PhotoTags.Select(photoTag => photoTag.Tag);
    }
}
