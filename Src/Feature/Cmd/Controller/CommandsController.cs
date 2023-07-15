using System.Collections.Generic;
using AutoMapper;
using Commander.Src.Feature.Cmd.Data.Dtos;
using Commander.Src.Feature.Cmd.Domain.UseCase;
using Commander.Src.Core.NoParams;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Commander.Src.Feature.Cmd.Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Commander.Src.Feature.Cmd.Controller
{
    [ApiController]
    [Route("api/commands")]
    public class CommandsController : ControllerBase
    {
        private readonly GetCommandsUseCase _getCommandsUseCase;
        private readonly GetCommandByIdUseCase _getCommandByIdUseCase;
        private readonly IMapper _mapper;
        public CommandsController(GetCommandsUseCase getCommandsUseCase, GetCommandByIdUseCase getCommandByIdUseCase, IMapper mapper)
        {
            _getCommandsUseCase = getCommandsUseCase;
            _getCommandByIdUseCase = getCommandByIdUseCase;
            _mapper = mapper;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommandReadDto>>> GetAllCommands()
        {
            var useCaseResults = await _getCommandsUseCase.execute(new NoParams());
            List<Command> commands = null;
            try
            {
                useCaseResults.Match(
                   leftFunc: (error) => throw new Exception(),
                   rightFunc: (data) => commands = data
               );
                if (commands != null)
                {
                    return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commands));
                }
                return NotFound();
            }
            catch (System.Exception e)
            {

                return Problem(e.StackTrace);
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{id}", Name = "GetCommandById")]
        public async Task<ActionResult<CommandReadDto>> GetCommandById(int id)
        {
            var useCaseResults = await _getCommandByIdUseCase.execute(id);
            Command command = null;
            try
            {
                useCaseResults.Match(
                   leftFunc: (error) => throw new Exception(),
                   rightFunc: (data) => command = data
               );
                if (command != null)
                {
                    return Ok(_mapper.Map<CommandReadDto>(command));
                }
                return NotFound();
            }
            catch (System.Exception e)
            {

                return Problem(e.StackTrace);
            }
        }

        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            // var commandModel = _mapper.Map<Command>(commandCreateDto);
            // _repository.CreateCommand(commandModel);
            // _repository.SavedChanges();

            // var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);

            // return CreatedAtRoute(nameof(GetCommandById), new { Id = commandReadDto.Id }, commandReadDto);

            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            // var companyModelFromRepo = _repository.GetCommandById(id);
            // if (companyModelFromRepo == null)
            // {
            //     return NotFound();

            // }
            // _mapper.Map(commandUpdateDto, companyModelFromRepo);

            // _repository.UpdateCommand(companyModelFromRepo);
            // _repository.SavedChanges();


            // return NoContent();
            return null;
        }


        [HttpPatch("{id}")]
        public ActionResult PatchCommand(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
            // var companyModelFromRepo = _repository.GetCommandById(id);
            // if (companyModelFromRepo == null)
            // {
            //     return NotFound();

            // }
            // var comandToPatch = _mapper.Map<CommandUpdateDto>(companyModelFromRepo);

            // patchDoc.ApplyTo(comandToPatch, ModelState);

            // if (!TryValidateModel(comandToPatch))
            // {
            //     return ValidationProblem(ModelState);
            // }

            // _mapper.Map(comandToPatch, companyModelFromRepo);

            // _repository.UpdateCommand(companyModelFromRepo);
            // _repository.SavedChanges();

            // return NoContent();
            return null;
        }


        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            // var companyModelFromRepo = _repository.GetCommandById(id);
            // if (companyModelFromRepo == null)
            // {
            //     return NotFound();

            // }
            // _repository.DeleteCommand(companyModelFromRepo);
            // _repository.SavedChanges();

            // return NoContent();
            return null;
        }

    }
}