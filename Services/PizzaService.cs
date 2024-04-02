using ContosoPizza.Database;
using ContosoPizza.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Services;

public class PizzaService
{
    private readonly DatabaseContext _context;

    public PizzaService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<List<Pizza>> GetAll()
    {
        return await _context.Pizzas.ToListAsync();
    }

    public async Task<Pizza> Get(int id)
    {
        return await _context.Pizzas.FindAsync(id);
    }

    public async Task Delete(int id)
    {
        var pizza = await _context.Pizzas.FindAsync(id);
        if (pizza != null)
        {
            _context.Pizzas.Remove(pizza);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Update(Pizza pizza)
    {
        var existingPizza = await _context.Pizzas.FindAsync(pizza.Id);
        if (existingPizza != null)
        {
            existingPizza.Name = pizza.Name;
            await _context.SaveChangesAsync();
        }
    }
    // static List<Pizza> Pizzas { get; }
    // static int nextId = 3;
    // static PizzaService()
    // {
    //     Pizzas = new List<Pizza>
    //     {
    //         new Pizza { Id = 1, Name = "Classic Italian", IsGlutenFree = false },
    //         new Pizza { Id = 2, Name = "Veggie", IsGlutenFree = true }
    //     };
    // }
    //
    // public static List<Pizza> GetAll()
    // {
    //     return Pizzas;
    // }
    //
    // public static Pizza? Get(int id)
    // {
    //     return Pizzas.FirstOrDefault(p => p.Id == id);
    // }
    //
    // public static void Add(Pizza pizza)
    // {
    //     pizza.Id = nextId++;
    //     Pizzas.Add(pizza);
    // }
    //
    // public static void Delete(int id)
    // {
    //     var pizza = Get(id);
    //     if(pizza is null)
    //         return;
    //
    //     Pizzas.Remove(pizza);
    // }
    //
    // public static void Update(Pizza pizza)
    // {
    //     var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
    //     if(index == -1)
    //         return;
    //
    //     Pizzas[index] = pizza;
    // }
}