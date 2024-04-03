using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{

    private readonly PizzaStore _pizzaStore;
    public PizzaController(PizzaStore pizzaStore)
    {
        _pizzaStore = pizzaStore;
    }

    [HttpGet]
    public async Task<ActionResult<List<Pizza>>> GetAll()
    {
        return await _pizzaStore.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Pizza>> Get(int id)
    {
        var pizza = await _pizzaStore.Get(id);

        if(pizza == null)
            return NotFound();

        return pizza;
    }

    [HttpPost]
    public async Task<IActionResult> Create(Pizza pizza)
    {            
        await _pizzaStore.Add(pizza);
        return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Pizza pizza)
    {
        if (id != pizza.Id)
            return BadRequest();
           
        var existingPizza = await _pizzaStore.Get(id);
        if(existingPizza is null)
            return NotFound();
   
        await _pizzaStore.Update(pizza);           
   
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var pizza = await _pizzaStore.Get(id);
   
        if (pizza is null)
            return NotFound();
       
        await _pizzaStore.Delete(id);
   
        return NoContent();
    }
}