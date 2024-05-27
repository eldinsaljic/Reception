using System.Collections.Generic;
using System.Threading.Tasks;
using Hotel.Server.Contracts.Service;
using Hotel.Server.Data.Dto;
using Hotel.Server.Data.Dto.Reservation;
using Hotel.Server.Models;
using Hotel.Server.Repository.Contracts;
using Mapster;

namespace Hotel.Server.Services;

public class ReservationService : IReservationService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly ResponseDto _response;

    public ReservationService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
        _response = new ResponseDto();
    }

    public async Task<ResponseDto> CreateReservation(ReservationCreateDto ReservationDto)
    {
        var Reservation = ReservationDto.Adapt<Reservation>();
        _repositoryManager.ReservationRepository.CreateReservation(Reservation);
        var result = await _repositoryManager.UnitOfWork.SaveChangesAsync();
        if (result > 0) return _response;
        _response.Success = false;
        _response.DisplayMessage = "Error Creating Reservation";
        return _response;
    }

    public async Task<ResponseDto> UpdateReservation(int ReservationId, ReservationUpdateDto ReservationDto)
    {
        var ReservationCheck = await _repositoryManager.ReservationRepository.GetReservationById(ReservationId);
        if (ReservationCheck is null)
        {
            _response.Success = false;
            _response.DisplayMessage = "Reservation not found in Database";
            return _response;
        }

        var Reservation = ReservationDto.Adapt<Reservation>();
        _repositoryManager.ReservationRepository.Update(Reservation);

        var result = await _repositoryManager.UnitOfWork.SaveChangesAsync();
        if (result > 0) return _response;
        _response.Success = false;
        _response.DisplayMessage = "Error Updating Reservation";
        return _response;
    }

    public async Task<bool> DeleteReservation(int ReservationID)
    {
        var Reservation = await _repositoryManager.ReservationRepository.GetReservationById(ReservationID);
        if (Reservation is null) return false;
        _repositoryManager.ReservationRepository.DeleteReservation(Reservation);
        return await _repositoryManager.UnitOfWork.SaveChangesAsync() == 1;
    }

    public async Task<IEnumerable<ReservationReadOnlyDto>> GetAllReservations()
    {
        var categories = await _repositoryManager.ReservationRepository.GetAllCategories();
        return categories.Adapt<IEnumerable<ReservationReadOnlyDto>>();
    }

    public async Task<ReservationReadOnlyDto> GetReservationById(int id)
    {
        var Reservation = await _repositoryManager.ReservationRepository.GetReservationById(id);
        return Reservation.Adapt<ReservationReadOnlyDto>();
    }
}