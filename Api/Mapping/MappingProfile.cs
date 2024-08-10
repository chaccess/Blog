using Api.ViewModels;
using AutoMapper;
using Main.Commands;
using Main.Models;

namespace Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RecordViewModel, SaveRecordCommand>();
        }
    }
}