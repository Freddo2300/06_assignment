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

        public MovieCharacterDTO[] Characters { get; set; }
        public MovieFranchiseDTO Franchise { get; set; }
    }
    public class MovieCharacterDTO {
        public int Id {get;set;}
        public string Name {get;set;}
    }

    public class MovieFranchiseDTO {
        public int Id {get;set;}
        public string Name {get;set;}

        public string Description {get;set;}
    }
}