using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.Model;

namespace Trivia.Services
{
    public class MovieService
    {
        private List<Movie> Movies = new();

        public MovieService()
        {
            PopulateMovies();
        }

        public async Task<List<Movie>> GetRandomMovies(int qtyMovies)
        {
            var tempMovies = new List<Movie>();
            var i = 0;
            while(i < qtyMovies)
            {
                var randomNumber = Random.Shared.Next(0, Movies.Count);
                if(!tempMovies.Any(x => x.Id == Movies[randomNumber].Id))
                {
                    tempMovies.Add(Movies[randomNumber]);
                    i++;
                }
                
            }
            await Task.Delay(500);
            return tempMovies;
        }

        private void PopulateMovies()
        {
            Movies.Add(new Movie { Id = 1, Title = "The GodFather" });
            Movies.Add(new Movie { Id = 2, Title = "The Dark Knight" });
            Movies.Add(new Movie { Id = 3, Title = "The Godfather Part II" });
            Movies.Add(new Movie { Id = 4, Title = "12 Angry Men" });
            Movies.Add(new Movie { Id = 5, Title = "Schindler's List" });
            Movies.Add(new Movie { Id = 6, Title = "The Lord of the Rings: The Return of the King" });
            Movies.Add(new Movie { Id = 7, Title = "Pulp Fiction" });
            Movies.Add(new Movie { Id = 8, Title = "The Good, the Bad and the Ugly" });
            Movies.Add(new Movie { Id = 9, Title = "Forrest Gump" });
            Movies.Add(new Movie { Id = 10, Title = "Fight Club" });
        }
    }
}
