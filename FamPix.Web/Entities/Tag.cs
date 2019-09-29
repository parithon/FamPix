using System.Collections.Generic;
using System.Linq;

namespace FamPix.Web.Entities
{
    public class Tag
    {
        public int Id { get; set; }

        public string Value { get; set; }

        public ICollection<PhotoTag> PhotoTags { get; set; } = new List<PhotoTag>();

        public IEnumerable<Photo> Images => PhotoTags.Select(photoTag => photoTag.Photo);
    }
}
