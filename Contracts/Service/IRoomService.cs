using System.Collections.Generic;
using System.Threading.Tasks;
using Hotel.Server.Data.Dto;
using Hotel.Server.Data.Dto.Room;

namespace Hotel.Server.Contracts.Service;

public interface IRoomService
{
    Task<IEnumerable<RoomReadOnlyDto>> GetAllCategories();
    Task<RoomReadOnlyDto> GetRoomById(int id);
    Task<ResponseDto> CreateRoom(RoomCreateDto RoomDto);
    Task<ResponseDto> UpdateRoom(int RoomId, RoomUpdateDto RoomDto);
    Task<bool> DeleteRoom(int RoomID);
}