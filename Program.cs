using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;

namespace TheWorkFlow
{
    public class Program
    {
        //public static void Main(string[] args)
        //{
        //    CreatehHostBuilder(args).Build().Run();
        //}

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
       // public static IWebHost CreateBuildWebHost(string[] args) => WebHost.CreateDefaultBuilder(args).UseStartup<Startup>().Build();
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();   
            });


    }
}
