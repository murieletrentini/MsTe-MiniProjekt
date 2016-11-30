using AutoReservation.Common.Interfaces;
using System;
using System.Diagnostics;
using AutoReservation.Common.DataTransferObjects;
using System.Collections.Generic;
using AutoReservation.Dal;
using AutoReservation.Dal.Entities;

namespace AutoReservation.Service.Wcf {
    public class AutoReservationService : IAutoReservationService {

        private static void WriteActualMethod() {
            Console.WriteLine($"Calling: {new StackTrace().GetFrame(1).GetMethod().Name}");
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
    }
}
