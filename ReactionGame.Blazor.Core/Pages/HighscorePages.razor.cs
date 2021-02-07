using ReactionGame.Blazor.Core.Services;
using ReactionGame.Entety;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactionGame.Blazor.Core.Pages
{
    partial class HighscorePages
    {
        IEnumerable<Highscore> Highscores { get; set; }
        IHighscoreDataService highscoreDataService;

        protected override async Task OnInitializedAsync()
        {
            Highscores = await highscoreDataService.GetHighscore<IEnumerable<Highscore>, string>("");
        }
    }
}
