using APIContract.ReportDTOs;
using APIContract.ReservationDTOs;
using AutoMapper;
using BusinessLayer.Interfaces;
using DataAccessLayer.Interfaces;

namespace BusinessLayer.Implementations
{
    public class ReportServices : IReportServices
    {
        private readonly IReservation _reservationServices;
        private readonly IRoom _roomServices;

        public ReportServices(IReservation reservation, IRoom room)
        {
            _reservationServices = reservation;
            _roomServices = room;
        }

        public async Task<ReportResultDTO> MakeReport(GetReportDTO getReportDTO)
        {
            ReportResultDTO reportResultDTO = new();
            reportResultDTO.AllRooms = await _roomServices.GetAllWithIncludeAsync(getReportDTO.BranchId, 0, 0);
            ReservationSearchDTO reservationSearchDTO = new ReservationSearchDTO
            {
                Adults = 0,
                BranchId = getReportDTO.BranchId,
                Childrens = 0,
                StartDate = DateTime.Now
            };
            if (getReportDTO.Time == "Daily")
                reservationSearchDTO.EndDate = DateTime.Now.AddDays(1);
            else if (getReportDTO.Time == "Weekly")
                reservationSearchDTO.EndDate = DateTime.Now.AddDays(7);
            else
                reservationSearchDTO.EndDate = DateTime.Now.AddDays(30);

            reportResultDTO.AvaliableRooms = await _reservationServices.GetAllAvaliableRoomsAsync(reservationSearchDTO);
            return reportResultDTO;
        }
    }
}
