using CommandAPI.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Npgsql;  
using AutoMapper;

//using NLog;
//using NLog.Web;

//var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
//var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
//logger.Debug("init main");


var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
//builder.Host.UseNLog();

var ConnectionBuilder = new NpgsqlConnectionStringBuilder();
ConnectionBuilder.ConnectionString = builder.Configuration.GetConnectionString("Postgres");
ConnectionBuilder.Username = builder.Configuration["UserID"];
ConnectionBuilder.Password = builder.Configuration["Password"];
//logger.Info(ConnectionBuilder.ConnectionString);

//Console.WriteLine(ConnectionBuilder.ConnectionString);
// Add services to the container.

builder.Services.AddControllers();
// builder.Services.AddScoped<ICommandAPIRepo, MockCommandAPIRepo >();
builder.Services.AddScoped<ICommandAPIRepo, SqlCommandAPIRepo >();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

/*builder.Services.AddSwaggerGen();*/

//building in security
builder.Services.AddDbContext<CommandDBContext>(options =>
                options.UseNpgsql(ConnectionBuilder.ConnectionString));


// builder.Services.AddDbContext<CommandDBContext>(options =>
//                 options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres")));



var app = builder.Build();
// Configure the HTTP request pipeline.

var optionsBuilder = new DbContextOptionsBuilder<CommandDBContext>();
    optionsBuilder.UseNpgsql(ConnectionBuilder.ConnectionString);

var context  = new CommandDBContext(optionsBuilder.Options);
context.Database.Migrate();

//var dbContext = new ApplicationDbContext(optionsBuilder.Options);

if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

