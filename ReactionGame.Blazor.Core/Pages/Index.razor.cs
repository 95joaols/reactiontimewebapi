using Microsoft.AspNetCore.Components.Web;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactionGame.Blazor.Core.Pages
{
    partial class Index
    {
        string userName { get; set; } = "";
        bool Ready { get; set; } = false;

        private void PlayerReady()
        {
            if(!string.IsNullOrWhiteSpace(userName))
            {
                Ready = true;
                StateHasChanged();
            }
        }
        
    }
}
