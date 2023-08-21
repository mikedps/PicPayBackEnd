using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PicPayBackEnd.Data.Context;
using PicPayBackEnd.Data.Repositories;
using PicPayBackEnd.Data.Services;
using PicPayBackEnd.Domain.Entities;
using PicPayBackEnd.Domain.Validation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<PicPayContext>(
    option =>
    {
        var conexao = builder.Configuration.GetConnectionString("DefaultConnection");
        option.UseSqlServer(conexao);
    });

builder.Services.AddScoped<IValidator<Payer>, PayerValidation>();
builder.Services.AddScoped<IPayerService, PayerService>();
builder.Services.AddScoped<IPayerRepository, PayerRepository>();
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
