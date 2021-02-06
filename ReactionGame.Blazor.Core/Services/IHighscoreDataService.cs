using ReactionGame.Entety;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactionGame.Blazor.Core.Services
{
    public interface IHighscoreDataService
    {
        Task<Highscore> CreateNewHighscore();
        Task<IEnumerable<Highscore>> GetAllHighscore();
        Task<Highscore> GetHighscoreById();
        Task<IEnumerable<Highscore>> GetAllHighscoreByUsername();
        Task DeleteAllHighscoreByUsername();
        Task DeleteAllHighscore();
    }
}
