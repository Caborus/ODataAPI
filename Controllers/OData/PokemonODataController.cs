using ODataAPI.EntityModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Formatter;

namespace ODataAPI.Controllers.odata;
public class PokemonsController : ODataController
{
    private readonly PokemonDbContext _dbContext;

    public PokemonsController(PokemonDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [EnableQuery]
    public ActionResult Get()
    {
        return Ok(_dbContext.Pokemons);
    }

    [EnableQuery]
    public async Task<ActionResult> Get( [FromODataUri] int key)
    {
        var entity = await _dbContext.Pokemons.FirstAsync(x => x.Id == key);

        if (entity == null)
        {
            return NotFound();
        }

        return Ok(entity);
    }

    [EnableQuery]
    public async Task<ActionResult> Patch( [FromODataUri] int key, [FromBody] Delta<Pokemon> model)
    {


        var entity = await _dbContext.Pokemons.FindAsync(key);
        if (entity == null)
        {
            return NotFound();
        }

        model.Patch(entity);

        await _dbContext.SaveChangesAsync();

        return Updated(entity);
    }


    [EnableQuery]
    public async Task<ActionResult> Post([FromBody] Pokemon model)
    {


        _dbContext.Pokemons.Add(model);
        await _dbContext.SaveChangesAsync();

        return Created(model);
    }

    [EnableQuery]
    public async Task<ActionResult> Put( [FromODataUri] int key, [FromBody] Pokemon update)
    {
        if (key != update.Id)
        {
            return BadRequest();
        }

        _dbContext.Entry(update).State = EntityState.Modified;

        await _dbContext.SaveChangesAsync();

        return Updated(update);
    }


    [EnableQuery]
    public async Task<ActionResult> Delete( [FromODataUri] int key)
    {
        var entity = await _dbContext.Pokemons.FindAsync(key);
        if (entity == null)
        {
            return NotFound();
        }

        _dbContext.Pokemons.Remove(entity);
        await _dbContext.SaveChangesAsync();

        return Ok();
    }
}