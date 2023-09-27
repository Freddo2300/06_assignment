using System;
namespace _06_assignment.Model
{
        public class Character
        {
            public int Id { get; set; }
            public string FullName { get; set; }
            public string Alias { get; set; }
            public string Gender { get; set; }
            public string Picture { get; set; } // URL to the photo
            public ICollection<Movie> Movies { get; set; } // Navigation property for many-to-many relationship
        }
}