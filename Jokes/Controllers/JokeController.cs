using Jokes.Models;
using Jokes.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace Jokes.Controllers
{
    [ApiController]
    [Route("/")]
    public class JokeController : ControllerBase
    {
        JokeService _jokeService;

        [HttpGet("GetKey")]
        public IActionResult GetKey()
        {
            return Ok("2af3542e-9ac1-443b-8dfa-1a76af9ed04d");
        }

        [HttpGet("GetCategories")]
        public IActionResult GetCategories()
        {
            List<string> categories = _jokeService.GetCategories();
            return Ok(categories);
        }

        [HttpPost("GetAJoke")]
        public IActionResult GetAJoke([FromBody] string category)
        {
            List<Joke> usedJokes = HttpContext.Session.GetObjectFromJson<List<Joke>>("UsedJokes") ?? new List<Joke>();
            if (category == "Dad" || category == "Chuck Norris")
            {
                if (Request.Headers.TryGetValue("Accept-Language", out StringValues acceptLanguages))
                {
                    string[] languages = acceptLanguages[0].Split(',');
                    Joke jokeToUse = _jokeService.GetAJoke(usedJokes, category, languages);
                    usedJokes.Add(jokeToUse);
                    HttpContext.Session.SetObjectAsJson("UsedJokes", usedJokes);
                    return Ok(jokeToUse.Text);
                }
                else
                    return BadRequest("No langange set in the browser");
            }
            else if (category == "Inappropriate")
            {
                return Unauthorized("Please use the InappropriateJokes endpoint to access these jokes and make sure you use the API key");
            }
            else
            {
                return BadRequest("Please enter a correct category");
            }
        }

        [ApiKeyAuthorization("2af3542e-9ac1-443b-8dfa-1a76af9ed04d")]
        [HttpGet("InappropriateJokes")]
        public IActionResult InappropriateJokes()
        {
            List<Joke> usedJokes = HttpContext.Session.GetObjectFromJson<List<Joke>>("UsedJokes") ?? new List<Joke>();
            if (Request.Headers.TryGetValue("Accept-Language", out StringValues acceptLanguages))
            {
                string[] languages = acceptLanguages[0].Split(',');
                Joke jokeToUse = _jokeService.GetAJoke(usedJokes, "Inappropriate", languages);
                usedJokes.Add(jokeToUse);
                HttpContext.Session.SetObjectAsJson("UsedJokes", usedJokes);
                return Ok(jokeToUse.Text);
            }
            else
                return BadRequest("No langange set in the browser");
        }

        public JokeController(JokeService jokeService)
        {
            _jokeService = jokeService;
        }
    }
}