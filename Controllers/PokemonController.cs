using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")] // api/pokemon
[ApiController]
public class PokemonController : ControllerBase {
    // class properties
    private readonly demoRestContext _context;
    // constructor
    public PokemonController(demoRestContext context){
        _context = context;
    }

    // REST 
    [HttpGet("all")] // ENDPOINT: api/pokemon/all
    public IEnumerable<Pokemon> getAllPokemons(){
        var pokemons = _context.Pokemon.ToList();
        return pokemons; 
    }  

    
    [HttpGet("avinash")] // api/pokemon/avinash
    public String sayHiToAvinash(){
        return "Hi Avinash!";
    }

    [HttpGet("{id}")]
    public Pokemon getPokemon(long id){
        var pokemon = _context.Pokemon.Find(id);
        return pokemon;
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Pokemon))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult editPokemon(long id, Pokemon pokemon ){
        
        try {
            _context.Entry(pokemon).State = EntityState.Modified;
            _context.SaveChanges();
        } catch {
            if(_context.Pokemon.Find(id) == null) {
                return NotFound();
            }
        }        
        return Ok(pokemon);
    }

    [HttpPost]
    public Pokemon createPokemon(Pokemon pokemon){
        _context.Pokemon.Add(pokemon);
        _context.SaveChanges();
        return pokemon;
    }

    [HttpDelete("{id}")]
    public String deletePokemon(long id){
        var pokemon = _context.Pokemon.Find(id); 

        // long trainerId = pokemon.trainerId; 
        // var trainer = _context.Trainer.Find(trainerId);
        //  {
        //     "id": 700,
        //     "name": "RocketPokemon",
        //     "gender": "B",
        //     "category": "Electric",
        //     "evolved": true,
        //     "ability": "Overgrow"
        //     "trainerId: 1, // -> Trainer with ID 1
        // }

        _context.Pokemon.Remove(pokemon);
        _context.SaveChanges();
        return "Succesfully deleted!";
    }


}