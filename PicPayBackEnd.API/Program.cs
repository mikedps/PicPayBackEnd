using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PicPayBackEnd.Data.Context;
using PicPayBackEnd.Data.Interceptors;
using PicPayBackEnd.Data.Repositories;
using PicPayBackEnd.Domain.Entities;
using PicPayBackEnd.Domain.Validation.ValueObjects;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
builder.Services.AddSingleton<PublishDomainEventsInterceptor>();
builder.Services.AddScoped<IValidator<User>, UserValidator>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddLogging();

builder.Services.AddDbContext<PicPayContext>(
    (sp,option) =>
    {
        var interceptor = sp.GetRequiredService<PublishDomainEventsInterceptor>();
        var conexao = builder.Configuration.GetConnectionString("DefaultConnection");
        option.UseSqlServer(conexao)
        .AddInterceptors(interceptor);
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
