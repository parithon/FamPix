namespace FamPix.Web.Entities
{
    public class PhotoAlbum
    {
        public int PhotoId { get; set; }
        public Photo Photo { get; set; }

        public int AlbumId { get; set; }
        public Album Album { get; set; }
    }
}
