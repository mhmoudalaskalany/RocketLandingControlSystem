using RocketSystemLibrary.Models;

namespace RocketSystemLibrary.Services
{
    /// <summary>
    /// Service To Handle Coordination
    /// </summary>
    public static class AreaService
    {
        #region Public Methods

        /// <summary>
        /// Method To Create Safe Adjacent Area  
        /// </summary>
        /// <param name="coordination"></param>
        /// <returns></returns>
        public static SquareArea CreateSafeArea(Coordination coordination)
        {
            var topLeftSide = new Coordination(coordination.XAxis - 1, coordination.YAxis - 1);
            var squareArea = new SquareArea(topLeftSide, 3);
            return squareArea;
        }

        /// <summary>
        /// Check If The Passed Coordination is in the square area
        /// </summary>
        /// <param name="area"></param>
        /// <param name="coordination"></param>
        /// <returns></returns>
        public static bool CheckIfCoordinationInArea(SquareArea area, Coordination coordination)
        {
            var topLeftSide = area.TopLeftSide;
            var size = area.AreaSize;
            if (coordination.XAxis >= topLeftSide.XAxis &&
                coordination.XAxis <= topLeftSide.XAxis + size - 1 &&
                coordination.YAxis >= topLeftSide.YAxis &&
                coordination.YAxis <= topLeftSide.YAxis + size - 1
            )
            {
                return true;
            }

            return false;
        }

        #endregion
    }
}