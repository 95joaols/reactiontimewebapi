using Microsoft.AspNetCore.Mvc;

using ReactionGame.Entety;
using ReactionGame.Repository;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactionGame.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HighscoresController : ControllerBase
    {
        private readonly IHighscoreRepository Repository;

        public HighscoresController(IHighscoreRepository repository)
        {
            Repository = repository;
        }

        [HttpGet] //Highscores
        public async Task<ActionResult<IEnumerable<Highscore>>> GetHighscoresAsync()
        {
            IEnumerable<Highscore> highscores = await Repository.GetHighscores();
            if (highscores == null || !highscores.Any())
            {
                return NoContent();
            }
            else
            {
                return Ok(highscores);
            }
        }

        [HttpPost] //Highscores
        public async Task<ActionResult<Highscore>> NewHighscoresAsync(Highscore NewHighscore)
        {
            if (NewHighscore == null)
            {
                return BadRequest();
            }
            Highscore highscore = await Repository.NewHighscores(NewHighscore);
            if (highscore == null)
            {
                return NoContent();
            }
            try
            {
                return CreatedAtAction(nameof(GetHighscoresByIdAsync), new { highscore.Id }, highscore);

            }
            catch (System.Exception)
            {

                throw;
            }
        }
        //[HttpGet("{id}")] //Highscores/id
        //[ActionName(nameof(GetHighscoresByIdAsync))]
        //public async Task<ActionResult<Highscore>> GetHighscoresByObjectAsync(string id)
        //{
        //    if (id == null)
        //    {
        //        return BadRequest();
        //    }
        //    if (int.TryParse(id, out int intId))
        //    {
        //    }

        //    Highscore highscore = await Repository.GetHighscoresById(id);
        //    if (highscore == null)
        //    {
        //        return NoContent();
        //    }
        //    return Ok(highscore);
        //}

        [HttpGet("{id:int}")] //Highscores/id
        [ActionName(nameof(GetHighscoresByIdAsync))]
        public async Task<ActionResult<Highscore>> GetHighscoresByIdAsync(int id)
        {
            Highscore highscore = await Repository.GetHighscoresById(id);
            if (highscore == null)
            {
                return NoContent();
            }
            return Ok(highscore);
        }

        [HttpGet("{username}")] //Highscores/username
        public async Task<ActionResult<IEnumerable<Highscore>>> GetHighscoresByUsernameAsync(string username)
        {
            IEnumerable<Highscore> highscores = await Repository.GetHighscoresByUsername(username);
            if (highscores == null || !highscores.Any())
            {
                return NoContent();
            }
            return Ok(highscores);
        }

        [HttpDelete] //Highscores
        public async Task<ActionResult> DeleteAllHighscoresAsync()
        {
            await Repository.DeleteAllHighscores();
            return Ok();
        }

        [HttpDelete("{username}")] //Highscores/usernames
        public async Task<ActionResult> DeleteHighscoresFromUsernameAsync(string username)
        {
            await Repository.DeleteHighscoresFromUsername(username);
            return Ok();
        }
    }
}
