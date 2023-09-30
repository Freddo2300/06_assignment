using AutoMapper;
using WebAPI.Data.Entities;
using WebAPI.Data.DTO.CharacterDTO;
using WebAPI.Data.DTO.FranchiseDTO;
using WebAPI.Data.DTO.MovieDTO;

namespace WebAPI

{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
        CreateMap<Character, CharacterDTO>().ReverseMap();
        CreateMap<Character, CharacterCreateUpdateDTO>().ReverseMap();

        
        CreateMap<Franchise, FranchiseDTO>().ReverseMap();
        CreateMap<Franchise, FranchiseCreateUpdateDTO>().ReverseMap();

        
        CreateMap<Movie, MovieDTO>().ReverseMap();
        CreateMap<Movie, MovieCreateUpdateDTO>().ReverseMap();
        }
    }
}