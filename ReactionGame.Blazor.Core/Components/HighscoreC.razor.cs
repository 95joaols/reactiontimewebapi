using Microsoft.AspNetCore.Components;

using ReactionGame.Entety;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactionGame.Blazor.Core.Components
{
    partial class HighscoreC
    {
        [Parameter]
        public int Pos { get; set; }
        [Parameter]
        public Highscore Highscore { get; set; }
    }
}
