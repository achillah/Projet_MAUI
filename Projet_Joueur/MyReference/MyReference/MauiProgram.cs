﻿using MyReference.View;

namespace MyReference;

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


        builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddSingleton<MainPage>();

        builder.Services.AddTransient<HomeViewModel>();
        builder.Services.AddTransient<HomePage>();

        builder.Services.AddTransient<JoueurViewModel>();
        builder.Services.AddTransient<JoueurPage>();


        builder.Services.AddTransient<DetailViewModel>();
        builder.Services.AddTransient<DetailPage>();

        builder.Services.AddTransient<AjouterJoueurViewModel>();
        builder.Services.AddTransient<AjouterJoueurPage>();

        builder.Services.AddTransient<ModifierJouerViewModel>();
        builder.Services.AddTransient<ModifierJoueurPage>();

        builder.Services.AddTransient<RechercheJoueurViewModel>();
        builder.Services.AddTransient<RechercheJoueurPage>();

        builder.Services.AddTransient<ConnexionViewModel>();
        builder.Services.AddTransient<ConnexionPage>();


        builder.Services.AddTransient<JoueurService>();

        return builder.Build();
	}
}
