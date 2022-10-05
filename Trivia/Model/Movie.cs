using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia.Model
{
    public class Movie : ObservableObject
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Emoji{ get; set; }

        public MovieState state = MovieState.None;
        public MovieState State { get => state; set => SetProperty(ref state, value); }

        public void RestoreState() => State = MovieState.None;
        //private bool isSelected = false;
        //public bool IsSelected { get => isSelected; set => SetProperty(ref isSelected, value); }

        //private bool isWinner = false;
        //public bool IsWinner { get => isSelected; set => SetProperty(ref isWinner, value); }
    }

    public enum MovieState
    {
        None = 0,
        Selected = 1,
        Winner = 2,
        SelectedLoss = 3
    }
    //public class Cast
    //{
    //    public int id { get; set; }
    //    public string name { get; set; }
    //}

    //public class Director
    //{
    //    public int id { get; set; }
    //    public string name { get; set; }
    //}

    //public class ExternalIds
    //{
    //    public string imdb_id { get; set; }
    //    public string facebook_id { get; set; }
    //    public string instagram_id { get; set; }
    //    public string twitter_id { get; set; }
    //}

    //public class Root
    //{
    //    public int budget { get; set; }
    //    public List<string> genres { get; set; }
    //    public string homepage { get; set; }
    //    public int id { get; set; }
    //    public string original_language { get; set; }
    //    public string overview { get; set; }
    //    public double popularity { get; set; }
    //    public string poster_path { get; set; }
    //    public string release_date { get; set; }
    //    public int revenue { get; set; }
    //    public int runtime { get; set; }
    //    public string tagline { get; set; }
    //    public string title { get; set; }
    //    public double vote_average { get; set; }
    //    public int vote_count { get; set; }
    //    public ExternalIds external_ids { get; set; }
    //    public List<Similar> similar { get; set; }
    //    public string certification { get; set; }
    //    public List<Director> directors { get; set; }
    //    public List<Writer> writers { get; set; }
    //    public List<Cast> cast { get; set; }
    //    public string trailer_yt { get; set; }
    //}

    //public class Similar
    //{
    //    public int id { get; set; }
    //    public string title { get; set; }
    //}

    //public class Writer
    //{
    //    public int id { get; set; }
    //    public string name { get; set; }
    //}
}
