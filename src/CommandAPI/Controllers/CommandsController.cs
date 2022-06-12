using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CommandAPI.Data;
using CommandAPI.Models;

namespace CommandAPI.Controllers{

    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase{

        private readonly ICommandAPIRepo _commandRepo;
        public CommandsController(ICommandAPIRepo repository)
        {
            _commandRepo = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> GetAllCommands(){
            var commands = _commandRepo.GetAllCommands();
            return Ok(commands);
        }

        [HttpGet("{id}")]
        public ActionResult<Command> Get(int id){
            var command = _commandRepo.GetCommandById(id);
            if( command == null ) {
                return NotFound();
            }
            return command;
        }
    }
}