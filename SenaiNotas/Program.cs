using Microsoft.Extensions.Options;
using SenaiNotas.Context;
using SenaiNotas.Interfaces;
using SenaiNotas.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();





builder.Services.AddCors(options =>
{
    options.AddPolicy("minhaOrigens", policy =>
    {
        policy.WithOrigins("http://localhost:3000") 
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


builder.Services.AddTransient<SenaiNotesContext, SenaiNotesContext>();
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();






builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var pastaDeDestino = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

if (!Directory.Exists(pastaDeDestino)) { Directory.CreateDirectory(pastaDeDestino);}

app.Run();
