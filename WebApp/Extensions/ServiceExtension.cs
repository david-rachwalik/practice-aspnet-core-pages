using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Services;

namespace WebApp.Extensions
{
    public static class ServiceExtension
    {
        // https://github.com/AzureAD/microsoft-authentication-library-for-dotnet/wiki/scenarios
        public static void AddCustomAuthenticationConfiguration(this IServiceCollection services, IConfiguration config)
        {
            //services.AddAuthentication(AzureADDefaults.AuthenticationScheme)
            //    .AddAzureAD(options => config.Bind("AzureAd", options));
        }

        public static void AddDataServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
        }
    }
}
