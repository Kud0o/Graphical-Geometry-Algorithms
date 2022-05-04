using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGUtilities;

namespace CGAlgorithms.Algorithms
{
    class PointInConcaveHull : Algorithm
    {
        public override void Run(List<Point> points, List<Line> lines, List<Polygon> polygons, ref List<Point> outPoints, ref List<Line> outLines, ref List<Polygon> outPolygons)
        { 
            double x=0,y=0;

            for(int i=0;i<polygons[0].lines.Count;i++)
            {
            x+= polygons[0].lines[i].Start.X;
            y+= polygons[0].lines[i].Start.Y;
            }
            x= x/polygons[0].lines.Count;
            y= y/polygons[0].lines.Count;


            Point center = new Point(x, y);

            Line L = new Line(points[0], new Point(polygons[0].lines[0].Start.X / 2 + polygons[0].lines[0].End.X / 2, polygons[0].lines[0].Start.Y/2+ polygons[0].lines[0].End.Y/2));
            int c = 0;
            for (int i = 0; i < polygons[0].lines.Count; i++)
            {
                if (CGUtilities.HelperMethods.CheckTurn(L, polygons[0].lines[i].Start) == Enums.TurnType.Colinear || CGUtilities.HelperMethods.CheckTurn(L, polygons[0].lines[i].End) == Enums.TurnType.Colinear)
                    continue;

                if (CGUtilities.HelperMethods.CheckTurn(L, polygons[0].lines[i].Start) != CGUtilities.HelperMethods.CheckTurn(L, polygons[0].lines[i].End))
                {

                    Point s = L.Start; // first point - first line
                    Point e = L.End; // second point - first line

                    double m1 = (e.Y - s.Y) / (e.X - s.X); //slope for first line
                    double B1 = s.Y - s.X * (m1); // intersection for first line with -axis

                    Point s2 = polygons[0].lines[i].Start;// first point - second line
                    Point e2 = polygons[0].lines[i].End; // second point - second line
                    double m2 = (e2.Y - s2.Y) / (e2.X - s2.X); //slope for second line
                    double B2 = s2.Y - s2.X * (m2); // intersection for second line with -axis

                    double Xintersect = (B2 - B1) / (m1 - m2); // Y1 = 2 so m1*x1 + B1 = m2*x2 + B2 so x2 = ??
                    double Yintersect = Xintersect * m1 + B1;  // Y = X2(intersection)*m2 + B2 to get Y for intersection point
                    Point intersect = new Point(Xintersect, Yintersect);
                    if (CGUtilities.HelperMethods.PointOnSegment(intersect, L.Start, L.End))
                    {
                        c++;
                        outLines.Add(new Line(intersect,points[0]));
                    }

                }
              
            
            }

  if(c%2==1)
      outPoints.Add(points[0]);

        }

        public override string ToString()
        {
            return "PointInConcaveHull";
        }

    }
}
