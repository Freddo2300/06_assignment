namespace WebAPI.Data.DTO
{
    using System.ComponentModel.DataAnnotations;

    public class FranchisePutDTO
    {
        [Required]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(2000)] // increased length based on `ntext` data type.
        public string Description { get; set; }
    }
}
