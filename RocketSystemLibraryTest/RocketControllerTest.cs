using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RocketSystemLibrary.Controller;
using RocketSystemLibrary.Models;

namespace RocketSystemLibraryTest
{
    [TestClass]
    public class RocketControllerTest
    {
        /// <summary>
        /// Test Top Left Side
        /// </summary>
        [TestMethod]
        public void RequestTopLeftSidePlatformTest()
        {
            var rocketController = new RocketLandingController();
            var requestOne = new Coordination(5, 5);
            Assert.AreEqual(Message.Ok, rocketController.ProcessRequestForLanding(requestOne));
        }

        /// <summary>
        /// Test Bottom Corner
        /// </summary>
        [TestMethod]
        public void BottomSideCornerPlatformTest()
        {
            var rocketController = new RocketLandingController();
            var requestOne = new Coordination(8, 8);
            Assert.AreEqual(Message.Ok, rocketController.ProcessRequestForLanding(requestOne));
        }

        /// <summary>
        /// Test Previously Checked Location
        /// </summary>
        [TestMethod]
        public void TestLastCheckedLocation()
        {
            var rocketController = new RocketLandingController();
            var requestOne = new Coordination(17, 5);
            Assert.AreEqual(Message.OutOfRange, rocketController.ProcessRequestForLanding(requestOne));
            var requestTwo = new Coordination(17, 5);
            Assert.AreEqual(Message.Clash , rocketController.ProcessRequestForLanding(requestTwo));
        }
        
        /// <summary>
        /// Test Side Cases
        /// </summary>
        [TestMethod]
        public void RequestPreviouslyRequestedSideCorners()
        {
            var rocketController  = new RocketLandingController();

            // request to top left side
            var  requestOne = new Coordination(1, 1);
            Assert.AreEqual(Message.OutOfRange, rocketController.ProcessRequestForLanding(requestOne));
            // request to clash previous request on top left side
            var  requestTwo = new Coordination(1, 1);
            Assert.AreEqual(Message.Clash, rocketController.ProcessRequestForLanding(requestTwo));
            // request to class  previous request location
            var  requestThree = new Coordination(2, 2);
            Assert.AreEqual(Message.Clash, rocketController.ProcessRequestForLanding(requestThree));
            // request out of platform
            var  requestFour = new Coordination(100, 100);
            Assert.AreEqual(Message.OutOfRange, rocketController.ProcessRequestForLanding(requestFour));
            // clash with previous out of platform  request
            var  requestFive = new Coordination(100, 100);
            Assert.AreEqual(Message.Clash, rocketController.ProcessRequestForLanding(requestFive));
            // clash with second previous out of platform request 
            var  requestSix = new Coordination(100, 99);
            Assert.AreEqual(Message.Clash, rocketController.ProcessRequestForLanding(requestSix));
        }
        
        /// <summary>
        /// Test Previously Checked Location
        /// </summary>
        [TestMethod]
        public void TestCreateNewRequest()
        {
            var rocketController = new RocketLandingController();
            Assert.AreEqual(Message.Ok, rocketController.CreateNewRequest( 5 , 5));
            Assert.AreEqual(Message.OutOfRange, rocketController.CreateNewRequest( 16 , 5));
            Assert.AreEqual(Message.Clash, rocketController.CreateNewRequest( 16 , 5));
        }
        
        /// <summary>
        /// Test Out Of Range
        /// </summary>
        [TestMethod]
        public void TestOutOfRangePlatform()
        {
            var rocketController = new RocketLandingController();
            var requestOne = new Coordination(4, 5);
            Assert.AreEqual(Message.OutOfRange, rocketController.ProcessRequestForLanding(requestOne));
            var requestTwo = new Coordination(17, 5);
            Assert.AreEqual(Message.OutOfRange, rocketController.ProcessRequestForLanding(requestTwo));
        }

        /// <summary>
        /// Test Out Of Range And Clash
        /// </summary>
        [TestMethod]
        public void TestRequestOutOfRangePlatform()
        {
            var rocketController = new RocketLandingController();
            var requestOne = new Coordination(4, 5);
            var requestTwo = new Coordination(5, 4);

            Assert.AreEqual(Message.OutOfRange, rocketController.ProcessRequestForLanding(requestOne));
            Assert.AreEqual(Message.Clash, rocketController.ProcessRequestForLanding(requestTwo));
        }

        /// <summary>
        /// Test Bigger Size Configurable Platform
        /// </summary>
        [TestMethod]
        public void TestConfigurablePlatform()
        {
            var rocketController = new RocketLandingController(30);
            var requestOne = new Coordination(20, 5);
            Assert.AreEqual(Message.Ok , rocketController.ProcessRequestForLanding(requestOne));
            var requestTwo = new Coordination(50, 5);
            Assert.AreEqual(Message.OutOfRange , rocketController.ProcessRequestForLanding(requestTwo));
        }
        
        /// <summary>
        /// Test  Platform Outside Landing Area
        /// </summary>
        [TestMethod]
        public void TestPlatformOutsideLandingArea()
        {
            var result  = Assert.ThrowsException<Exception>(() => new RocketLandingController(105));
            Assert.AreEqual(Message.NotInArea , result.Message);
        }
        
        
    }
}