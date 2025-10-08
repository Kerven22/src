using FileParserService;
using FileParserService.Abstraction;
using FileParserService.Models;
using FileParserService.Service;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.Configure<RabbitMQSettings>(builder.Configuration.GetSection("RabbitMQSettings"));
builder.Services.AddSingleton<ISerializerService, SerializerService>();
builder.Services.AddSingleton<ISendMessage, SendMessage>(); 

var host = builder.Build();
host.Run();
