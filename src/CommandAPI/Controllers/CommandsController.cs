using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CommandAPI.Data;
using CommandAPI.Models;
using AutoMapper;
using CommandAPI.Dtos;

namespace CommandAPI.Controllers{

    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase{

        private readonly ICommandAPIRepo _commandRepo;
        private readonly IMapper _mapper;
        public CommandsController(ICommandAPIRepo repository, IMapper mapper)
        {
            _commandRepo = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands(){
            var commands = _commandRepo.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commands) );
        }

        [HttpGet("{id}", Name="GetCommandById")]
        public ActionResult<CommandReadDto> GetCommmandById(int id){
            var command = _commandRepo.GetCommandById(id);
            if( command == null ) {
                return NotFound();
            }
            return Ok(_mapper.Map<CommandReadDto>(command));
        }
        [HttpPost]
        public ActionResult<CommandReadDto> Post(CommandCreateDto command){
            var commandMapped = _mapper.Map<Command>(command);

            _commandRepo.CreateCommand(commandMapped);
            _commandRepo.SaveChanges();

            var commandReadDto = _mapper.Map<CommandReadDto>(commandMapped);

            return CreatedAtRoute("GetCommandById", new {Id = commandReadDto.Id} ,commandReadDto);
        }
    }
}