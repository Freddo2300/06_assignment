using System;

namespace WebAPI.Models
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
        public Franchise Franchise { get; set; }
        public int FranchiseId { get; set; }

        public ICollection<CharacterMovie> Characters { get; set; }
    }
}