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
        public Movie PickedMovie;
        private int _roundTime = 10;

        public ObservableCollection<Movie> Movies { get; } =  new();

        [ObservableProperty]
        public Movie winnerMovie = new();

        [ObservableProperty]
        private int remainingTime = 10;

        MovieService movieService; 

        public TriviaViewModel(MovieService movieService)
        {
            Title = "Trivia Game";
            this.movieService = movieService;
            StartGame();
        }

        [RelayCommand]
        private async Task PickAnswer(Movie movie)
        {
            if (PickedMovie is null)
            {
                PickedMovie = movie;
                movie.State = MovieState.Selected;
            }
            //_ = Shell.Current.DisplayAlert("test", "test", "ok");
        }

        [RelayCommand]
        private async Task GetMovies()
        {
            try
            {
                IsBusy = true;
                //StartGame();
                var movies = await movieService.GetRandomMovies(_qtyMovies);

                

                Movies.Clear();
                

                foreach(Movie movie in movies)
                {
                    Movies.Add(movie);
                }
                WinnerMovie = Movies[Random.Shared.Next(0, _qtyMovies)];
                Console.WriteLine($"Winner movie: {WinnerMovie.Title}");
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
            PickedMovie = null;
            await GetMovies();
            remainingTime = _roundTime;

            while(_isRunning)// && remainingTime !=0)
            {
                _time.Add(TimeSpan.FromSeconds(1));
                RemainingTime -= 1;
                await Task.Delay(TimeSpan.FromSeconds(1));

                if(RemainingTime == 0) 
                {
                    _isRunning = false;

                    Movies.Single(o => o == WinnerMovie).State = MovieState.Winner;

                    if (WinnerMovie == PickedMovie)
                    {
                        
                        await Shell.Current.DisplayAlert("Respuesta Correcta", "Preparese para la siguiente ronda", "Ok");
                    }
                    else if(WinnerMovie != PickedMovie && PickedMovie is not null)
                    {
                        Movies.Single(o => o == PickedMovie).State = MovieState.SelectedLoss;
                        await Shell.Current.DisplayAlert("Respuesta Incorrecta", "Buena suerte en la siguiente ronda", "Ok");
                    }
                    else
                    {
                        await Shell.Current.DisplayAlert("Tiempo agotado", "Elija la respuesta mas rapido la proxima vez", "Ok");
                    }
                }
            }

            ResetRound();
            await StartGame();

            //remainingTime = 10;
        }

        private void ResetRound()
        {
            foreach (Movie movie in Movies)
                movie.RestoreState();
        }
    }
}
