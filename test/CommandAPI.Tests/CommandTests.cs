using System.ComponentModel.DataAnnotations;
using Xunit;
using CommandAPI.Models;
using System;

namespace CommandAPI.Tests 
{
    public class CommandTests: IDisposable
    {
        public Command? TestCommand;

        [Fact]
        public void CanChangeHowTo(){
            //Arrange
             TestCommand = new Command {
                HowTo = "Run Unit Tests",
                CommandLine = "dotnet test",
                Platform = "XUnit"
            };
            //Act
            TestCommand.HowTo = "Execute Unit Tests";
            //Assert
            Assert.Equal("Execute Unit Tests", TestCommand.HowTo);


        }

        public void Dispose(){
            TestCommand = null;
        }
    }
}