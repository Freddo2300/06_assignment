using AutoMapper;

using WebAPI.Data.Entities;
using WebAPI.Data.DTO.CharacterDTO;
using WebAPI.Data.DTO.MovieDTO;
using WebAPI.Data.DTO.FranchiseDTO;

namespace WebAPI.MappingProfiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Franchise, FranchisePutDTO>().ReverseMap();
            CreateMap<Movie, MoviePutDTO>().ReverseMap();
                // .ForMember(mdto => mdto.Franchise, options => options 
                //     .MapFrom(f => new MovieFranchiseDTO {
                //         Id = f.Franchise.Id,
                //         Name = f.Franchise.Name,
                //         Description = f.Franchise.Description,
                //     })
                // ).ReverseMap();
            CreateMap<Movie, MoviePostDTO>().ReverseMap();
            CreateMap<Movie, MovieDTO>()
                .ForMember(mdto => mdto.Characters, options => options
                    .MapFrom(m => m.Characters.Select(c => new MovieCharacterDTO
                        {
                            Id = c.Id,
                            Name = c.FullName,
                        }
                    )
                )
                ).ForMember(mdto => mdto.Franchise, options => options 
                    .MapFrom(f => new MovieFranchiseDTO {
                        Id = f.Franchise.Id,
                        Name = f.Franchise.Name,
                        Description = f.Franchise.Description,
                    })
                    
                );
        
        }
    }
}