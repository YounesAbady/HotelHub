namespace APIContract.ReservationDTOs
{
    public record ReservationSearchDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Adults { get; set; }
        public int Childrens { get; set; }
        public Guid BranchId { get; set; }
    }
}
