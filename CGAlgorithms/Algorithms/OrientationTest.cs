using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGUtilities;


namespace CGAlgorithms.Algorithms
{
    class OrientationTest: Algorithm
    {
        public override void Run(List<Point> points, List<Line> lines, List<Polygon> polygons, ref List<Point> outPoints, ref List<Line> outLines, ref List<Polygon> outPolygons)
        {
            Point p1 = new Point(lines[0].Start.X - lines[0].End.X, lines[0].Start.Y - lines[0].End.Y);
            Point p2 = new Point(lines[0].End.X-points[0].X,lines[0].End.Y-points[0].Y);

            if (CGUtilities.HelperMethods.CheckTurn(p1, p2) == Enums.TurnType.Right)
            {
                outPoints.Add(points[0]);
            }
            else
            {
                outLines.Add(lines[0]);
            }

        }
        public override string ToString()
        {
            return "OrientationTest";
        }
    }
}
