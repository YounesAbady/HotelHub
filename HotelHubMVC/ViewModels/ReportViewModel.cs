using APIContract.BranchDTOs;
using APIContract.ReportDTOs;

namespace HotelHubMVC.ViewModels
{
    public record ReportViewModel
    {
        public List<BranchTinyDto> Branches { get; set; } = new();
        public GetReportDTO GetReportDTO { get; set; } = new();
        public ReportResultDTO ReportResultDTO { get; set; } = new();
    }
}
