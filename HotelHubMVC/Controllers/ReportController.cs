using APIContract.BranchDTOs;
using APIContract.LoginDTOs;
using APIContract.ReportDTOs;
using APIContract.RoomDTOs;
using HotelHubMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace HotelHubMVC.Controllers
{
    public class ReportController : Controller
    {
        private IHttpClientFactory _httpClient;
        private ReportViewModel _reportViewModel = new();
        public IConfiguration config = new ConfigurationBuilder()
       .AddJsonFile("appsettings.json")
       .AddEnvironmentVariables()
       .Build();

        [TempData]
        public string Msg { get; set; } = string.Empty;
        [TempData]
        public string Status { get; set; } = string.Empty;

        public ReportController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory;
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginSendDTO loginDTO)
        {
            var client = _httpClient.CreateClient();
            client.BaseAddress = new Uri(config["BaseAddress"]);
            try
            {
                var request = await client.PostAsJsonAsync("/admins/login", loginDTO);
                if (request.IsSuccessStatusCode)
                {
                    if (request.Content != null)
                    {
                        if (await request.Content.ReadFromJsonAsync<int>() == 1)
                        {
                            Msg = "Successfully logged in!";
                            Status = "success";
                            HttpContext.Session.SetString("loggedUser", loginDTO.Username);
                            HttpContext.Session.SetString("loggedPassword", loginDTO.Password);
                        }
                        else
                        {
                            Msg = "Invalid Login Data";
                            Status = "error";
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        Msg = "Invalid Login Data";
                        Status = "error";
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    Msg = "Invalid Login Data";
                    Status = "error";
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                Msg = ex.Message;
                Status = "error";
                return RedirectToAction("Index", "Home");
            }
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
                        _reportViewModel.Branches = JsonSerializer.Deserialize<List<BranchTinyDto>>(request, options);
                    }
                    else
                    {
                        Msg = request.ToString();
                        Status = "error";
                        return RedirectToAction("Index", "Home");
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
            return View(_reportViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> GetReport(GetReportDTO getReportDTO)
        {
            var client = _httpClient.CreateClient();
            client.BaseAddress = new Uri(config["BaseAddress"]);
            try
            {
                var request = await client.PostAsJsonAsync("/reports/get-report", getReportDTO);
                if (request.IsSuccessStatusCode)
                {
                    if (request.Content != null)
                    {
                        _reportViewModel.ReportResultDTO = await request.Content.ReadFromJsonAsync<ReportResultDTO>();
                    }
                    else
                    {
                        Status = "error";
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    Status = "error";
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                Msg = ex.Message;
                Status = "error";
                return RedirectToAction("Index", "Home");
            }
            return View(_reportViewModel.ReportResultDTO);
        }
    }
}
