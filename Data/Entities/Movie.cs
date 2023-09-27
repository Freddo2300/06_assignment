using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Data.Entities
{
    [Table(nameof(Movie))]
    public class Movie
    {
        [Key]
        [Column(Order=1)]
        public int Id { get; set; }

        [Required]
        [Column(Order=2)]
        [StringLength(100)]
        public required string Title { get; set; }

        [Column(Order=3, TypeName="ntext")]
        public string? Genre { get; set; }
        
        public int ReleaseYear { get; set; }

        [Required]
        [StringLength(100)]
        public required string Director { get; set; }

        [StringLength(100)]
        public string? PictureUrl { get; set; }

        [StringLength(100)]
        public string? TrailerUrl { get; set; }
        public Franchise? Franchise { get; set; }
        public ICollection<Character>? Characters { get; set; }
    }
}