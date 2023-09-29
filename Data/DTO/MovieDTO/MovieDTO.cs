namespace WebAPI.Data.DTO.MovieDTO
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } 
        
        
    }

    public class MovieCreateUpdateDTO
    {   
        public string Title { get; set; }
    
    }
}

