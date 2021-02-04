using ReactionGame.Entety;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReactionGame.Repository
{
    public interface IHighscoreRepository
    {
        Task<Highscore> NewHighscores(Highscore NewHighscore);

        Task<IEnumerable<Highscore>> GetHighscores();
        Task<Highscore> GetHighscoresById(int id);
        Task<IEnumerable<Highscore>> GetHighscoresByUsername(string username);

        Task DeleteAllHighscores();
        Task DeleteHighscoresFromUsername(string username);
    }
}
