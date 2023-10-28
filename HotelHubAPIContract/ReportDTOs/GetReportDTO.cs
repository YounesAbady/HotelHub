namespace APIContract.ReportDTOs
{
    public record GetReportDTO
    {
        public Guid BranchId { get; set; }
        public string Time { get; set; } = string.Empty;
    }
}
