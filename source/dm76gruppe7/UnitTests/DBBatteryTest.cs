using DBLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataTier;

namespace UnitTests
{
    
    
    /// <summary>
    ///This is a test class for DBBatteryTest and is intended
    ///to contain all DBBatteryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DBBatteryTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for searchBatteryID
        ///</summary>
        [TestMethod()]
        public void searchBatteryIDTest()
        {
            DBBattery target = new DBBattery(); // TODO: Initialize to an appropriate value
            int id = 1; // TODO: Initialize to an appropriate value
            Battery expected = new Battery(1,Battery.Status.Charged,new Station(1,"TRAFIKCENTER SÆBY SYD","20",9300)); // TODO: Initialize to an appropriate value
            Battery actual;
            actual = target.searchBatteryID(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
