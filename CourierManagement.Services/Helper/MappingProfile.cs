using AutoMapper;
using CourierManagement.Database.Tables;
using CourierManagement.Entities.Models;

namespace CourierManagement.Services.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Courier, CourierModel>().ReverseMap();
        }
    }
}
