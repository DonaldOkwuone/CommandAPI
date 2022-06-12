using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design ;
using CommandAPI.Models;

namespace CommandAPI.Data{
    public class CommandDBContext: DbContext{
        public CommandDBContext(DbContextOptions<CommandDBContext> options) : base(options)
        {
            
        }

        public DbSet<Command> commandItems {get; set;}
    }
}