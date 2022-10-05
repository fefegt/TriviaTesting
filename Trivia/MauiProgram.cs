using Trivia.Services;
using Trivia.ViewModel;


namespace Trivia;

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

		builder.Services.AddSingleton<MovieService>();

		builder.Services.AddSingleton<TriviaViewModel>();

		builder.Services.AddSingleton<MainPage>();



        return builder.Build();
	}
}
