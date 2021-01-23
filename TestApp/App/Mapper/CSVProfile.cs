using AutoMapper;
using TestApp.App.DTO;
using Entities = TestApp.Domain.Entities;


namespace TestApp.App.Mapper
{
    public class CSVProfile : Profile
    {
        public CSVProfile()
        {
            CreateMap<CSVDto, Entities.CSV>().ReverseMap();
        }
    }
}
