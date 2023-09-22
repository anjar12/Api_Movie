using Domain.Interfaces;
using Domain.Repository.Validators;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddTransient<IAuthRepository, AuthRepository>();
            services.AddTransient<IMovieReposiory, MovieRepository>();
            services.AddTransient<IValidators, ValidatorRepository>();

            // Adding the Unit of work to the DI container
            services.AddTransient<IUnitOfWorks, UnitOfWorks>();

            return services;
        }
    }
}
