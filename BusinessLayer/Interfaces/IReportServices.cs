using APIContract.ReportDTOs;

namespace BusinessLayer.Interfaces
{
    public interface IReportServices
    {
        public Task<ReportResultDTO> MakeReport(GetReportDTO getReportDTO);
    }
}
