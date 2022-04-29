using Autofac.Extensions.DependencyInjection;
using CDDD.Application.DI;
using Domain.Interfaces;
using Domain.Models;
using Domain.Services;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Configuration;
using System.Text.Json;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DBContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen(c =>
            {
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Prova Marcus Marques", Version = "v1" });
});
// Add a service to DI
//builder.Services.AddSingleton(typeof(IRepository<Cliente>), typeof(ClienteRepository));
//Initializer.Configure(builder.Services, Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddScoped(typeof(IRepository<Cliente>), typeof(ClienteRepository));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(ClienteService));
builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
        
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Prova Marcus Marques v1"));
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
