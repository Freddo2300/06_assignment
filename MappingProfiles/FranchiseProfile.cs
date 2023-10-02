using AutoMapper;

using WebAPI.Data.Entities;
using WebAPI.Data.DTO.FranchiseDTO;


namespace WebAPI.MappingProfiles
{
    public class FranchiseProfile : Profile
    {
        public FranchiseProfile()
        {
            CreateMap<Franchise, FranchisePutDTO>().ReverseMap();
            CreateMap<Franchise, FranchisePostDTO>().ReverseMap();
            CreateMap<Franchise, FranchiseDTO>()
                .ForMember(fdto => fdto.Movies, options => options
                    .MapFrom(f => f.Movies.Select(m => new franchiseMovieDTO 
                        {
                            Id = m.Id,
                            Title = m.Title,
                        }
                    )
                )
            );
        }
    }
}