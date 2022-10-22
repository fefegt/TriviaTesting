using Trivia.ViewModel;

namespace Trivia;

public partial class MenuPage : ContentPage
{
	public MenuPage(TriviaViewModel triviaViewModel)
	{
		InitializeComponent();
		BindingContext = triviaViewModel;
	}
}