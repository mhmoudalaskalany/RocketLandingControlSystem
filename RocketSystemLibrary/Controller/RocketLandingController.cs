using System;
using RocketSystemLibrary.Models;
using RocketSystemLibrary.Services;

namespace RocketSystemLibrary.Controller
{
    public class RocketLandingController
    {
        #region Private Fields

        private const int AreaTopLeftSide = 1;
        private const int DefaultAreaSize = 100;
        private const int PlatformTopLeftSide = 5;
        private const int DefaultPlatformSize = 10;

        /// <summary>
        /// Last Rocket Landing Position
        /// </summary>
        private SquareArea LastRocketPosition { get; set; }

        /// <summary>
        /// Landing Area Property
        /// </summary>
        public SquareArea Area { get; set; }

        /// <summary>
        /// Landing Platform 
        /// </summary>
        public SquareArea Platform { get; set; }

        #endregion


        #region Constructors
        /// <summary>
        /// Default initialization
        /// </summary>
        public RocketLandingController()
        {
            // initialize landing area square and platform square
            Area = new SquareArea(new Coordination(AreaTopLeftSide, AreaTopLeftSide), DefaultAreaSize);
            Platform = new SquareArea(new Coordination(PlatformTopLeftSide, PlatformTopLeftSide), DefaultPlatformSize);
        }

        /// <summary>
        /// Make Landing Platform Size Configurable
        /// </summary>
        public RocketLandingController(int newSizeForPlatform)
        {
            if (newSizeForPlatform + PlatformTopLeftSide > DefaultAreaSize)
            {
                throw new Exception(Message.NotInArea);
            }

            Area = new SquareArea(new Coordination(AreaTopLeftSide, AreaTopLeftSide), DefaultAreaSize);
            Platform = new SquareArea(new Coordination(PlatformTopLeftSide, PlatformTopLeftSide), newSizeForPlatform);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Allow Rocket To Create New Request For landing
        /// </summary>
        /// <param name="xAxis"></param>
        /// <param name="yAxis"></param>
        /// <returns></returns>
        public string CreateNewRequest(int xAxis, int yAxis)
        {
            var coordination = new Coordination(xAxis, yAxis);
            var result = ProcessRequestForLanding(coordination);
            return result;
        }
        /// <summary>
        /// Process Rockets  New Landing Request
        /// </summary>
        /// <param name="landingCoordination"></param>
        /// <returns></returns>
        public string ProcessRequestForLanding(Coordination landingCoordination)
        {
            var response = string.Empty;
            if (LastRocketPosition != null &&
                AreaService.CheckIfCoordinationInArea(LastRocketPosition, landingCoordination))
            {
                response = Message.Clash;
            }

            else if (AreaService.CheckIfCoordinationInArea(Platform, landingCoordination))
            {
                response = Message.Ok;
            }

            else
            {
                response = Message.OutOfRange;
            }
            
            // last save the request in the last position property
            LastRocketPosition = AreaService.CreateSafeArea(landingCoordination);
            return response;
        }
        #endregion

        #region Private Methods

        #endregion
    }
}