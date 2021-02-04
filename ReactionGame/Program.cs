using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace ReactionGame
{
    class Program
    {
        static List<Highscore> highscores = new List<Highscore>();

        static void Main(string[] args)
        {
            Random random = new Random();

            while (true)
            {
                Console.Clear();
                Stopwatch stopwatch = new Stopwatch();

                Console.WriteLine("Tryck valfri tangent för att starta spelet!");
                Console.ReadKey(true);
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
                    Console.ReadKey(true);
                }
                else
                {
                    Console.WriteLine("Tryck NU!!");
                    stopwatch.Start();
                    Console.ReadKey(true);
                    stopwatch.Stop();

                    Console.WriteLine("Det tog: " + stopwatch.ElapsedMilliseconds + " millisekunder!");

                    if (CheckNewHighscore(stopwatch.ElapsedMilliseconds))
                    {
                        RegisterNewHighscore(stopwatch.ElapsedMilliseconds);
                    }

                    Console.WriteLine("\nHIGHSCORE:");
                    for (int i = highscores.Count; i > 0; i--)
                    {
                        Console.WriteLine(highscores[i - 1]);
                    }
                }

                Console.WriteLine("\nTryck på valfri tangent för att börja om, eller Q för att avsluta.");
                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Q) Environment.Exit(0);
            }
        }

        private static bool CheckNewHighscore(long elapsedMilliseconds)
        {
            if (highscores.Count == 0) return true;
            foreach (Highscore score in highscores)
            {
                if (elapsedMilliseconds < score.Time)
                {
                    return true;
                }
            }
            return false;
        }

        static void RegisterNewHighscore(long time)
        {
            Console.WriteLine("\nNytt rekord!");
            Console.Write("Skriv ditt namn: ");
            string newName = Console.ReadLine();
            Highscore highscore = new Highscore
            {
                Name = newName,
                Time = time
            };
            highscores.Add(highscore);
        }
    }
}