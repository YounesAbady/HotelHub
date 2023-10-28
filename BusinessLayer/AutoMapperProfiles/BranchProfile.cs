using APIContract.BranchDTOs;
using AutoMapper;
using Models;

namespace BusinessLayer.AutoMapperProfiles
{
    public class BranchProfile : Profile
    {
        public BranchProfile()
        {
            CreateMap<Branch, BranchTinyDto>().ReverseMap();
        }
    }
}
