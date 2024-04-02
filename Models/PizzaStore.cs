using ContosoPizza.Database;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Models;

public class PizzaStore
{
    private readonly DatabaseContext _context;

    public PizzaStore(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<List<Pizza>> GetAll()
    {
        return await _context.Pizzas.ToListAsync();
    }

    public async Task Add(Pizza pizza)
    {
        await _context.Pizzas.AddAsync(pizza);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Pizza pizza)
    {
        var entity = await _context.Pizzas.SingleOrDefaultAsync(p => p.Id == pizza.Id);
        entity.Name = pizza.Name;

        _context.Pizzas.Update(entity);
        await _context.SaveChangesAsync();
    }
}