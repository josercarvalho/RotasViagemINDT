using FluentValidation;
using Microsoft.OpenApi.Models;
using RotasViagem.Domain.Entities;
using RotasViagem.Domain.Validators;
using RotasViagem.Infra.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

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

builder.Services.AddScoped<RotaDbContext>();

builder.Services.AddScoped<IValidator<Rota>, RotaValidator>();
builder.Services.AddScoped<IValidator<Trecho>, TrechoValidator>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTudo", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

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

app.UseAuthorization();

app.MapControllers();

app.Run();
