using System.Net;
using applestore.OpenSSL.Command;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace applestore.WebApp {
    public class Program {
        public static Certifications _ssl;
        public Program(Certifications ssl) {
            _ssl = ssl;
        }

        public static void Main(string[] args) {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => {
                    // webBuilder.UseKestrel(options => {
                    //     options.Listen(IPAddress.Loopback, 5001);
                    //     options.Listen(IPAddress.Loopback, 5002, listenOptions => {
                    //         listenOptions.UseHttps(_ssl.LOCALHOST_PFX, _ssl.TEST_PASSWORD);
                    //     });
                    // }).UseStartup<Startup>();
                    webBuilder.UseStartup<Startup>();
                });
    }
}
