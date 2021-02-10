using ReactionGame.Entety;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactionGame.Blazor.Core.Event
{
    class HighscoreArgs : EventArgs
    {
        public Highscore Highscore { get; set; }
    }
}
