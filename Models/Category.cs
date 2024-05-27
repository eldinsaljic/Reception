using System.Collections.Generic;

namespace Hotel.Server.Models;

public class Category
{
    public int CategoryID { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<Room> Products { get; set; } = new();
}