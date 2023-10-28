namespace Models
{
    public record ReservedRoom : BaseDomain
    {
        public Guid ReservedRoomId { get; set; }
        public Guid ReservationId { get; set; }

        //Navigation Properties
        public virtual Reservation? Reservation { get; set; }
        public virtual Room? Room { get; set; }
    }
}
