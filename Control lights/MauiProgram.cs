using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations.Schema;
using Npgsql;
using Control_lights.DbContext;

namespace Control_lights
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            var config = builder.Configuration;

            var db = new SupaDbContext(config);
            string a = db.Test();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
