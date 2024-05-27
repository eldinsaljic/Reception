using System.Collections.Generic;
using System.Threading.Tasks;
using Hotel.Server.Data.Dto.Reservation;
using Hotel.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Server.Controllers;

[Route("api/reservations")]
[ApiController]
public class ReservationController : ControllerBase
{
    private readonly ServiceManager _serviceManager;

    public ReservationController(ServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    [HttpGet]
    public async Task<ActionResult<List<ReservationReadOnlyDto>>> GetReservation()
    {
        var categories = await _serviceManager.ReservationService.GetAllReservations();


        return Ok(categories);
    }

    [HttpGet("{ReservationId}")]
    public async Task<ActionResult<List<ReservationReadOnlyDto>>> GetReservationById(int ReservationId)
    {
        var reservation = await _serviceManager.ReservationService.GetReservationById(ReservationId);


        return Ok(reservation);
    }

    [HttpPost]
    public async Task<IActionResult> CreateReservation(ReservationCreateDto createDto)
    {
        var response = await _serviceManager.ReservationService.CreateReservation(createDto);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateReservation(ReservationUpdateDto updateDto)
    {
        var response = await _serviceManager.ReservationService.UpdateReservation(updateDto.ReservationID, updateDto);
        return Ok(response);
    }

    [HttpDelete("{ReservationId}")] //api/reservation/123
    public async Task<IActionResult> DeleteReservation(int ReservationId)
    {
        var response = await _serviceManager.ReservationService.DeleteReservation(ReservationId);

        if (response)
            return Ok(response);

        return BadRequest();
    }
}