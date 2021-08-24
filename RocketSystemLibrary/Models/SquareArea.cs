namespace RocketSystemLibrary.Models
{
    /// <summary>
    /// To Define The Square Area
    /// It Takes Coordination Instance and Define The Area
    /// </summary>
    public class SquareArea
    {
        #region Private Fields

        public Coordination TopLeftSide { get; set; }
        public int AreaSize { get; set; }

        #endregion

        #region Constructors

        public SquareArea(Coordination topLeftSide , int areaSize)
        {
            TopLeftSide = topLeftSide;
            AreaSize = areaSize;
        }

        #endregion
    }
}