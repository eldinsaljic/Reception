using System.Collections.Generic;
using System.Threading.Tasks;
using Hotel.Server.Data.Dto.Room;
using Hotel.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Server.Controllers;

[Route("api/rooms")]
[ApiController]
public class RoomController : ControllerBase
{
    private readonly ServiceManager _serviceManager;

    public RoomController(ServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    [HttpGet]
    public async Task<ActionResult<List<RoomReadOnlyDto>>> GetRoom()
    {
        var categories = await _serviceManager.RoomService.GetAllCategories();


        return Ok(categories);
    }

    [HttpGet("{RoomId}")]
    public async Task<ActionResult<List<RoomReadOnlyDto>>> GetRoomById(int RoomId)
    {
        var Room = await _serviceManager.RoomService.GetRoomById(RoomId);


        return Ok(Room);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRoom(RoomCreateDto createDto)
    {
        var response = await _serviceManager.RoomService.CreateRoom(createDto);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateRoom(RoomUpdateDto updateDto)
    {
        var response = await _serviceManager.RoomService.UpdateRoom(updateDto.RoomID, updateDto);
        return Ok(response);
    }

    [HttpDelete("{RoomId}")] //api/room/123
    public async Task<IActionResult> DeleteRoom(int RoomId)
    {
        var response = await _serviceManager.RoomService.DeleteRoom(RoomId);

        if (response)
            return Ok(response);

        return BadRequest();
    }
}