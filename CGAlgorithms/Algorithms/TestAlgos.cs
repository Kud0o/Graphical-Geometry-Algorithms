using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGUtilities;

namespace CGAlgorithms.Algorithms
{
    class TestAlgos:Algorithm
    {
        public override void Run(List<Point> points, List<Line> lines, List<Polygon> polygons, ref List<Point> outPoints, ref List<Line> outLines, ref List<Polygon> outPolygons)
        {
           /* outPoints.Add(new Point(-30, -20));
            outPoints.Add(new Point(-40, -40));
            outPoints.Add(new Point(-20, 0));
            outPoints.Add(new Point(0, 40));
            outPoints.Add(new Point(-10, 20));
            outPoints.Add(new Point(0, 40));*/
            List<Point> inputPoints = new List<Point>();
            inputPoints.Add(new Point(-190, -102));
            inputPoints.Add(new Point(-144, 91));
            inputPoints.Add(new Point(47, 63));
            inputPoints.Add(new Point(8, 126));
            inputPoints.Add(new Point(172, -131));
            inputPoints.Add(new Point(-15, 12));
            inputPoints.Add(new Point(37, 199));
            inputPoints.Add(new Point(-137, 55));
            inputPoints.Add(new Point(150, 165));
            inputPoints.Add(new Point(106, -91));
            inputPoints.Add(new Point(-105, -183));
            inputPoints.Add(new Point(159, -161));
            inputPoints.Add(new Point(69, -55));
            inputPoints.Add(new Point(0, -85));
            inputPoints.Add(new Point(174, -99));
            inputPoints.Add(new Point(-32, 235));
            inputPoints.Add(new Point(-225, 148));
            inputPoints.Add(new Point(-214, -227));
            inputPoints.Add(new Point(227, -235));
            inputPoints.Add(new Point(215, 209));

            List<Point> desiredPoints = new List<Point>();


            desiredPoints.Add(new Point(-7, 241));
            desiredPoints.Add(new Point(-234, 213));
            desiredPoints.Add(new Point(-212, -228));
            desiredPoints.Add(new Point(219, -231));
            desiredPoints.Add(new Point(204, 189));

            foreach (Point P in desiredPoints)
            outPoints.Add(P);
        }

        public override string ToString()
        {
            return "Test Algos yo Haha";
        }

    }
}
