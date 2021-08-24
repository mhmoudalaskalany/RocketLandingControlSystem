namespace RocketSystemLibrary.Models
{
    /// <summary>
    /// Coordination class (x and y)
    /// </summary>
    public class Coordination
    {
        #region Private  Properties

        public  int XAxis { get; set; }
        public int YAxis { get; set; }

        #endregion

        #region Constructors

        public Coordination(int xAxis, int yAxis)
        {
            XAxis = xAxis;
            YAxis = yAxis;
        }

        #endregion

        #region Public Methods
        public override bool Equals(object obj)
        {
            var casted = (Coordination) obj;
            return (casted.XAxis == XAxis && casted.YAxis == YAxis );
        }
        public string GetCoordinates()
        {
            return $"{XAxis} , {YAxis}";
        }
        #endregion
    }
}