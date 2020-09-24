using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;

namespace MedicalTelegrammBot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Medical Telegram Bot v1.0");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;

            CreateWebHostBuilder(args).Build().Run();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Designed by Roman Onofreichuk 2020");
            Console.ResetColor();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}