using ReactionGame.Entety;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactionGame.Blazor.Core.Event
{
    static class HighscoreEvent
    {
        public static event EventHandler<HighscoreArgs> NewHighscore;

        public static void NewHighscoreMetod(object o, Highscore h)
        {
            NewHighscore?.Invoke(o, new HighscoreArgs { Highscore = h });
        }
    }
}
