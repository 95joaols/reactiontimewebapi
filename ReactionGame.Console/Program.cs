using ReactionGame.Entety;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace ReactionGame
{
    internal class Program
    {
        private const string RequestUri = "https://localhost:5001/Highscores";

        //private static readonly List<Highscore> highscores = new List<Highscore>();

        private static readonly HttpClientHandler clientHandler = new HttpClientHandler { ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; } };
        private static readonly HttpClient client = new HttpClient(clientHandler);

        private static async Task Main(string[] args)
        {
            Random random = new Random();

            while (true)
            {
                Console.Clear();
                Stopwatch stopwatch = new Stopwatch();

                Console.WriteLine("Tryck valfri tangent för att starta spelet!");
                _ = Console.ReadKey(true);
                Console.WriteLine("Vänta lite...");

                float waitTime = random.Next(500, 3000);
                while (Console.KeyAvailable != true && waitTime > 0)
                {
                    Thread.Sleep(10);
                    waitTime -= 10;
                }

                if (waitTime > 0)
                {
                    Console.WriteLine("Tjuvstart! Prova igen.");
                    _ = Console.ReadKey(true);
                }
                else
                {
                    Console.WriteLine("Tryck NU!!");
                    stopwatch.Start();
                    _ = Console.ReadKey(true);
                    stopwatch.Stop();

                    Console.WriteLine("Det tog: " + stopwatch.ElapsedMilliseconds + " millisekunder!");

                    if (await CheckNewHighscoreAsync(stopwatch.ElapsedMilliseconds))
                    {
                        await RegisterNewHighscoreAsync(stopwatch.ElapsedMilliseconds);
                    }

                    Console.WriteLine("\nHIGHSCORE:");

                    IEnumerable<Highscore> highscores = await client.GetFromJsonAsync<IEnumerable<Highscore>>(RequestUri);
                    foreach (Highscore highscore in highscores.OrderBy(h => h.Time))
                    {
                        Console.WriteLine(highscore);
                    }
                }

                Console.WriteLine("\nTryck på valfri tangent för att börja om, eller Q för att avsluta.");
                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Q)
                {
                    Environment.Exit(0);
                }
            }
        }

        private static async Task<bool> CheckNewHighscoreAsync(long elapsedMilliseconds)
        {
            IEnumerable<Highscore> highscores = null;
            try
            {
            highscores = await client.GetFromJsonAsync<IEnumerable<Highscore>>(RequestUri);

            }
            catch (Exception)
            {

            }
            if (!highscores?.Any() ?? true)
            {
                return true;
            }

            foreach (Highscore score in highscores)
            {
                if (elapsedMilliseconds < score.Time)
                {
                    return true;
                }
            }
            return false;
        }

        private static async Task RegisterNewHighscoreAsync(long time)
        {
            Console.WriteLine("\nNytt rekord!");
            Console.Write("Skriv ditt namn: ");
            string newName = Console.ReadLine();
            Highscore highscore = new Highscore(newName, time);
            HttpResponseMessage response = null;
            try
            {
                response = await client.PostAsJsonAsync(RequestUri, highscore);

            }
            catch (Exception)
            {
            }
            if (response?.IsSuccessStatusCode ?? false)
            {
            }
            else
            {
                //error
            }
        }
    }
}