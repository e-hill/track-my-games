using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Refit;
using TrackMyGames.Refit;

namespace TrackMyGames.Setup
{
    public static class SetupRefitClients
    {
        public static void AddHandlers(IServiceCollection services)
        {
            services.AddTransient<PsnClientHandler>();
            services.AddTransient<HttpLoggingHandler>();
        }

        public static void AddPsnRefitClient(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(provider =>
            {
                var remoteAddress = configuration.GetValue<string>("Psn:Address");
                var handler = provider.GetRequiredService<HttpLoggingHandler>();

                handler.InnerHandler = new PsnClientHandler
                {
                    AllowAutoRedirect = false,
                    UseCookies = true,
                    CookieContainer = new CookieContainer(),
                };

                var httpClient = new HttpClient(handler) { BaseAddress = new Uri(remoteAddress) };

                var serializer = new NewtonsoftJsonContentSerializer(
                    new JsonSerializerSettings
                    {
                        ContractResolver = new DefaultContractResolver()
                        {
                            NamingStrategy = new SnakeCaseNamingStrategy()
                        }
                    });

                return RestService.For<IPsnApi>(httpClient, new RefitSettings(serializer));
            });
        }

        public static void AddPsnCommunityRefitClient(IServiceCollection services, IConfiguration configuration)
        {
            var remoteAddress = configuration.GetValue<string>("Psn:CommunityAddress");

            var serializer = new NewtonsoftJsonContentSerializer(
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });

            services.AddRefitClient<IPsnCommunityApi>(new RefitSettings(serializer))
               .ConfigureHttpClient(c => c.BaseAddress = new Uri(remoteAddress));
        }
    }
}