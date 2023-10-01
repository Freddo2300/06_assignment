namespace WebAPI.Data.DTO
{
    using System.ComponentModel.DataAnnotations;

    public class FranchisePostDTO
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(2000)] // increased length based on `ntext` data type
        public string Description { get; set; }
    }
}
