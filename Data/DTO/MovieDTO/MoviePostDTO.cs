namespace WebAPI.Data.DTO
{
    using System.ComponentModel.DataAnnotations;

    public class MoviePostDTO
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        // Add other properties?
    }
}
