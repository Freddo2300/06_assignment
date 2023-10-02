namespace WebAPI.Data.DTO.CharacterDTO
{
    using System.ComponentModel.DataAnnotations;

    public class CharacterPostDTO
    {
        [StringLength(100)]
        public string FullName { get; set; }

        [StringLength(20)]
        public string Alias { get; set; }

        [StringLength(200)]
        public string PictureUrl { get; set; }
    }
}
