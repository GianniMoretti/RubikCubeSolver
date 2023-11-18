using System.Drawing;

namespace RubikCube.UI
{
   public class VectorOfPoint
    {
        public Point[] Points = new Point[4];
        public VectorOfPoint(Point p1, Point p2, Point p3, Point p4)
        {
            Points[0] = p1;
            Points[1] = p2;
            Points[2] = p3;
            Points[3] = p4;
        }
    }
}
