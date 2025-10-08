using DataProcessorService;
using DataProcessorService.Abstractions;
using DataProcessorService.Models;
using DataProcessorService.Services;
using DataProcessorService.Storage;
using DataProcessorService.Storage.DbContexts;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.AddSingleton<IGetMessageService, GetMessageService>();
builder.Services.AddSingleton<ISaveMessageStorage, SaveMessageStorage>();
builder.Services.Configure<RabbitMQSettings>(builder.Configuration.GetSection("RabbitMQSettings"));
builder.Services.AddSingleton<IConnectionFactory>(_=>new ConnectionFactory() { HostName = "localhost"});

builder.Services.AddDbContext<Module_SqliteContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Default")));

var host = builder.Build();
host.Run();
