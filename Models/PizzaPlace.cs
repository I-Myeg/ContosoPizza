namespace ContosoPizza.Models;

public class PizzaPlace
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    
    public List<Pizza> Pizzas { get; set; }
}