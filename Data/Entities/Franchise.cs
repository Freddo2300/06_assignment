

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebAPI.Data.Entities
{
    [Table(nameof(Franchise))]
    public class Franchise
    {
        [Key]
        [Column(Order=1)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Column(Order=2)]
        public required string Name { get; set; }

        [Column(Order=3, TypeName="ntext")]
        public required string Description { get; set; }
        
        public ICollection<Movie> Movies { get; set; }
    }
}