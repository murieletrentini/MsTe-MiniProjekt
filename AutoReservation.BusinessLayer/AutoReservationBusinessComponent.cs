using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Dal;
using AutoReservation.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace AutoReservation.BusinessLayer
{
    public class AutoReservationBusinessComponent 
    {
 

        private static LocalOptimisticConcurrencyException<T> CreateLocalOptimisticConcurrencyException<T>(AutoReservationContext context, T entity)
            where T : class
        {
            var dbEntity = (T)context.Entry(entity)
                .GetDatabaseValues()
                .ToObject();

            return new LocalOptimisticConcurrencyException<T>($"Update {typeof(Auto).Name}: Concurrency-Fehler", dbEntity);
        }

        public Auto GetAutoById(int Id) {
            using (var db = new AutoReservationContext()) {
                Auto auto = db.Autos.Find(Id);
                if (auto != null) {
                    return auto;
                } else //FaultException {
                    throw new Exception();
            }
        }

        public IList<Auto> GetAutos() {
            using (var db = new AutoReservationContext()) {
                List<Auto> list = db.Autos.ToList();
                return list;
            }
        }

        public Kunde GetKundeById(int Id) {
            using (var db = new AutoReservationContext()) {
                Kunde kunde = db.Kunden.Find(Id);
                if (kunde != null) {
                    return kunde;
                }
                else {
                    throw new Exception();
                }
            }
        }

        public IList<Kunde> GetKunden() {
            using (var db = new AutoReservationContext()) {
                List<Kunde> list = db.Kunden.ToList();
                return list;
            }
        }

        public Reservation GetReservationById(int Id) {
            using (var db = new AutoReservationContext()) {
                Reservation res = db.Reservationen.Find(Id);
                if (res != null) {
                    return res;
                }
                else { //only throw Exceptions on Update?
                    throw new Exception();
                }
            }
        }

        public IList<Reservation> GetReservationen() {
            using (var db = new AutoReservationContext()) {
                List<Reservation> list = db.Reservationen.ToList();
                return list;
            }
        }

        public void InsertAuto(Auto auto) {
            using (var db = new AutoReservationContext()) {
                db.Entry(auto).State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public void InsertKunde(Kunde kunde) {
            using (var db = new AutoReservationContext()) {
                db.Entry(kunde).State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public void InsertReservation(Reservation reservation) {
            using (var db = new AutoReservationContext) {
                db.Entry(reservation).State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public void UpdateAuto(Auto auto) {
            using (var db = new AutoReservationContext()) {
                try {
                    db.Entry(auto).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException) {
                    throw CreateLocalOptimisticConcurrencyException(db, auto);
                }
            }
        }

        public void UpdateKunde(Kunde kunde) {
            using (var db = new AutoReservationContext()) {
                try {
                    db.Entry(kunde).State = EntityState.Modified;
                    db.SaveChanges();
                } catch (DbUpdateConcurrencyException) {
                    throw CreateLocalOptimisticConcurrencyException(db, kunde);
                }
            }
        }

        public void UpdateReservation(Reservation reservation) {
            using (var db = new AutoReservationContext()) {
                try {
                    db.Entry(reservation).State = EntityState.Modified;
                    db.SaveChanges();
                } catch (DbUpdateConcurrencyException) {
                    throw CreateLocalOptimisticConcurrencyException(db, reservation);
                }
            }
        }

        public void DeleteAuto(Auto auto) {
            using (var db = new AutoReservationContext()) {
                db.Entry(auto).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void DeleteKunde(Kunde kunde) {
            using (var db = new AutoReservationContext()) {
                db.Entry(kunde).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void DeleteReservation(Reservation reservation) {
            using (var db = new AutoReservationContext()) {
                db.Entry(reservation).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}