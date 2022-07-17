using Entities.Commands;
using IPlan.Common.Extensions.DependencyInjection;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMessageBroker(option =>
 {
     option.RabbitMqConfigure = (context, rabbitConfig) =>
     {
         rabbitConfig.Host("localhost", "usersExample", h =>
         {
             h.Username("guest");
             h.Password("guest");
         });
     };

     EndpointConvention.Map<CreateUser>(new Uri($"queue:CreateUserTEST"));
 });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
