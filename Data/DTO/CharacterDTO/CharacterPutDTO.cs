namespace WebAPI.Data.DTO
{
    using System.ComponentModel.DataAnnotations;

    public class CharacterPutDTO
    {
        // he validation attributes ([Required] and [StringLength]) help ensure the client provides appropriate data when creating or updating an entity.
        [Required] 
        public int Id { get; set; }

        [StringLength(100)]
        public string FullName { get; set; }

        [StringLength(20)]
        public string? Alias { get; set; }

        [StringLength(200)]
        public string? PictureUrl { get; set; }
    }
}
