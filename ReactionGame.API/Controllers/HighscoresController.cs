using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using ReactionGame.Entety;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactionGame.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HighscoresController : ControllerBase
    {
        [HttpGet] //Highscores
        public ActionResult<IEnumerable<Highscore>> GetHighscores()
        {
            return NoContent();
        }

        [HttpPost] //Highscores
        public ActionResult<Highscore> NewHighscores(Highscore NewHighscore)
        {
            if (NewHighscore is null)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpGet("{id}")] //Highscores/id
        public ActionResult<Highscore> GetHighscoresById(int id)
        {
            return NoContent();
        }

        [HttpGet("{username}")] //Highscores/username
        public ActionResult<Highscore> GetHighscoresByUsername(string username)
        {
            return NoContent();
        }

        [HttpDelete] //Highscores
        public ActionResult DeleteAllHighscores()
        {
            return NoContent();
        }

        [HttpDelete("{username}")] //Highscores/usernames
        public ActionResult DeleteHighscoresFromUsername(string username)
        {
            return NoContent();
        }
    }
}
