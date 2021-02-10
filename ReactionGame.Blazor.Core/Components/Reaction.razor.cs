using Microsoft.AspNetCore.Components;

using ReactionGame.Blazor.Core.Event;
using ReactionGame.Blazor.Core.Services;
using ReactionGame.Entety;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ReactionGame.Blazor.Core.Components
{
    partial class Reaction
    {
        private string Info { get; set; } = "";
        bool Press { get; set; } = false;
        bool playing { get; set; } = false;
        string GameLable { get; set; } = "play";
        Stopwatch Stopwatch { get; set; } = new Stopwatch();
        [Parameter]
        public string UserName { get; set; } = "";

        [Inject]
        public IHighscoreDataService HighscoreDataService { get; set; }

        private async Task StartGameAsync()
        {
            await InvokeAsync(() =>
            {
                playing = true;
                Info = "StandBy";
                Timer timer = new Timer(new Random().Next(1000, 15000))
                {
                    AutoReset = false
                };
                timer.Elapsed += PressNow;
                timer.Start();
                GameLable = "Waite";
                StateHasChanged();
            });

        }

        private async void PressNow(object sender, ElapsedEventArgs e)
        {
            await InvokeAsync(() =>
            {
                Info = "Press";
                Press = true;
                GameLable = "Press";
                Stopwatch.Start();
                StateHasChanged();
            });

        }

        public async Task PresedAsync()
        {
            await InvokeAsync(async () =>
            {
                Stopwatch.Stop();
                Press = false;
                playing = false;
                GameLable = "Play";

                Info = "Time " + Stopwatch.ElapsedMilliseconds + "ms";
                Highscore highscore = new Highscore(UserName, Stopwatch.ElapsedMilliseconds);
                highscore = await HighscoreDataService.CreateNewHighscore(highscore);
                HighscoreEvent.NewHighscoreMetod(this, highscore);
                Stopwatch.Reset();
                StateHasChanged();
            });
        }
    }
}
