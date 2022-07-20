using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class GreetingsController : ControllerBase {

    public string[] Greetings {get;} 
    
    public GreetingsController(){
        Greetings = new string[]{"Gotta Catch'em All!", "Bulbasaur", "Charmander", "Squirtle"};
    }

    [HttpGet]
    public IEnumerable<String> GetAllGreetings(){
        return Greetings;
    }


    [HttpGet("{index}")]
    public String GetGreeting(long index){
        String greeting;
        try { 
            greeting = Greetings[index]; 
        } catch {
            return "try again!";
        };
       return greeting;
    }
}
