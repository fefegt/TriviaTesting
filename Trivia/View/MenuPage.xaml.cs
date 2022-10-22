using Trivia.ViewModel;

namespace Trivia;

public partial class MenuPage : ContentPage
{
	public MenuPage(MenuPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}