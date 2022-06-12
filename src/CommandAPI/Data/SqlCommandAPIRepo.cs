using Microsoft.EntityFrameworkCore;
using CommandAPI.Models;

namespace CommandAPI.Data{
    public class SqlCommandAPIRepo: ICommandAPIRepo{

        private readonly CommandDBContext _context;
        public SqlCommandAPIRepo(CommandDBContext context)
        {
            _context = context;
        }
         public bool SaveChanges(){
            throw new System.NotImplementedException();
        }
        public IEnumerable<Command> GetAllCommands(){
            
            var commands = _context.commandItems.ToList<Command>();
           return commands;
        }
        public Command GetCommandById(int id){

            var command = _context.commandItems.FirstOrDefault(p => p.Id == id);
            return command;
        }
        public void CreateCommand(Command cmd){

        }
        public void UpdateCommand(Command cmd){

        }
        public void DeleteCommand(Command cmd){

        }
    
    }
}