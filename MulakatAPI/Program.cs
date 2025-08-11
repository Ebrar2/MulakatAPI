using Microsoft.EntityFrameworkCore;
using MulakatAPI.Core.Repositories;
using MulakatAPI.Core.Services;
using MulakatAPI.Repository;
using MulakatAPI.Repository.Repositories;
using MulakatAPI.Service.Services;
using Scalar.AspNetCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>  
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);   
    });
});

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddScoped(typeof(IService<>),typeof(Service<>));

builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();
builder.Services.AddScoped<ICalmaListeRepository, CalmaListeRepository>();
builder.Services.AddScoped<ISanatciRepository, SanatciRepository>();
builder.Services.AddScoped<ISarkiRepository, SarkiRepository>();
builder.Services.AddScoped<ICalmaListeSarkiRepository, CalmaListeSarkiRepository>();


builder.Services.AddScoped<ICalmaListeSarkiService, CalmaListeSarkiService>();

builder.Services.AddScoped<IAlbumService, AlbumService>();
builder.Services.AddScoped<ICalmaListeService, CalmaListeService>();
builder.Services.AddScoped<ISanatciService, SanatciService>();
builder.Services.AddScoped<ISarkiService, SarkiService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.MapScalarApiReference();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
