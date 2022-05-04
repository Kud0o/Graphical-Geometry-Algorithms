using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGUtilities;

namespace CGAlgorithms.Algorithms
{
    class Triangle :Algorithm
    {
        
      //  List<Enums.TurnType> L = new List<Enums.TurnType>(3);
        public override void Run(List<Point> points, List<Line> lines, List<Polygon> polygons, ref List<Point> outPoints, ref List<Line> outLines, ref List<Polygon> outPolygons)
        {
        /*for(int i =0 ; i< 3;i++)
        {
            Point p1 = new Point(polygons[0].lines[i].Start.X - polygons[0].lines[0].End.X, polygons[0].lines[i].Start.Y - polygons[0].lines[0].End.Y);
            Point p2 = new Point(polygons[0].lines[i].End.X - points[0].X, polygons[0].lines[i].End.Y - points[0].Y);

          L[i]= CGUtilities.HelperMethods.CheckTurn(p1, p2);
        
        }
            */
        if ((CGUtilities.HelperMethods.PointInTriangle(points[0], polygons[0].lines[0].Start, polygons[0].lines[2].Start, polygons[0].lines[1].Start) == Enums.PointInPolygon.Inside) || CGUtilities.HelperMethods.PointInTriangle(points[0], polygons[0].lines[0].Start, polygons[0].lines[2].Start, polygons[0].lines[1].Start) == Enums.PointInPolygon.OnEdge)
            outPoints.Add(points[0]);
    else
     //       outPolygons.Add(polygons[0]);
       outLines = polygons[0].lines;
        }
        
        public override string ToString()
        {
            return "Triangle";
        }
    }
}
