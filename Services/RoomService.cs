using System.Collections.Generic;
using System.Threading.Tasks;
using Hotel.Server.Contracts.Service;
using Hotel.Server.Data.Dto;
using Hotel.Server.Data.Dto.Room;
using Hotel.Server.Models;
using Hotel.Server.Repository.Contracts;
using Mapster;

namespace Hotel.Server.Services;

public class RoomService : IRoomService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly ResponseDto _response;

    public RoomService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
        _response = new ResponseDto();
    }

    public async Task<ResponseDto> CreateRoom(RoomCreateDto RoomDto)
    {
        var Room = RoomDto.Adapt<Room>();
        _repositoryManager.RoomRepository.CreateRoom(Room);
        var result = await _repositoryManager.UnitOfWork.SaveChangesAsync();
        if (result > 0) return _response;
        _response.Success = false;
        _response.DisplayMessage = "Error Creating Room";
        return _response;
    }

    public async Task<ResponseDto> UpdateRoom(int RoomId, RoomUpdateDto RoomDto)
    {
        var RoomCheck = await _repositoryManager.RoomRepository.GetRoomById(RoomId);
        if (RoomCheck is null)
        {
            _response.Success = false;
            _response.DisplayMessage = "Room not found in Database";
            return _response;
        }

        var Room = RoomDto.Adapt<Room>();
        _repositoryManager.RoomRepository.Update(Room);

        var result = await _repositoryManager.UnitOfWork.SaveChangesAsync();
        if (result > 0) return _response;
        _response.Success = false;
        _response.DisplayMessage = "Error Updating Room";
        return _response;
    }

    public async Task<bool> DeleteRoom(int RoomID)
    {
        var Room = await _repositoryManager.RoomRepository.GetRoomById(RoomID);
        if (Room is null) return false;
        _repositoryManager.RoomRepository.DeleteRoom(Room);
        return await _repositoryManager.UnitOfWork.SaveChangesAsync() == 1;
    }

    public async Task<IEnumerable<RoomReadOnlyDto>> GetAllCategories()
    {
        var categories = await _repositoryManager.RoomRepository.GetAllCategories();
        return categories.Adapt<IEnumerable<RoomReadOnlyDto>>();
    }

    public async Task<RoomReadOnlyDto> GetRoomById(int id)
    {
        var Room = await _repositoryManager.RoomRepository.GetRoomById(id);
        return Room.Adapt<RoomReadOnlyDto>();
    }
}