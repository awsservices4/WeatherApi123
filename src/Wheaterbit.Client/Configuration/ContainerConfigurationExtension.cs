﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Validot;
using Wheaterbit.Client.Abstractions;
using Wheaterbit.Client.Options;
using Wheaterbit.Client.Validation;

namespace Wheaterbit.Client.Configuration
{
    public static class ContainerConfigurationExtension
    {
        public static IServiceCollection AddWeatherbit(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.Configure<WeatherbitOptions>(configuration.GetSection(WeatherbitOptions.Weatherbit));

            return serviceCollection.AddSingleton<IWheaterbitHttpClient, WheaterbitHttpClient>()
                .AddSingleton(typeof(IValidator<WeatherbitOptions>), Validator.Factory.Create(new WeatherbitOptionsSpecificationHolder()));
        }
    }
}
