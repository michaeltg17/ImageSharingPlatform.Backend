﻿using Microsoft.Extensions.DependencyInjection;
using Application.Services.Interfaces;
using Application.Services.Implementations;

namespace Application
{
    public static class ServiceConfigurator
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IImageService, ImageService>();

            return services;
        }
    }
}
