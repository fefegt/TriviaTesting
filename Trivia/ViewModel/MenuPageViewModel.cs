using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Trivia.ViewModel
{
    public partial class MenuPageViewModel : BaseViewModel
    {
        [RelayCommand]
        async Task GameModeSelected() 
        {
            await Shell.Current.GoToAsync($"{nameof(MainPage)}");
        }
    }
}
