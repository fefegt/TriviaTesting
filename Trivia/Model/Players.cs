using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia.ViewModel;

namespace Trivia.Model
{
    public class Player : ObservableObject
    {
        private int lifesLeft;
        public int Lifesleft { get => lifesLeft; set => SetProperty(ref lifesLeft, value); }

        private int points;
        public int Points { get => points; set => SetProperty(ref points, value); }

        public Player(int lifesleft, int points)
        {
            Lifesleft = lifesleft;
            Points = points;
        }
    }
}
