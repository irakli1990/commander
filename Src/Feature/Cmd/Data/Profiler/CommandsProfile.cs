using AutoMapper;
using Commander.Src.Feature.Cmd.Data.Dtos;
using Commander.Src.Feature.Cmd.Domain.Entity;

namespace Commander.Src.Feature.Cmd.Data.Profiler
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            CreateMap<Command, CommandReadDto>();
            CreateMap<CommandCreateDto, Command>();
            CreateMap<CommandUpdateDto, Command>();
            CreateMap<Command, CommandUpdateDto>();
        }

    }
}