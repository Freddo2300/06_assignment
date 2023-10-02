using AutoMapper;

using WebAPI.Data.Entities;
using WebAPI.Data.DTO.CharacterDTO;
using WebAPI.Data.DTO.MovieDTO;
using WebAPI.Data.DTO.FranchiseDTO;

namespace WebAPI.MappingProfiles
{
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            CreateMap<Character, CharacterPutDTO>().ReverseMap();
            CreateMap<Character, CharacterPostDTO>().ReverseMap();
            CreateMap<Character, CharacterDTO>()
                .ForMember(cdto => cdto.Movies, options => options
                    .MapFrom(c => c.Movies.Select(m => new MovieDTO 
                        {
                            Id = m.Id,
                            Title = m.Title,
                            ReleaseYear = m.ReleaseYear,
                            Director = m.Director,
                        }
                    )
                )
            );
        }
    }
}