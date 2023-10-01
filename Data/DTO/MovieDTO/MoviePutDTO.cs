namespace WebAPI.Data.DTO
{
    using System.ComponentModel.DataAnnotations;

    public class MoviePutDTO
    {
        [Required]
        public int Id { get; set; }

        [StringLength(100)]
        public string Title { get; set; }
           
    }
}
