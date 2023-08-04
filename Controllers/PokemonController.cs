using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Sharpi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        private static List<Pokemon> PokemonObjectList = new List<Pokemon>();


        [HttpPost]
        [Route("/Pokemon/add", Name = "AddPokemon")]
        public ActionResult Post([FromBody] Pokemon pokemon)
        {
            if (pokemon == null)
            {
                return BadRequest("Pokemon not found");
            }

            if (PokemonObjectList.Any(p => p.Id == pokemon.Id))
            {
                return Conflict("A Pokemon with this ID already exists.");
            }

            PokemonObjectList.Add(pokemon);

            return CreatedAtAction(nameof(GetPokemonById), new { id = pokemon.Id }, pokemon);
        }

        [HttpPost]
        [Route("/Pokemon/{id}/update", Name = "UpdatePokemon")]
        public IActionResult UpdatePokemon([FromBody] Pokemon updatedPokemon, int id)
        {
            var pokemon = PokemonObjectList.FirstOrDefault(p => p.Id == id);


            if (pokemon == null)
            {
                return NotFound("Pokemon not found");
            }

            //GetPokemons(PokemonObjectList, id, pokemon);
            

            return NoContent();
        }

        [HttpGet]
        [Route("/Pokemon/{id}", Name = "GetPokemonById")]
        public ActionResult<Pokemon> GetPokemonById(int id)
        {
            var pokemon = PokemonObjectList.FirstOrDefault(p => p.Id == id);

            if (pokemon == null)
            {
                return NotFound("Pokemon not found");
            }

            return pokemon;
        }

        [HttpGet]
        [Route("/Pokemon/list", Name = "GetPokemonList")]
        public IEnumerable<Pokemon> Get()
        {
            return PokemonObjectList;
        }

        [HttpDelete]
        [Route("/Pokemon/{id}/delete", Name = "DeletePokemon")]
        public IActionResult DeletePokemon(int id)
        {
            var pokemon = PokemonObjectList.FirstOrDefault(p => p.Id == id);

            if (pokemon == null)
            {
                return NotFound("Pokemon not found");
            }

            PokemonObjectList.Remove(pokemon);

            return NoContent();
        }


    }
}
