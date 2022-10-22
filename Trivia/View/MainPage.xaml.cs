using CommunityToolkit.Maui.Views;
using Trivia.ViewModel;

namespace Trivia;

public partial class MainPage : ContentPage
{

	public MainPage(TriviaViewModel triviaViewModel)
	{
		InitializeComponent();
		BindingContext = triviaViewModel;
	}

    protected override bool OnBackButtonPressed()
    {
		return false;
    }

}

