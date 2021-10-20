using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using Serilog;
using Sentry;

namespace Recipe_Saver
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var configuration = new ConfigurationBuilder()
					.AddJsonFile("appsettings.json")
					.Build();

			Log.Logger = new LoggerConfiguration()
					.ReadFrom.Configuration(configuration)
					.CreateLogger();
			string version = configuration.GetSection("Version")["Major"] + "." + configuration.GetSection("Version")["Minor"] + "." + configuration.GetSection("Version")["Revision"];
			using (SentrySdk.Init(o =>
            {
                o.Release = "recipe-saver@" + version;
                o.Dsn = "https://11e5611b6d1b4e40b158608be2a0ca78@o1044877.ingest.sentry.io/6020699";
                // When configuring for the first time, to see what the SDK is doing:
                o.Debug = true;
                // Set traces_sample_rate to 1.0 to capture 100% of transactions for performance monitoring.
                // We recommend adjusting this value in production.
                o.TracesSampleRate = 1.0;
            }))
			{
				// App code goes here. Dispose the SDK before exiting to flush events.

				try
				{
					SentrySdk.CaptureMessage("Appliation Starting Up");
					CreateHostBuilder(args).Build().Run();
				}
				catch (Exception ex)
				{
					SentrySdk.CaptureException(ex);
				}
				finally
				{
					Log.CloseAndFlush();
				}
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
