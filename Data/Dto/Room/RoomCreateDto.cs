using System.ComponentModel.DataAnnotations;

namespace Hotel.Server.Data.Dto.Room;

public class RoomCreateDto
{
    [Required] [StringLength(50)] public string Name { get; set; }

    [Required] [StringLength(250)] public string Description { get; set; }
}