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
            throw new NotImplementedException();
        }

        public void DeleteKunde(KundeDto kunde) {
            throw new NotImplementedException();
        }

        public void DeleteReservation(ReservationDto reservation) {
            throw new NotImplementedException();
        }

        public AutoDto GetAutoById(int Id) {
            using (var db = new AutoReservationContext()) {
                AutoDto auto = db.Autos.Find(Id).ConvertToDto();
                if (auto != null) {
                    return auto;
                } else //FaultException {
                    throw new Exception();
            }
        }

        public IList<AutoDto> GetAutos() {
            using (var db = new AutoReservationContext()) {
                List<AutoDto> list = db.Autos.ConvertToDtos();
                return list;
            }
        }

        public KundeDto GetKundeById(int Id) {
            throw new NotImplementedException();
        }

        public IList<KundeDto> GetKunden() {
            throw new NotImplementedException();
        }

        public ReservationDto GetReservationById(int Id) {
            throw new NotImplementedException();
        }

        public IList<ReservationDto> GetReservationen() {
            throw new NotImplementedException();
        }

        public void InsertAuto(AutoDto auto) {
            throw new NotImplementedException();
        }

        public void InsertKunde(KundeDto kunde) {
            throw new NotImplementedException();
        }

        public void InsertReservation(ReservationDto reservation) {
            throw new NotImplementedException();
        }

        public void UpdateAuto(AutoDto auto) {
            throw new NotImplementedException();
        }

        public void UpdateKunde(KundeDto kunde) {
            throw new NotImplementedException();
        }

        public void UpdateReservation(ReservationDto reservation) {
            throw new NotImplementedException();
        }
    }
}
