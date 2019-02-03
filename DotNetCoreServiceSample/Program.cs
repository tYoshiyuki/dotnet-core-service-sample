using DotNetCoreServiceSample.Extensions;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace DotNetCoreServiceSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var isService = !(Debugger.IsAttached || args.Contains("--console"));
            
            var pathToContentRoot = Directory.GetCurrentDirectory();
            if (isService)
            {
                // サービス実行時のルートディレクトリの指定を変更する
                var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
                pathToContentRoot = Path.GetDirectoryName(pathToExe);
            }

            var host = WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                // 起動ポートを変更する場合に指定する
                //.UseUrls("http://*:8080/")
                .UseContentRoot(pathToContentRoot)
                .UseStartup<Startup>()
                .Build();

            // サービスかどうかで起動方法を分ける
            if (isService)
            {
                host.RunAsCustomService();
            }
            else
            {
                host.Run();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
