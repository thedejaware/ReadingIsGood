using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RIG.Application.Behaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RIG.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly()); // Assembly, herhangi bir classın Profile class'ını inherit edip etmediğini kontrol ediyor.
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly()); // Assembly, herhangi bir class'ın AbstractValidator'ı inherit edip etmediğini kontrol ediyor.
            services.AddMediatR(Assembly.GetExecutingAssembly()); // Assembly, herhangi bir class'ın IRequest ya da IRequestHandler interface'lerini implement edip etmediğini kontrol ediyor.

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            return services;
        }
    }
}
