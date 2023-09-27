using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Data.Entities
{
    [Table(nameof(Character))]
    public class Character
    {   
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string FullName { get; set; }

        [StringLength(20)]
        public string? Alias { get; set; }

        [StringLength(200)]
        public string? PictureUrl { get; set; }
        
        public ICollection<Movie>? Movies { get; set; }
    }
}