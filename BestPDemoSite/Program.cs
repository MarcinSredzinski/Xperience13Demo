using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace BlankSiteCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //webBuilder.UseSentry(o =>
                    //{
                    //    o.Dsn = "https://315c2f6cafdb4a33a4549a70853ff37b@o4505120176603137.ingest.sentry.io/4505120177848320";
                    //    // When configuring for the first time, to see what the SDK is doing:
                    //    o.Debug = true;
                    //    // Set TracesSampleRate to 1.0 to capture 100% of transactions for performance monitoring.
                    //    // We recommend adjusting this value in production.
                    //    o.TracesSampleRate = 1.0;
                    //});
                    webBuilder.UseStartup<Startup>();
                });
    }
}
