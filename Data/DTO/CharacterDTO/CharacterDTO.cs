using WebAPI.Data.DTO.MovieDTO;

namespace WebAPI.Data.DTO.CharacterDTO
{
    public class CharacterDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Alias { get; set; }
        public string Gender { get; set; }
        public string PictureUrl { get; set; }
        public List<MovieDTO.MovieDTO> Movies { get; set; }
    }
}