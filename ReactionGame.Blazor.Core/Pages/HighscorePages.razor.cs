using Microsoft.AspNetCore.Components;

using ReactionGame.Blazor.Core.Event;
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
        private string sheach = "";

        IEnumerable<Highscore> Highscores { get; set; } = new List<Highscore>();

        string Sheach { get => sheach; set { sheach = value; ChangeHighscores(); } }
        [Inject]
        public IHighscoreDataService HighscoreDataService { get; set; }
        [Parameter]
        public bool CombresedAndLocal { get; set; } = false;

        protected override async Task OnInitializedAsync()
        {
            if (!CombresedAndLocal)
            {
                Highscores = await HighscoreDataService.GetHighscore<IEnumerable<Highscore>, string>("");
                Highscores = Highscores.OrderBy(h => h.Time);
            }
            else
            {
                HighscoreEvent.NewHighscore += gotNewHighscoreAsync;
            }
        }

        private async Task ChangeHighscores()
        {
            if (int.TryParse(Sheach, out int id))
            {
                List<Highscore> Highscoreslists = new List<Highscore>();
                Highscoreslists.Add(await HighscoreDataService.GetHighscore<Highscore, string>(id.ToString()));
                Highscores = Highscoreslists;
            }
            else
            {
                Highscores = await HighscoreDataService.GetHighscore<IEnumerable<Highscore>, string>(Sheach.Replace("\'", ""));
                Highscores = Highscores.OrderBy(h => h.Time);
            }
            StateHasChanged();
        }

        private async void gotNewHighscoreAsync(object sender, HighscoreArgs e)
        {
            List<Highscore> tempList = Highscores.ToList();
            
            await InvokeAsync(async () =>
            {
                tempList.Add(e.Highscore);
                Highscores = tempList.OrderBy(h => h.Time);
                StateHasChanged();
            });
        }
    }
}
