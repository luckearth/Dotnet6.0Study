using WebApplication1;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Autofac;
using Serilog;
using Serilog.Events;
using Microsoft.Extensions.Hosting;
var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddJsonConsole();

var startup=new Startup(builder.Configuration);
Log.Logger = new Serilog.LoggerConfiguration()
               .MinimumLevel.Information()
               .WriteTo.File("Logs/logs.txt")
               .WriteTo.Console(LogEventLevel.Information).CreateLogger(); 
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(startup.ConfigureContainer).UseSerilog();

// Add services to the container.
startup.ConfigureServices(builder.Services);

//builder.Services.AddControllers();
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new() { Title = "WebApplication1", Version = "v1" });
//});

var app = builder.Build();


startup.Configure(app,app.Environment);

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplication1 v1"));
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

app.Run();
