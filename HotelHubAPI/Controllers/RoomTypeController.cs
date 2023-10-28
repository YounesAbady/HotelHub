using APIContract.RoomTypeDTOs;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("room-types/")]
    public class RoomTypeController : ControllerBase
    {
        private readonly IRoomType _roomType;

        public RoomTypeController(IRoomType roomType)
        {
            _roomType = roomType;
        }

        [HttpGet]
        [Route("get-all-room-types-tiny")]
        public async Task<List<RoomTypeTinyDTO>> GetAllTiny()
        {
            return await _roomType.GetAllTinyAsync();
        }
    }
}
