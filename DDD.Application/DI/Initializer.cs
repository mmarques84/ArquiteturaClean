using Domain.Interfaces;
using Domain.Models;
using Domain.Services;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CDDD.Application.DI {
    public class Initializer {
        public static void Configure (IServiceCollection services, string conection) 
        {
            services.AddDbContext<DBContext> (options => options.UseSqlServer (conection));

            services.AddScoped (typeof (IRepository<Cliente>), typeof (ClienteRepository));
            services.AddScoped (typeof (IRepository<>), typeof (Repository<>));
            services.AddScoped (typeof (ClienteService));
            services.AddScoped (typeof (IUnitOfWork), typeof (UnitOfWork));
        }
    }
}