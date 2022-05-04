using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGUtilities;
namespace CGAlgorithms.Algorithms
{
    class LinePolygonIntersect: Algorithm
    {

        public override void Run(List<Point> points, List<Line> lines, List<Polygon> polygons, ref List<Point> outPoints, ref List<Line> outLines, ref List<Polygon> outPolygons)
        {
            for (int i = 0; i < polygons[0].lines.Count(); i++)
            {
                Point s = lines[0].Start; // first point - first line
                Point e = lines[0].End; // second point - first line

                double m1 = (e.Y - s.Y) / (e.X - s.X); //slope for first line
                double B1 = s.Y - s.X * (m1); // intersection for first line with -axis

                Point s2 = polygons[0].lines[i].Start;// first point - second line
                Point e2 = polygons[0].lines[i].End; // second point - second line
                double m2 = (e2.Y - s2.Y) / (e2.X - s2.X); //slope for second line
                double B2 = s2.Y - s2.X * (m2); // intersection for second line with -axis

                double Xintersect = (B2 - B1) / (m1 - m2); // Y1 = 2 so m1*x1 + B1 = m2*x2 + B2 so x2 = ??
                double Yintersect = Xintersect * m1 + B1;  // Y = X2(intersection)*m2 + B2 to get Y for intersection point
                Point intersect = new Point(Xintersect, Yintersect);
                // Point O = new Point(0, 0);
                //  Line L = new Line(O, intersect);
                if (CGUtilities.HelperMethods.PointOnSegment(intersect, lines[0].Start, lines[0].End) && CGUtilities.HelperMethods.PointOnSegment(intersect, polygons[0].lines[i].Start, polygons[0].lines[i].End))
                    outPoints.Add(intersect);

            }
        }


        public override string ToString()
        {
            return "LinePolyIntersect";
        }

    }
}
