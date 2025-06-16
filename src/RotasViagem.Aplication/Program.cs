using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RotasViagem.Aplication.Controllers;
using RotasViagem.Domain.Entities;
using RotasViagem.Domain.Validators;
using RotasViagem.Infra.Context;
using RotasViagem.Infra.Interfaces;
using RotasViagem.Infra.Repositories;
using RotasViagem.Services.Mappings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Swagger

var contactUrl = builder.Configuration["Swagger:ContactUrl"];

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Rota Viagem API",
        Version = "v1",
        Description = "API para cadastro de rotas e consulta da melhor rota de viagem",
        Contact = new OpenApiContact
        {
            Name = "José R. Carvalho",
            Email = "josercarvalho@gmail.com",
            Url = new Uri(contactUrl ?? "https://github.com/josercarvalho")
        }
    });

});

#endregion

#region Database

builder.Services.AddDbContext<RotaDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<RotaDbContext>();
builder.Services.AddScoped<IValidator<Rota>, RotaValidator>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTudo", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

#endregion

#region Repositories

builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IRotaRepository, RotaRepository>();

#endregion

#region Services    

builder.Services.AddAutoMapper(typeof(RotaProfile));

#endregion

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<RotaDbContext>();
    dbContext.Seed();
}

if (app.Environment.IsDevelopment())
{
    app.UseCors("PermitirTudo");
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rota Viagem API v1");
    });
}

app.UseHttpsRedirection();

app.MapRotasEndpoints();

await app.RunAsync();
