// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using ODataAPI.EntityModels;


// namespace ODataAPI.Controllers
// {
//     [ApiController]
//     [Route("Pokemon")]
//     public class PokemonController : ControllerBase
//     {
//         private PokemonDbContext _context;
//         public PokemonController(PokemonDbContext context){ 
//             _context = context;
//         }

//         [HttpGet("")]
//         public ActionResult<List<Pokemon>> GetAllPokemon(){
//             return Ok(_context.Pokemons);
//         }
//     }
// }