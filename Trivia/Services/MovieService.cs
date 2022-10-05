using J3QQ4;
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
            Movies.Add(new Movie { Id = 1, Title = "The GodFather" , Emoji = Emoji.Older_Man + Emoji.Gun + Emoji.Wine_Glass});
            Movies.Add(new Movie { Id = 2, Title = "The Dark Knight" , Emoji = Emoji.Man + Emoji.Fist + Emoji.Night_With_Stars});
            Movies.Add(new Movie { Id = 3, Title = "The Godfather Part II" , Emoji = Emoji.Gun + Emoji.Knife + Emoji.Horse + Emoji.Older_Man + Emoji.Two});
            Movies.Add(new Movie { Id = 4, Title = "12 Angry Men" , Emoji = Emoji.One + Emoji.Two + Emoji.Angry + Emoji.Mens});
            Movies.Add(new Movie { Id = 5, Title = "Schindler's List" , Emoji = Emoji.Girl + Emoji.Gun});
            Movies.Add(new Movie { Id = 6, Title = "The Lord of the Rings: The Return of the King" , Emoji = Emoji.Older_Man + Emoji.Boy + Emoji.Ring + Emoji.Volcano});
            Movies.Add(new Movie { Id = 7, Title = "Pulp Fiction" , Emoji = Emoji.Man + Emoji.Man + Emoji.Hamburger + Emoji.Video_Camera + Emoji.File_Folder});
            Movies.Add(new Movie { Id = 8, Title = "The Good, the Bad and the Ugly" , Emoji = Emoji.Man + Emoji.Vs + Emoji.Man + Emoji.Vs + Emoji.Man});
            Movies.Add(new Movie { Id = 9, Title = "Forrest Gump" , Emoji = Emoji.Runner + Emoji.Athletic_Shoe + Emoji.Man + Emoji.Wheelchair + Emoji.Sailboat + Emoji.Fried_Shrimp});
            Movies.Add(new Movie { Id = 10, Title = "Fight Club" , Emoji = Emoji.Man + Emoji.Vs + Emoji.Man + Emoji.Hushed + Emoji.Clubs });
        }
    }
}
