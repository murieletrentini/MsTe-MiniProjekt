using AutoReservation.Common.Interfaces;
using System;
using System.Diagnostics;
using AutoReservation.Common.DataTransferObjects;
using System.Collections.Generic;
using AutoReservation.Dal;
using AutoReservation.Dal.Entities;
using AutoReservation.BusinessLayer;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace AutoReservation.Service.Wcf {
    
    public class AutoReservationService : IAutoReservationService {
        AutoReservationBusinessComponent bc = new AutoReservationBusinessComponent();
        
        private static void WriteActualMethod() {
            Console.WriteLine($"Calling: {new StackTrace().GetFrame(1).GetMethod().Name}");
        }
       
        public AutoDto DeleteAuto(AutoDto auto) {
            bc.DeleteAuto(auto.ConvertToEntity());
            return auto;
        }

        public KundeDto DeleteKunde(KundeDto kunde) {
            bc.DeleteKunde(kunde.ConvertToEntity());
            return kunde;
        }

        public ReservationDto DeleteReservation(ReservationDto reservation) {
            bc.DeleteReservation(reservation.ConvertToEntity());
            return reservation;
        }

        public AutoDto GetAutoById(int Id) {
            return bc.GetAutoById(Id).ConvertToDto();
        }

        public List<AutoDto> GetAutos() {
            return bc.GetAutos().ConvertToDtos();
        }

        public KundeDto GetKundeById(int Id) {
            return bc.GetKundeById(Id).ConvertToDto();
        }

        public List<KundeDto> GetKunden() {
            return bc.GetKunden().ConvertToDtos();
        }

        public ReservationDto GetReservationById(int Id) {
            return bc.GetReservationById(Id).ConvertToDto();
        }

        public List<ReservationDto> GetReservationen() {
            return bc.GetReservationen().ConvertToDtos();
        }

        public AutoDto InsertAuto(AutoDto auto) {
            bc.InsertAuto(auto.ConvertToEntity());
            return auto;
        }

        public KundeDto InsertKunde(KundeDto kunde) {
            bc.InsertKunde(kunde.ConvertToEntity());
            return kunde;
        }

        public ReservationDto InsertReservation(ReservationDto reservation) {
            bc.InsertReservation(reservation.ConvertToEntity());
            return reservation;
        }
        //Exceptionhandling
        public AutoDto UpdateAuto(AutoDto auto) {
            try {
                bc.UpdateAuto(auto.ConvertToEntity());
            }
            catch (LocalOptimisticConcurrencyException<Auto> e) {
                throw new FaultException<AutoDto>(e.MergedEntity.ConvertToDto(), e.Message);
            }
            return auto;
        }

        public KundeDto UpdateKunde(KundeDto kunde) {
            try {
                bc.UpdateKunde(kunde.ConvertToEntity());
            } 
            catch (LocalOptimisticConcurrencyException<Kunde> e) {
                throw new FaultException<KundeDto>(e.MergedEntity.ConvertToDto(), e.Message);
            }
            return kunde;
        }

        public ReservationDto UpdateReservation(ReservationDto reservation) {
            try {
                bc.UpdateReservation(reservation.ConvertToEntity());
            } 
            catch (LocalOptimisticConcurrencyException<Reservation> e) {
                throw new FaultException<ReservationDto>(e.MergedEntity.ConvertToDto(), e.Message);
            }
            return reservation;
        }
    }
}
