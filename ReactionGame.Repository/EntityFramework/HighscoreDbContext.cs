using Microsoft.EntityFrameworkCore;

using ReactionGame.Entety;

using System;
using System.Collections.Generic;
using System.Text;

namespace ReactionGame.Repository.EntityFramework
{
    class HighscoreDbContext : DbContext
    {
        public DbSet<Highscore> Highscores { get;  set; }
        public HighscoreDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
