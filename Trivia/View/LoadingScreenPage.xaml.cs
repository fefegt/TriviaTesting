using Microsoft.Maui.Controls;

namespace Trivia.View;

public partial class LoadingScreenPage : ContentView
{
	public LoadingScreenPage()
	{
		InitializeComponent();
	}

    ProgressBar progressBar = new ProgressBar { Progress = 0.5 };
	Image image = new Image
    {
        Source = ImageSource.FromFile("splashscreen.svg")
    };


    private async void ProgressBar_PropertyChanging(object sender, PropertyChangingEventArgs e)
	{
        await progressBar.ProgressTo(0.95, 1000, Easing.Linear);
    }

	private async void Image_PropertyChanging(object sender, PropertyChangingEventArgs e)
	{
        await image.RotateTo(360, 900);
        image.Rotation = 0;
    }
}