using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using Trivia.Model;
using Trivia.Services;
using Debug = System.Diagnostics.Debug;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Trivia.ViewModel
{
    public partial class TriviaViewModel : BaseViewModel
    {
        private int _qtyMovies = 4;
        private TimeOnly _time = new();
        private bool _isRunning = false;

        public ObservableCollection<Movie> Movies { get; } =  new();
        public Movie WinnerMovie = new();

        [ObservableProperty]
        private int remainingTime = 10;

        MovieService movieService; 

        public TriviaViewModel(MovieService movieService)
        {
            Title = "Trivia Game";
            this.movieService = movieService;
        }

        [RelayCommand]
        private async Task PickAnswer(Movie movie)
        {
            //_ = Shell.Current.DisplayAlert("test", "test", "ok");
        }

        [RelayCommand]
        private async Task GetMovies()
        {
            try
            {
                IsBusy = true;
                StartGame();
                var movies = await movieService.GetRandomMovies(_qtyMovies);

                Movies.Clear();
                

                foreach(Movie movie in movies)
                {
                    Movies.Add(movie);
                }
                WinnerMovie = Movies[Random.Shared.Next(0, _qtyMovies)];
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error", $"Error obtaining the list of movies: {ex.Message}", "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task StartGame()
        {
            _isRunning = !_isRunning;
            while(_isRunning && remainingTime !=0)
            {
                _time.Add(TimeSpan.FromSeconds(1));
                RemainingTime -= 1;
                await Task.Delay(TimeSpan.FromSeconds(1));

                if(RemainingTime == 0) 
                {
                    Shell.Current.DisplayAlert("ROUND HAS ENDED!!", "You ran out of time", "OK");
                }
            }
        }
    }
}
