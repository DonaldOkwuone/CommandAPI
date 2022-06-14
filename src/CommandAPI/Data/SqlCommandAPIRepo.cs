using Microsoft.EntityFrameworkCore;
using CommandAPI.Models;
using Npgsql;

namespace CommandAPI.Data{
    public class SqlCommandAPIRepo: ICommandAPIRepo{

        private readonly CommandDBContext _context;
        private readonly ILogger<SqlCommandAPIRepo> _logger;
        private readonly IConfiguration _configuration;
        public SqlCommandAPIRepo(CommandDBContext context, ILogger<SqlCommandAPIRepo> logger, IConfiguration configuration)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }
         public bool SaveChanges(){
           return  (_context.SaveChanges()>0);
        }
        public IEnumerable<Command> GetAllCommands(){

            _logger.LogDebug(_configuration.GetConnectionString("Postgres"));
            
             var commands = _context.commandItems.ToList<Command>();
           return commands;
        }
        public Command GetCommandById(int id){

            var command = _context.commandItems.FirstOrDefault(p => p.Id == id);
            return command;
        }
        public void CreateCommand(Command cmd){
            if(cmd ==null){
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.Add(cmd);

        }
        public void UpdateCommand(Command cmd){

        }
        public void DeleteCommand(Command cmd){

        }
    
    }
}