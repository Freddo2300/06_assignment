namespace WebAPI.Data.DTO.FranchiseDTO
{
    public class FranchiseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
    }

    public class FranchiseCreateUpdateDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
    
    }

}


