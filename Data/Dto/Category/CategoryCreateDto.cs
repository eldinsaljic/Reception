using System.ComponentModel.DataAnnotations;

namespace Hotel.Server.Data.Dto.Category;

public class CategoryCreateDto
{
    [Required] [StringLength(50)] public string Name { get; set; }

    [Required] [StringLength(250)] public string Description { get; set; }
}