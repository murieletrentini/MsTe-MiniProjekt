using AutoReservation.Dal.Entities;
using AutoReservation.TestEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AutoReservation.BusinessLayer.Testing
{
    [TestClass]
    public class BusinessLayerTest
    {

        private AutoReservationBusinessComponent target;
        private AutoReservationBusinessComponent Target
        {
            get
            {
                if (target == null)
                {
                    target = new AutoReservationBusinessComponent();
                }
                return target;
            }
        }
        
        [TestInitialize]
        public void InitializeTestData()
        {
            TestEnvironmentHelper.InitializeTestData();
        }
        
        [TestMethod]
        public void UpdateAutoTest()
        {
            Auto changeAuto = Target.GetAutoById(1);
            changeAuto.Marke = "TestMarke";
            Target.UpdateAuto(changeAuto); 
            Assert.AreEqual(changeAuto.Marke, Target.GetAutoById(1).Marke);    
        }

        [TestMethod]
        public void UpdateKundeTest()
        {
            Kunde changeKunde = Target.GetKundeById(1);
            changeKunde.Vorname = "Hans";
            Target.UpdateKunde(changeKunde);
            Assert.AreEqual(changeKunde.Vorname, Target.GetKundeById(1).Vorname);   
        }

        [TestMethod]
        public void UpdateReservationTest()
        {
            Reservation changeRes = Target.GetReservationById(1);
            changeRes.Bis = new DateTime(2050, 6, 10);
            Target.UpdateReservation(changeRes);
            Assert.AreEqual(changeRes.Bis, Target.GetReservationById(1).Bis);
        }

    }

}
