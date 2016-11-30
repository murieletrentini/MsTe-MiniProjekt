using AutoReservation.Common.DataTransferObjects;
using System.Collections.Generic;

namespace AutoReservation.Common.Interfaces
{
    public interface IAutoReservationService
    {
        IList<AutoDto> GetAutos();
        AutoDto GetAutoById(int Id);
        void InsertAuto(AutoDto auto);
        void UpdateAuto(AutoDto auto);
        void DeleteAuto(AutoDto auto);

        IList<KundeDto> GetKunden();
        KundeDto GetKundeById(int Id);
        void InsertKunde(KundeDto kunde);
        void UpdateKunde(KundeDto kunde);
        void DeleteKunde(KundeDto kunde);

        IList<ReservationDto> GetReservationen();
        ReservationDto GetReservationById(int Id);
        void InsertReservation(ReservationDto reservation);
        void UpdateReservation(ReservationDto reservation);
        void DeleteReservation(ReservationDto reservation);
    }
}
