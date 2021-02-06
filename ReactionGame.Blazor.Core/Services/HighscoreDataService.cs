using ReactionGame.Entety;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ReactionGame.Blazor.Core.Services
{
    public class HighscoreDataService : IHighscoreDataService
    {
        private readonly HttpClient _httpClient;

        public Task<Highscore> CreateNewHighscore()
        {
            throw new NotImplementedException();
        }

        public Task DeleteAllHighscore()
        {
            throw new NotImplementedException();
        }

        public Task DeleteAllHighscoreByUsername()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Highscore>> GetAllHighscore()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Highscore>> GetAllHighscoreByUsername()
        {
            throw new NotImplementedException();
        }

        public Task<Highscore> GetHighscoreById()
        {
            throw new NotImplementedException();
        }
    }
}
