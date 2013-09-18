using System.ComponentModel.DataAnnotations.Schema;

namespace EthioSpark.Entities
{
    public class Picture
    {
        public int PictureId { get; set; }
        public int UserId { get; set; }
        public string Filename { get; set; }
        public float? Description { get; set; }

        public User User { get; set; }
    }
}