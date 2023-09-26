using System;
namespace _06_assignment.Model
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }  
        public int ReleaseYear { get; set; }
        public string Director { get; set; }
        public string Picture { get; set; } // URL 
        public string Trailer { get; set; } 
        public int FranchiseId { get; set; } // Foreign Key
        public Franchise Franchise { get; set; } // Navigation property
        public ICollection<Character> Characters { get; set; } // Navigation property for many-to-many relationship
    }

}

