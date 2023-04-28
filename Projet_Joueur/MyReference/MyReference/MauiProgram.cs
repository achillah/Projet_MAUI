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

        builder.Services.AddTransient<JoueurViewModel>();
        builder.Services.AddTransient<JoueurPage>();


        builder.Services.AddTransient<DetailViewModel>();
        builder.Services.AddTransient<DetailPage>();

        builder.Services.AddTransient<AjouterJoueurViewModel>();
        builder.Services.AddTransient<AjouterJoueur>();

        builder.Services.AddTransient<ModifierJouerViewModel>();
        builder.Services.AddTransient<ModifierJoueur>();

        builder.Services.AddTransient<RechercheViewModel>();
        builder.Services.AddTransient<RechercheJoueur>();


        builder.Services.AddTransient<JoueurService>();

        return builder.Build();
	}
}
