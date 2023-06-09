﻿using CommunityToolkit.Maui;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using Microsoft.Extensions.Logging;
using StudySchedule.Data;
using StudySchedule.Services;

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
						
        string dbPath = FileAccessDb.GetLocalFilePath("StudyDb.db3");
        builder.Services.AddSingleton<ServiceMateria>(s => ActivatorUtilities.CreateInstance<ServiceMateria>(s, dbPath));
		builder.Services.AddSingleton<ServiceAgenda>(s=> ActivatorUtilities.CreateInstance<ServiceAgenda>(s, dbPath));


        return builder.Build();
	}	
}
