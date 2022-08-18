using Serilog;
using Serilog.Events;

namespace Obra.API
{

    public static class SerilogStartupExtension
    {
        public static void AddSerilogApi(WebApplicationBuilder builder)
        {
            string shortdate = DateTime.Now.ToString("yyyy-MM-dd_HH");
            string path = builder.Configuration.GetSection("LoggerBasePath").Value;
            string fileName = $@"{path}\{shortdate}.log";
            string template = builder.Configuration.GetSection("LoggerFileTemplate").Value;

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .Enrich.WithProperty("ApplicationName", $"API Serilog - {Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")}")
                .Filter.ByExcluding(z => z.MessageTemplate.Text.Contains("Business error"))
                .WriteTo.Console()
                .WriteTo.File(fileName, outputTemplate: template)
                .CreateLogger();

            builder.Host.UseSerilog(Log.Logger);
        }
    }
}
