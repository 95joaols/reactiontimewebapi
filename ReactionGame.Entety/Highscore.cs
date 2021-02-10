using System;
using System.ComponentModel.DataAnnotations;

namespace ReactionGame.Entety
{
    public class Highscore
    {
        public Highscore(string name, long time)
        {
            Name = name;
            Time = time;
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(0, double.MaxValue)]
        public long Time { get; set; }
    }
}