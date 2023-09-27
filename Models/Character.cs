﻿using System;

namespace WebAPI.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Alias { get; set; }
        public string Gender { get; set; }
        public string PictureUrl { get; set; } // URL to the photo
        public ICollection<CharacterMovie> Movies { get; set; }
        }
}