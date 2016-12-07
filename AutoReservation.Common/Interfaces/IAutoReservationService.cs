using AutoReservation.Common.DataTransferObjects;
using System.Collections.Generic;
using System.ServiceModel;

namespace AutoReservation.Common.Interfaces
{
    [ServiceContract] //DataContract ?
    public interface IAutoReservationService
    {
        [OperationContract]
        List<AutoDto> GetAutos();
        [OperationContract]
        AutoDto GetAutoById(int Id);
        [OperationContract]
        AutoDto InsertAuto(AutoDto auto);
        [OperationContract]
        [FaultContract(typeof(AutoDto))]
        AutoDto UpdateAuto(AutoDto auto);
        [OperationContract]
        AutoDto DeleteAuto(AutoDto auto);

        [OperationContract]
        List<KundeDto> GetKunden();
        [OperationContract]
        KundeDto GetKundeById(int Id);
        [OperationContract]
        KundeDto InsertKunde(KundeDto kunde);
        [OperationContract]
        [FaultContract(typeof(KundeDto))]
        KundeDto UpdateKunde(KundeDto kunde);
        [OperationContract]
        KundeDto DeleteKunde(KundeDto kunde);

        [OperationContract]
        List<ReservationDto> GetReservationen();
        [OperationContract]
        ReservationDto GetReservationById(int Id);
        [OperationContract]
        ReservationDto InsertReservation(ReservationDto reservation);
        [OperationContract]
        [FaultContract(typeof(ReservationDto))]
        ReservationDto UpdateReservation(ReservationDto reservation);
        [OperationContract]
        ReservationDto DeleteReservation(ReservationDto reservation);
    }
}
