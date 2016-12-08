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
                return auto;
            }
        }

        public List<Auto> GetAutos() {
            using (var db = new AutoReservationContext()) {
                List<Auto> list = db.Autos.ToList();
                return list;
            }
        }

        public Kunde GetKundeById(int Id) {
            using (var db = new AutoReservationContext()) {
                Kunde kunde = db.Kunden.Find(Id);
                return kunde;
            }
        }

        public List<Kunde> GetKunden() {
            using (var db = new AutoReservationContext()) {
                List<Kunde> list = db.Kunden.ToList();
                return list;
            }
        }

        public Reservation GetReservationById(int Id) {
            using (var db = new AutoReservationContext()) {
                return db.Reservationen
                    .Include(res => res.Kunde)
                    .Include(res => res.Auto)
                    .SingleOrDefault(r => r.ReservationsNr == Id);
            }
        }

        public List<Reservation> GetReservationen() {
            using (var db = new AutoReservationContext()) {
                return db.Reservationen
                    .Include(res => res.Auto)
                    .Include(res => res.Kunde)
                    .ToList<Reservation>();
            }
        }

        public Auto InsertAuto(Auto auto) {
            using (var db = new AutoReservationContext()) {
                db.Entry(auto).State = EntityState.Added;
                db.SaveChanges();
            }
            return auto;
        }

        public Kunde InsertKunde(Kunde kunde) {
            using (var db = new AutoReservationContext()) {
                db.Entry(kunde).State = EntityState.Added;
                db.SaveChanges();
            }
            return kunde;
        }

        public Reservation InsertReservation(Reservation reservation) {
            using (var db = new AutoReservationContext()) {
                db.Entry(reservation).State = EntityState.Added;
                db.Entry(reservation).Reference(res => res.Auto).Load();
                db.Entry(reservation).Reference(res => res.Kunde).Load();
                db.SaveChanges();
            }
            return reservation;
        }

        public Auto UpdateAuto(Auto auto) {
            using (var db = new AutoReservationContext()) {
                try {
                    db.Entry(auto).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException) {
                    throw CreateLocalOptimisticConcurrencyException(db, auto);
                }
                return auto;
            }
        }

        public Kunde UpdateKunde(Kunde kunde) {
            using (var db = new AutoReservationContext()) {
                try {
                    db.Entry(kunde).State = EntityState.Modified;
                    db.SaveChanges();
                } catch (DbUpdateConcurrencyException) {
                    throw CreateLocalOptimisticConcurrencyException(db, kunde);
                }
                return kunde;
            }
        }

        public Reservation UpdateReservation(Reservation reservation) {
            using (var db = new AutoReservationContext()) {
                try {
                    db.Entry(reservation).State = EntityState.Modified;
                    db.Entry(reservation).Reference(res => res.Auto).Load();
                    db.Entry(reservation).Reference(res => res.Kunde).Load();
                    db.SaveChanges();
                } catch (DbUpdateConcurrencyException) {
                    throw CreateLocalOptimisticConcurrencyException(db, reservation);
                }
                return reservation;
            }
        }

        public Auto DeleteAuto(Auto auto) {
            using (var db = new AutoReservationContext()) {
                db.Entry(auto).State = EntityState.Deleted;
                db.SaveChanges();
            }
            return auto;
        }

        public Kunde DeleteKunde(Kunde kunde) {
            using (var db = new AutoReservationContext()) {
                db.Entry(kunde).State = EntityState.Deleted;
                db.SaveChanges();
            }
            return kunde;
        }

        public Reservation DeleteReservation(Reservation reservation) {
            using (var db = new AutoReservationContext()) {
                db.Entry(reservation).State = EntityState.Deleted;
                db.SaveChanges();
            }
            return reservation;
        }
    }
}