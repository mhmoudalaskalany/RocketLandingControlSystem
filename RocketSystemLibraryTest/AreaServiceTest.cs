using Microsoft.VisualStudio.TestTools.UnitTesting;
using RocketSystemLibrary.Models;
using RocketSystemLibrary.Services;

namespace RocketSystemLibraryTest
{
    [TestClass]
    public class AreaServiceTest
    {
        /// <summary>
        /// Test Creating Safe Area
        /// </summary>
        [TestMethod]
        public void SafeAreaTest()
        {
            var request = new Coordination(5, 5);
            var coordination = new Coordination(4, 4);
            var area = AreaService.CreateSafeArea(request);
            Assert.AreEqual(area.AreaSize, 3);
            Assert.AreEqual(area.TopLeftSide, coordination);
        }


        /// <summary>
        /// Test If Coordination Is In Defined Landing Area
        /// </summary>
        [TestMethod]
        public void TestCheckIfCoordinationInArea()
        {
            var request = new Coordination(5, 5);
            var inCoordination = new Coordination(4, 4);
            var outCoordination = new Coordination(12, 13);
            var area = AreaService.CreateSafeArea(request);
            Assert.IsFalse(AreaService.CheckIfCoordinationInArea(area, outCoordination));
            Assert.IsTrue(AreaService.CheckIfCoordinationInArea(area, inCoordination));
        }
    }
}