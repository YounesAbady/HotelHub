using APIContract.ReservationDTOs;
using APIContract.RoomDTOs;
using APIContract.RoomPictureDTO;
using HotelHubMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HotelHubMVC.Controllers
{
    public class ReservationController : Controller
    {
        private IHttpClientFactory _httpClient;
        private ReservationViewModel _reservationViewModel = new();
        public IConfiguration config = new ConfigurationBuilder()
       .AddJsonFile("appsettings.json")
       .AddEnvironmentVariables()
       .Build();
        [TempData]
        public string Msg { get; set; } = string.Empty;
        [TempData]
        public string Status { get; set; } = string.Empty;

        public ReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory;
        }

        [HttpPost]
        public async Task<IActionResult> Index(ReservationSearchDTO reservationSearchDTO)
        {
            var client = _httpClient.CreateClient();
            client.BaseAddress = new Uri(config["BaseAddress"]);
            try
            {
                var request = await client.PostAsJsonAsync("/reservations/get-avaliable-rooms", reservationSearchDTO);
                if (request.IsSuccessStatusCode)
                {
                    if (request.Content != null)
                    {
                        _reservationViewModel.Rooms = await request.Content.ReadFromJsonAsync<List<RoomTinyDTO>>();
                    }
                }
                else
                {
                    Msg = request.ToString();
                    Status = "error";
                    return View();
                }
            }
            catch (Exception ex)
            {
                Msg = ex.Message;
                Status = "error";
                return View();
            }
            try
            {
                var request = await client.PostAsJsonAsync("/room-pictures/get-all-room-pictures", "");
                if (request.IsSuccessStatusCode)
                {
                    if (request.Content != null)
                    {
                        _reservationViewModel.RoomPictures = await request.Content.ReadFromJsonAsync<List<RoomPictureTinyDTO>>();
                        foreach (var room in _reservationViewModel.Rooms)
                        {
                            room.RoomPictures = new();
                            foreach (var picture in _reservationViewModel.RoomPictures)
                            {
                                if (room.Id == picture.RoomId)
                                    room.RoomPictures.Add(picture);
                            }
                        }
                    }
                }
                else
                {
                    Msg = request.ToString();
                    Status = "error";
                    return View();
                }
            }
            catch (Exception ex)
            {
                Msg = ex.Message;
                Status = "error";
                return View();
            }
            return View(_reservationViewModel);
        }
    }
}
