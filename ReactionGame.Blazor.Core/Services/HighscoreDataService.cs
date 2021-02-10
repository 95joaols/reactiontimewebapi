using ReactionGame.Entety;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ReactionGame.Blazor.Core.Services
{
    public class HighscoreDataService : IHighscoreDataService
    {
        private readonly HttpClient _httpClient;

        public HighscoreDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Highscore> CreateNewHighscore(Highscore highscore)
        {
            HttpResponseMessage response = null;
            try
            {
                response = await _httpClient.PostAsJsonAsync($"", highscore);

            }
            catch (Exception)
            {
            }
            if (response?.StatusCode == HttpStatusCode.Created)
            {
                try
                {
                    return await response.Content.ReadFromJsonAsync<Highscore>();
                }
                catch (Exception)
                {
                }
            }
            return null;
        }

        public async Task<T> GetHighscore<T, T1>(T1 input)
            where T : class
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<T>(input.ToString());

            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task DeleteAllHighscore()
        {
            try
            {
                await _httpClient.DeleteAsync("");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteAllHighscoreByUsername(string usename)
        {
            if (string.IsNullOrWhiteSpace(usename))
            {
                throw new ArgumentException($"'{nameof(usename)}' cannot be null or whitespace", nameof(usename));
            }
            try
            {
                await _httpClient.DeleteAsync("/" + usename);
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
