using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PicPayBackEnd.Data.Context;
using PicPayBackEnd.Data.Repositories;
using PicPayBackEnd.Data.Services;
using PicPayBackEnd.Domain.Entities;
using PicPayBackEnd.Domain.Validation;
using PicPayBackEnd.Domain.Validation.ValueObjects;

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

builder.Services.AddScoped<IValidator<User>, UserValidator>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
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
