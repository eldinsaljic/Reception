namespace Hotel.Server.Models;

public class Room
{
    public int ID { get; set; }
    public Category Category { get; set; }
    public int CategoryID { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
}