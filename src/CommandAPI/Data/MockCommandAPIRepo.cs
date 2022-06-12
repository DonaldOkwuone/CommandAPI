using System.Collections.Generic;
using CommandAPI.Data;
using CommandAPI.Models;


namespace CommandAPI.Data{
    public class MockCommandAPIRepo : ICommandAPIRepo{

        public bool SaveChanges(){
            throw new System.NotImplementedException();
        }
        public IEnumerable<Command> GetAllCommands(){
            var commands = new List<Command>{
                new Command(){
                    Id = 1,
                    HowTo = "Hello",
                    Platform = "test",
                    CommandLine = "test"
                },
                new Command{
                    Id=2,
                    HowTo="Hello 2",
                    Platform="Test 2",
                    CommandLine="Test 2"
                }
            };
           return commands;
        }
        public Command GetCommandById(int id){
            return new Command(){
                Id=1,
                HowTo="Try  harder",
                Platform = "Production",
                CommandLine = "Terminal"
            };
        }
        public void CreateCommand(Command cmd){

        }
        public void UpdateCommand(Command cmd){

        }
        public void DeleteCommand(Command cmd){

        }
    }
}