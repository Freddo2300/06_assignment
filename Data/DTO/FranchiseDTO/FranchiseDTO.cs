namespace WebAPI.Data.DTO.FranchiseDTO
{
    public class FranchiseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public franchiseMovieDTO[] Movies { get; set; }
    }

    public class franchiseMovieDTO {
        public int Id {get; set;}
        public string Title {get; set;}
        
    }
}