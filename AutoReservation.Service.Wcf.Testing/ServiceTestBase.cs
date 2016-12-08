using AutoReservation.BusinessLayer;
using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Common.Interfaces;
using AutoReservation.Dal.Entities;
using AutoReservation.TestEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ServiceModel;

namespace AutoReservation.Service.Wcf.Testing
{
    [TestClass]
    public abstract class ServiceTestBase
    {
        protected abstract IAutoReservationService Target { get; }

        [TestInitialize]
        public void InitializeTestData()
        {
            TestEnvironmentHelper.InitializeTestData();
        }

        #region Read all entities

        [TestMethod]
        public void GetAutosTest()
        {
            List<AutoDto> list = Target.GetAutos();
            AutoDto auto = list[1];
            Assert.AreEqual(auto.Marke, Target.GetAutos()[1].Marke);
        }

        [TestMethod]
        public void GetKundenTest()
        {
            List<KundeDto> list = Target.GetKunden();
            KundeDto kunde = list[1];
            Assert.AreEqual(kunde.Nachname, Target.GetKunden()[1].Nachname);
        }

        [TestMethod]
        public void GetReservationenTest()
        {
            List<ReservationDto> list = Target.GetReservationen();
            ReservationDto res = list[1];
            Assert.AreEqual(res.Auto.Marke, Target.GetReservationen()[1].Auto.Marke);
        }

        #endregion

        #region Get by existing ID

        [TestMethod]
        public void GetAutoByIdTest()
        {
            AutoDto auto = Target.GetAutoById(1);
            Assert.AreEqual(auto.Marke, Target.GetAutoById(1).Marke);
        }

        [TestMethod]
        public void GetKundeByIdTest()
        {
            KundeDto kunde = Target.GetKundeById(1);
            Assert.AreEqual(kunde.Nachname, Target.GetKundeById(1).Nachname);
        }

        [TestMethod]
        public void GetReservationByNrTest()
        {
            ReservationDto res = Target.GetReservationById(1);
            Assert.AreEqual(res.Kunde, Target.GetReservationById(1).Kunde);
        }

        #endregion

        #region Get by not existing ID

        [TestMethod]
        public void GetAutoByIdWithIllegalIdTest()
        {
            AutoDto auto = Target.GetAutoById(20);
            Assert.IsNull(auto);
        }

        [TestMethod]
        public void GetKundeByIdWithIllegalIdTest()
        {
            KundeDto kunde = Target.GetKundeById(20);
            Assert.IsNull(kunde);
        }

        [TestMethod]
        public void GetReservationByNrWithIllegalIdTest()
        {
            ReservationDto res = Target.GetReservationById(20);
            Assert.IsNull(res);
        }

        #endregion

        #region Insert

        [TestMethod]
        public void InsertAutoTest()
        {
            Auto auto = new LuxusklasseAuto();
            auto.Marke = "Lamborghini";
            auto.Tagestarif = 150;
            Target.InsertAuto(auto.ConvertToDto());
            Assert.AreEqual(auto.ConvertToDto().Marke, Target.GetAutoById(4).Marke);
        }

        [TestMethod]
        public void InsertKundeTest()
        {
            Kunde kunde = new Kunde();
            kunde.Vorname = "Michael";
            kunde.Nachname = "Mann";
            kunde.Geburtsdatum = new DateTime(1992, 3, 14);
            Target.InsertKunde(kunde.ConvertToDto());
            Assert.AreEqual(kunde.ConvertToDto().Geburtsdatum, Target.GetKundeById(5).Geburtsdatum);
        }

        [TestMethod]
        public void InsertReservationTest()
        {
            Auto auto = new LuxusklasseAuto();
            auto.Marke = "Lamborghini";
            auto.Tagestarif = 150;
            Target.InsertAuto(auto.ConvertToDto()); 
            Kunde kunde = new Kunde();
            kunde.Vorname = "Michael";
            kunde.Nachname = "Mann";
            kunde.Geburtsdatum = new DateTime(1992, 3, 14);
            Target.InsertKunde(kunde.ConvertToDto());
            Reservation res = new Reservation();
            res.Von = new DateTime(2050, 6, 10);
            res.Bis = new DateTime(2051, 6, 10);
            res.Auto = auto;
            res.Kunde = kunde;
            Target.InsertReservation(res.ConvertToDto());
            Assert.AreEqual(res.Von, Target.GetReservationById(4).Von);
        }

        #endregion

        #region Delete  

        [TestMethod]
        public void DeleteAutoTest()
        {
            AutoDto auto = Target.GetAutoById(1);
            Target.DeleteAuto(auto);
            Assert.IsNull(Target.GetAutoById(1));
        }

        [TestMethod]
        public void DeleteKundeTest()
        {
            KundeDto kunde = Target.GetKundeById(1);
            Target.DeleteKunde(kunde);
            Assert.IsNull(Target.GetKundeById(1));
        }

        [TestMethod]
        public void DeleteReservationTest()
        {
            ReservationDto res = Target.GetReservationById(1);
            Target.DeleteReservation(res);
            Assert.IsNull(Target.GetReservationById(1));
        }

        #endregion

        #region Update

        [TestMethod]
        public void UpdateAutoTest()
        {
            AutoDto auto = Target.GetAutoById(1);
            auto.Marke = "Lamborghini";
            Target.UpdateAuto(auto);
            Assert.AreEqual(auto.Marke, Target.GetAutoById(1).Marke);
        }

        [TestMethod]
        public void UpdateKundeTest()
        {
            KundeDto kunde = Target.GetKundeById(1);
            kunde.Nachname = "Mann";
            Target.UpdateKunde(kunde);
            Assert.AreEqual(kunde.Nachname, Target.GetKundeById(1).Nachname);
        }

        [TestMethod]
        public void UpdateReservationTest()
        {
            ReservationDto res = Target.GetReservationById(1);
            res.Von = new DateTime(2000, 5, 5);
            Target.UpdateReservation(res);
            Assert.AreEqual(res.Von, Target.GetReservationById(1).Von);
        }

        #endregion

        #region Update with optimistic concurrency violation

        [TestMethod]
        [ExpectedException(typeof(FaultException<AutoDto>))]
        public void UpdateAutoWithOptimisticConcurrencyTest()
        {
            AutoDto auto1 = Target.GetAutoById(1);
            AutoDto auto2 = Target.GetAutoById(1);
            auto1.Marke = "Mercedes";
            auto2.Marke = "Alfa Romeo";
            Target.UpdateAuto(auto1);
            Target.UpdateAuto(auto2);

        }

        [TestMethod]
        [ExpectedException(typeof(LocalOptimisticConcurrencyException<KundeDto>))]
        public void UpdateKundeWithOptimisticConcurrencyTest()
        {
            KundeDto kunde1 = Target.GetKundeById(1);
            KundeDto kunde2 = Target.GetKundeById(1);
            kunde1.Nachname = "Mann";
            kunde2.Nachname = "Gruber";
            Target.UpdateKunde(kunde1);
            Target.UpdateKunde(kunde2);
        }

        [TestMethod]
        [ExpectedException(typeof(LocalOptimisticConcurrencyException<ReservationDto>))]
        public void UpdateReservationWithOptimisticConcurrencyTest()
        {
            ReservationDto res1 = Target.GetReservationById(1);
            ReservationDto res2 = Target.GetReservationById(1);
            res1.Von = new DateTime(2010, 5, 5);
            res2.Von = new DateTime(2009, 7, 7);
            Target.UpdateReservation(res1);
            Target.UpdateReservation(res2);
        }

        #endregion
    }
}
