using System.Collections.Generic;

namespace Hotel.Server.Data.Dto;

public class ResponseDto
{
    public object Data { get; set; }
    public bool Success { get; set; } = true;
    public string DisplayMessage { get; set; }
    public List<string> ErrorMessages { get; set; }
}