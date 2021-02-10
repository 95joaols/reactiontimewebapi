using ReactionGame.Entety;
using ReactionGame.Repository.EntityFramework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactionGame.Repository
{
    public class HighscoreRepositorySqllite : IHighscoreRepository
    {
        private HighscoreDbContext highscoreDbContext;

        public HighscoreRepositorySqllite()
        {
            HighscoreContextFactory highscoreContextFactory = new HighscoreContextFactory();
            highscoreDbContext = highscoreContextFactory.CreateDbContext(null);
        }

        public async Task DeleteAllHighscores()
        {
            highscoreDbContext.Highscores.RemoveRange(highscoreDbContext.Highscores.ToArray());
            await highscoreDbContext.SaveChangesAsync();
        }

        public async Task DeleteHighscoresFromUsername(string username)
        {
            highscoreDbContext.Highscores.RemoveRange(highscoreDbContext.Highscores.Where(h => h.Name.ToLower() == username.ToLower()));
            await highscoreDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Highscore>> GetHighscores()
        {
            List<Highscore> temp = new List<Highscore>();
            await Task.Run(() =>
             {
                 temp = highscoreDbContext.Highscores.ToList();
             });
            return temp;
        }

        public async Task<Highscore> GetHighscoresById(int id)
        {
            return await highscoreDbContext.Highscores.FindAsync(id);
        }

        public async Task<IEnumerable<Highscore>> GetHighscoresByUsername(string username)
        {
            List<Highscore> temp = new List<Highscore>();
            await Task.Run(() =>
            {
                temp = highscoreDbContext.Highscores.Where(h => h.Name.Contains(username, StringComparison.OrdinalIgnoreCase)).ToList();
            });
            return temp;
        }

        public async Task<Highscore> NewHighscores(Highscore NewHighscore)
        {
            await highscoreDbContext.Highscores.AddAsync(NewHighscore);
            await highscoreDbContext.SaveChangesAsync();
            return NewHighscore;
        }
    }
}
