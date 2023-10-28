using APIContract.ReportDTOs;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("reports")]
    public class ReportController : ControllerBase
    {
        private readonly IReportServices _reportServices;

        public ReportController(IReportServices reportServices)
        {
            _reportServices = reportServices;
        }

        [HttpPost]
        [Route("get-report")]
        public async Task<ReportResultDTO> Index([FromBody] GetReportDTO getReportDTO)
        {
            return await _reportServices.MakeReport(getReportDTO);
        }
    }
}
