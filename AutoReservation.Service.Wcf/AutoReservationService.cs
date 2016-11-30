using AutoReservation.Common.Interfaces;
using System;
using System.Diagnostics;
using AutoReservation.Common.DataTransferObjects;
using System.Collections.Generic;
using AutoReservation.Dal;
using AutoReservation.Dal.Entities;
using AutoReservation.BusinessLayer;

namespace AutoReservation.Service.Wcf {
    public class AutoReservationService : IAutoReservationService {
        AutoReservationBusinessComponent bc = new AutoReservationBusinessComponent();

        private static void WriteActualMethod() {
            Console.WriteLine($"Calling: {new StackTrace().GetFrame(1).GetMethod().Name}");
        }

        public void DeleteAuto(AutoDto auto) {
            bc.DeleteAuto(auto.ConvertToEntity());
        }

        public void DeleteKunde(KundeDto kunde) {
            bc.DeleteKunde(kunde.ConvertToEntity());
        }

        public void DeleteReservation(ReservationDto reservation) {
            bc.DeleteReservation(reservation.ConvertToEntity());
        }

        public AutoDto GetAutoById(int Id) {
            return bc.GetAutoById(Id).ConvertToDto();
        }

        public IList<AutoDto> GetAutos() {
            return bc.GetAutos().ConvertToDtos();
        }

        public KundeDto GetKundeById(int Id) {
            return bc.GetKundeById(Id).ConvertToDto();
        }

        public IList<KundeDto> GetKunden() {
            return bc.GetKunden().ConvertToDtos();
        }

        public ReservationDto GetReservationById(int Id) {
            return bc.GetReservationById(Id).ConvertToDto();
        }

        public IList<ReservationDto> GetReservationen() {
            return bc.GetReservationen().ConvertToDtos();
        }

        public void InsertAuto(AutoDto auto) {
            bc.InsertAuto(auto.ConvertToEntity());
        }

        public void InsertKunde(KundeDto kunde) {
            bc.InsertKunde(kunde.ConvertToEntity());
        }

        public void InsertReservation(ReservationDto reservation) {
            bc.InsertReservation(reservation.ConvertToEntity());
        }
        //Exceptionhandling
        public void UpdateAuto(AutoDto auto) {
            try {
                bc.UpdateAuto(auto.ConvertToEntity());
            }
            catch (LocalOptimisticConcurrencyException<AutoDto>) {
                
            }
        }

        public void UpdateKunde(KundeDto kunde) {
            try {
                bc.UpdateKunde(kunde.ConvertToEntity());
            }
            catch (LocalOptimisticConcurrencyException<KundeDto>) {

            }
        }

        public void UpdateReservation(ReservationDto reservation) {
            throw new NotImplementedException();
        }
    }
}
