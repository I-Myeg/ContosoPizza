﻿namespace ContosoPizza.Models;

public class Pizza
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsGlutenFree { get; set; }
    
    public int Cost { get; set; }
    
    public string Size { get; set; }
}