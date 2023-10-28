using APIContract.RoomPictureDTO;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("/room-pictures")]
    public class RoomPictureController : Controller
    {
        private readonly IRoomPictureServices _roomPictureServices;

        public RoomPictureController(IRoomPictureServices roomPictureServices)
        {
            _roomPictureServices = roomPictureServices;
        }

        [HttpPost]
        [Route("get-all-room-pictures")]
        public async Task<List<RoomPictureTinyDTO>> GetAll()
        {
            return await _roomPictureServices.GetAllRoomPictures();
        }
    }
}
