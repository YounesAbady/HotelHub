using APIContract.BranchDTOs;
using APIContract.ReservationDTOs;
using APIContract.RoomTypeDTOs;
using HotelHubMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace HotelHubMVC.Controllers
{
    public class HomeController : Controller
    {
        private IHttpClientFactory _httpClient;
        private HomeViewModel _homeViewModel = new();
        public IConfiguration config = new ConfigurationBuilder()
       .AddJsonFile("appsettings.json")
       .AddEnvironmentVariables()
       .Build();
        [TempData]
        public string Msg { get; set; } = string.Empty;
        [TempData]
        public string Status { get; set; } = string.Empty;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClient.CreateClient();
            client.BaseAddress = new Uri(config["BaseAddress"]);
            try // To Get All Branches
            {
                var request = await client.GetStringAsync("/branches/get-all-branches-tiny");
                if (request is not null)
                {
                    if (request.Length > 0)
                    {
                        var options = new JsonSerializerOptions
                        {
                            WriteIndented = true,
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                            DictionaryKeyPolicy = JsonNamingPolicy.CamelCase
                        };
                        _homeViewModel.Branches = JsonSerializer.Deserialize<List<BranchTinyDto>>(request, options);
                    }
                    else
                        return View();
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
            try // To Get All RoomTypes
            {
                var request = await client.GetStringAsync("/room-types/get-all-room-types-tiny");
                if (request is not null)
                {
                    if (request.Length > 0)
                    {
                        var options = new JsonSerializerOptions
                        {
                            WriteIndented = true,
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                            DictionaryKeyPolicy = JsonNamingPolicy.CamelCase
                        };
                        _homeViewModel.RoomTypes = JsonSerializer.Deserialize<List<RoomTypeTinyDTO>>(request, options);
                    }
                    else
                        return View();
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
            Status = "success";
            return View(_homeViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            Msg = "Logged out successfully";
            Status = "success";
            return RedirectToAction("Index", "Home");
        }
    }
}