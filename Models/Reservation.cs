namespace Models
{
    public record Reservation : BaseDomain
    {
        public Guid BranchId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double TotalPrice { get; set; }

        //Navigation Properties
        public virtual List<ReservedRoom>? ReservedRooms { get; set; } 
        public virtual Branch? Branch { get; set; } 
    }
}
