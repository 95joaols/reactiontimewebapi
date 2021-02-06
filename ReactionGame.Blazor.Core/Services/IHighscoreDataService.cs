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
        Task<Highscore> CreateNewHighscore(Highscore highscore);
        Task<T> GetHighscore<T, T1>(T1? input) where T : Highscore where T1 : struct;
        //Task<IEnumerable<Highscore>> GetAllHighscore();
        //Task<Highscore> GetHighscoreById(int id);
        //Task<IEnumerable<Highscore>> GetAllHighscoreByUsername(string usename);
        Task DeleteAllHighscoreByUsername(string usename);
        Task DeleteAllHighscore();
    }
}
