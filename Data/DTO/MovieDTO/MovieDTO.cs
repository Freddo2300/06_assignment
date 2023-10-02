using WebAPI.Data.DTO.FranchiseDTO;

namespace WebAPI.Data.DTO.MovieDTO
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public string Director { get; set; }
    }
}