using AutoReservation.Common.DataTransferObjects;
using System.Collections.Generic;
using System.ServiceModel;

namespace AutoReservation.Common.Interfaces
{
    [ServiceContract] //DataContract ?
    public interface IAutoReservationService
    {
        [OperationContract]
        IList<AutoDto> GetAutos();
        [OperationContract]
        AutoDto GetAutoById(int Id);
        [OperationContract]
        void InsertAuto(AutoDto auto);
        [OperationContract]
        [FaultContract(typeof(LocalOptimisticConcourrencyException))]
        void UpdateAuto(AutoDto auto);
        [OperationContract]
        void DeleteAuto(AutoDto auto);

        [OperationContract]
        IList<KundeDto> GetKunden();
        [OperationContract]
        KundeDto GetKundeById(int Id);
        [OperationContract]
        void InsertKunde(KundeDto kunde);
        [OperationContract]
        [FaultContract(typeof(LocalOptimisticConcourrencyException))]
        void UpdateKunde(KundeDto kunde);
        [OperationContract]
        void DeleteKunde(KundeDto kunde);

        [OperationContract]
        IList<ReservationDto> GetReservationen();
        [OperationContract]
        ReservationDto GetReservationById(int Id);
        [OperationContract]
        void InsertReservation(ReservationDto reservation);
        [OperationContract]
        [FaultContract(typeof(LocalOptimisticConcourrencyException))]
        void UpdateReservation(ReservationDto reservation);
        [OperationContract]
        void DeleteReservation(ReservationDto reservation);
    }
}
