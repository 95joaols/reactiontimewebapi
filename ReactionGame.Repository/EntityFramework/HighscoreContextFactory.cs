using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ReactionGame.Repository.EntityFramework
{
    class HighscoreContextFactory : IDesignTimeDbContextFactory<HighscoreDbContext>
    {
        public HighscoreDbContext CreateDbContext(string[] args)
        {

            var dbContextBuilder = new DbContextOptionsBuilder();

            dbContextBuilder.UseSqlite("Data Source=ReactionGameDb.db");

            return new HighscoreDbContext(dbContextBuilder.Options);
        }
    }
}
