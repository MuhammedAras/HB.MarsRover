using HB.MarsRover.Core.Command;
using HB.MarsRover.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System;
using HB.MarsRover.Domain;

namespace HB.MarsRover.Core
{
    public static class DependecyResolver
    {
        public static IServiceProvider RegisterServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<ICommand, RotateLeftCommand>();
            services.AddTransient<ICommand, RotateRightCommand>();
            services.AddTransient<ICommand, MoveCommand>();
            services.AddTransient<IInputParser, InputParser>();
            services.AddTransient<IPosition, Position>();
            services.AddTransient<IPlateau>(e => new Plateau(e.GetService<IPosition>()));
            services.AddTransient<IRover>(e => new Rover(e.GetService<IPosition>()));
            services.AddTransient<IRoverCommandCenter, RoverCommandCenter>();

            return services.BuildServiceProvider();
        }

        public static void DisposeServices(this IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
            {
                return;
            }
            if (serviceProvider is IDisposable)
            {
                ((IDisposable)serviceProvider).Dispose();
            }
        }
    }
}
