using System;
using System.Collections.Generic;
using System.Text;

namespace ReactionGame.Entety
{
   public class IdEntety
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IdEntety(string name)
        {
            Name = name;
        }
    }
}
