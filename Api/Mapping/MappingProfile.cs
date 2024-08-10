using Api.ViewModels;
using AutoMapper;
using Main.Api.Commands;
using Main.Api.Models;

namespace Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RecordViewModel, SaveRecordCommand>();
            CreateMap<SaveRecordCommand, Record>();
        }
    }
}