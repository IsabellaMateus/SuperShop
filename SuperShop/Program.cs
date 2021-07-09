using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SuperShop.Data;

namespace SuperShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Constroi o host (para correr em qualquer sistema operativo) mas não corre ainda
            var host = CreateHostBuilder(args).Build();
            RunSeeding(host);
            host.Run(); //No fim corre o host
        }

        private static void RunSeeding(IHost host)
        {
            //Design Pattern 'Factory' em que o próprio objecto antes de existir cria-se a ele próprio

            //variavel utilizada na construção
            var scopeFactory = host.Services.GetService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetService<SeedDb>();
                seeder.SeedAsync().Wait(); //Espera até ser criado
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
