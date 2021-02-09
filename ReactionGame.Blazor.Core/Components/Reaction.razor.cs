using Microsoft.AspNetCore.Components;

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

        private void StartGame()
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

        }

        private void PressNow(object sender, ElapsedEventArgs e)
        {
            Info = "Press";
            Press = true;
            GameLable = "Press";
            Stopwatch.Start();
            StateHasChanged();
        }

        public void presed()
        {
            Stopwatch.Stop();
            Press = false;
            playing = false;
            GameLable = "Play";

            Info = "Time " + Stopwatch.ElapsedMilliseconds +"ms";
            HighscoreDataService.CreateNewHighscore(new Highscore(UserName, Stopwatch.ElapsedMilliseconds));
            Stopwatch.Reset();
            StateHasChanged();
        }
    }
}
