namespace WebAPI.Data.DTO.MovieDTO
{
    using System.ComponentModel.DataAnnotations;

    public class MoviePostDTO
    {
        [StringLength(100)]
        public string Title { get; set; }

        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public string Director { get; set; }
    }
}
