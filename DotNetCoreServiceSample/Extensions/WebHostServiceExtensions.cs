using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.WindowsServices;
using System;
using System.ServiceProcess;

namespace DotNetCoreServiceSample.Extensions
{
    public static class WebHostServiceExtensions
    {
        /// <summary>
        /// IWebHostの拡張メソッド
        /// </summary>
        public static void RunAsCustomService(this IWebHost host)
        {
            var webHostService = new CustomWebHostService(host);
            ServiceBase.Run(webHostService);
        }
    }

    public class CustomWebHostService : WebHostService
    {
        public CustomWebHostService(IWebHost host) : base(host) { }

        protected override void OnStarting(string[] args)
        {
            Console.WriteLine("OnStarting method called.");
            base.OnStarting(args);
        }

        protected override void OnStarted()
        {
            Console.WriteLine("OnStarted method called.");
            base.OnStarted();
        }

        protected override void OnStopping()
        {
            Console.WriteLine("OnStopping method called.");
            base.OnStopping();
        }
    }
}
