namespace Hotel.Server.Models;

public class Reservation
{
    public int ID { get; set; }
    public Room Room { get; set; }
    public int RoomID { get; set; }
    public decimal Price { get; set; }
    public string Name { get; set; }
}