using CommunityToolkit.Maui;
using Trivia.Services;
using Trivia.View;
using Trivia.ViewModel;


namespace Trivia;

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
				fonts.AddFont("Font Awesome 6 Free-Regular-400.otf", "fa-regular");
			});

		builder.Services.AddSingleton<MovieService>();

		builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<TriviaViewModel>();

        builder.Services.AddSingleton<GameEndedPage>();
		builder.Services.AddTransient<LoadingScreenPage>();

		builder.Services.AddSingleton<MenuPage>();
		builder.Services.AddSingleton<MenuPageViewModel>();

        return builder.Build();
	}
}
