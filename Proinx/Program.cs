using System;
using Microsoft.Extensions.DependencyInjection;
using Proinx.Services;

namespace Proinx
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceProvider serviceProvider = RegisterServices();
            IServiceScope serviceScope = serviceProvider.CreateScope();
            ProjectStarter projectStarter = serviceScope.ServiceProvider.GetRequiredService<ProjectStarter>();
            projectStarter.Start();
        }

        private static IServiceProvider RegisterServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<IProductsMerger, ProductsMerger>();
            services.AddSingleton<ProjectStarter>();
            return services.BuildServiceProvider();
        }
    }
}
