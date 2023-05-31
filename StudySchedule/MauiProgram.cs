using CommunityToolkit.Maui;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using Microsoft.Extensions.Logging;
using SqliteClassLibrary;

namespace StudySchedule;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
		builder.Services.AddDbContext<StudyContext>(options => options.UseSqlite($"Filename={GetDatabasePath()}",
			x => x.MigrationsAssembly(nameof(SqliteClassLibrary))));
#endif

		return builder.Build();
	}
	public static string GetDatabasePath()
	{
		var databasePath = "";
		var databaseName = "StudyDb.db3";
		if(DeviceInfo.Platform== DevicePlatform.Android)
		{
			databasePath=Path.Combine(FileSystem.AppDataDirectory, databaseName);

		}
		if(DeviceInfo.Platform== DevicePlatform.iOS)
		{
            SQLitePCL.Batteries_V2.Init();
            databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", databaseName);
        }
        // add other platforms if needed
		// adicione outras plataformas se necessario para obter o path combine
        
        return databasePath;
	}
}
