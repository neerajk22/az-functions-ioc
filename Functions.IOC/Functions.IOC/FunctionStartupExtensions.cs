using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Project.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;

namespace Functions.IOC
{
    public static class FunctionStartupExtensions
    {
        public static IServiceCollection RegisterFunctionServices(this IServiceCollection services)
        {
            var configurationBuilder =
                new ConfigurationBuilder();

            var environmentVariables = Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Process);

            var memoryCollectionVariables = new List<KeyValuePair<string, string>>();
            var data = environmentVariables as Hashtable;

            foreach (var environmentVariable in environmentVariables)
            {
                var keyValue = environmentVariable is DictionaryEntry entry ? entry : default(DictionaryEntry);
                memoryCollectionVariables.Add(new KeyValuePair<string, string>(keyValue.Key.ToString(), keyValue.Value?.ToString()));
            }

            // Add defaultConfigurationStrings
            configurationBuilder.AddInMemoryCollection(memoryCollectionVariables);

            // Directory.GetCurrentDirectory() + "\\";
            /*
			var configuration = new ConfigurationBuilder()
								 .SetBasePath(directoryPath)
								.AddJsonFile(directoryPath + "appsettings.json", false, true)
								.AddJsonFile(directoryPath + "appsettings.local.json", true)
								.Build() as IConfiguration;
								*/
            var configuration = configurationBuilder.Build();

            var connection = configuration.GetConnectionString("DB:ConnectionString");

            // services.AddDbContext<>(options => options.UseSqlServer(connection, o => o.EnableRetryOnFailure()));

            // add logging
            services.AddSingleton(new LoggerFactory().AddDebug());
            services.AddLogging();

            services.AddMemoryCache();

            services.RegisterConfigServices();            
            services.RegisterServices();

            services.AddSingleton<HttpClient>();

            return services;
        }
    }
}
