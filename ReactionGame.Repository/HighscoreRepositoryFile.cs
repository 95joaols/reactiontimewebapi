﻿using ReactionGame.Entety;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ReactionGame.Repository
{
    public class HighscoreRepositoryFile : IHighscoreRepository
    {
        private readonly string fileLocation;
        private static int nextId = 0;

        public HighscoreRepositoryFile(string fileLocation)
        {
            this.fileLocation = fileLocation;
        }

        public async Task<Highscore> NewHighscores(Highscore NewHighscore)
        {
            if (string.IsNullOrWhiteSpace(NewHighscore?.Name) || NewHighscore?.Time == 0)
            {
                throw new ArgumentException();
            }
            NewHighscore.Id = nextId++;

            try
            {
                IEnumerable<Highscore> highscore = await GetHighscores() ?? new List<Highscore>();

                List<Highscore> highscoreList = highscore.ToList();
                highscoreList.Add(NewHighscore);




                await WriteToFile(highscoreList);
            }
            catch (Exception)
            {
                return null;
            }
            return NewHighscore;
        }
        //public async Task<TReturn> GetT<TReturn,TSingel, T1>(T1 input)
        //   where TSingel : IdEntety
        //{
        //    try
        //    {
        //        string rawHighscore = await File.ReadAllTextAsync(fileLocation);
        //        if (input != null)
        //        {
        //            if (input is int inputint)
        //            {
        //                return (TReturn)JsonSerializer.Deserialize<IEnumerable<TSingel>>(rawHighscore).Where((h) => h.Id == inputint).FirstOrDefault();
        //            }
        //            else
        //            {
        //                return (TReturn)JsonSerializer.Deserialize<IEnumerable<Highscore>>(rawHighscore).Where((h) => h.Name.ToLower() == input.ToString().ToLower());
        //            }
        //        }
        //        return (TReturn)JsonSerializer.Deserialize<TSingel>(rawHighscore);
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}

        public async Task<IEnumerable<Highscore>> GetHighscores()
        {
            try
            {
                string rawHighscore = await File.ReadAllTextAsync(fileLocation);
                IEnumerable<Highscore> highscore = JsonSerializer.Deserialize<IEnumerable<Highscore>>(rawHighscore);
                return highscore;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Highscore>> GetHighscoresByUsername(string username)
        {
            IEnumerable<Highscore> highscore = await GetHighscores();
            return highscore?.Where((h) => h.Name.Contains(username, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<Highscore> GetHighscoresById(int id)
        {
            IEnumerable<Highscore> highscore = await GetHighscores();
            return highscore?.Where((h) => h.Id == id).FirstOrDefault();
        }

        public async Task DeleteHighscoresFromUsername(string username)
        {
            IEnumerable<Highscore> highscore = await GetHighscores();
            highscore = highscore.Where(h => h.Name.ToLower() != username.ToLower());
            await WriteToFile(highscore);
        }
        public async Task DeleteAllHighscores()
        {
            IEnumerable<Highscore> emty = new List<Highscore>();
            await WriteToFile(emty);
        }

        private async Task WriteToFile(IEnumerable<Highscore> highscore)
        {
            string SerializeHighscore = JsonSerializer.Serialize(highscore);
            try
            {
                await File.WriteAllTextAsync(fileLocation, SerializeHighscore);
            }
            catch (Exception)
            {
            }
        }
    }
}
