using AutoMapper;
using PracticeTestGaiaNext.Api.Dtos;
using PracticeTestGaiaNext.Domain.Entities;

namespace PracticeTestGaiaNext.Api.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
        }
    }
}