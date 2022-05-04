using CGUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGAlgorithms.Algorithms.ConvexHull
{
    public class ExtremeSegments : Algorithm
    {
        public override void Run(List<Point> points, List<Line> lines, List<Polygon> polygons, ref List<Point> outPoints, ref List<Line> outLines, ref List<Polygon> outPolygons)
        {
            List<Line> L = new List<Line>();
         /*   List<Point> inputPoints = new List<Point>();
             inputPoints.Add(new Point(-84, -157));
             inputPoints.Add(new Point(79, 195));
             inputPoints.Add(new Point(114, 38));
             inputPoints.Add(new Point(150, -111));
             inputPoints.Add(new Point(-150, 157));
             inputPoints.Add(new Point(177, 36));
             inputPoints.Add(new Point(113, -47));
             inputPoints.Add(new Point(64, -84));
             inputPoints.Add(new Point(102, 125));
             inputPoints.Add(new Point(-89, 191));
             inputPoints.Add(new Point(172, 19));
             inputPoints.Add(new Point(41, 153));
             inputPoints.Add(new Point(-88, 195));
             inputPoints.Add(new Point(-114, -117));
             inputPoints.Add(new Point(97, 183));
             inputPoints.Add(new Point(-148, 162));
             inputPoints.Add(new Point(-75, -174));
             inputPoints.Add(new Point(-53, 97));
             inputPoints.Add(new Point(-39, -200));
             inputPoints.Add(new Point(66, -178));
             inputPoints.Add(new Point(88, -145));
             inputPoints.Add(new Point(9, -44));
             inputPoints.Add(new Point(-147, 184));
             inputPoints.Add(new Point(-102, -49));
             inputPoints.Add(new Point(-4, 120));
             inputPoints.Add(new Point(129, 80));
             inputPoints.Add(new Point(72, 9));
             inputPoints.Add(new Point(27, 97));
             inputPoints.Add(new Point(1, 125));
             inputPoints.Add(new Point(82, 119));
             inputPoints.Add(new Point(-49, 67));
             inputPoints.Add(new Point(-9, -134));
             inputPoints.Add(new Point(104, -185));
             inputPoints.Add(new Point(-90, 86));
             inputPoints.Add(new Point(-194, 167));
             inputPoints.Add(new Point(154, 101));
             inputPoints.Add(new Point(-141, -112));
             inputPoints.Add(new Point(-98, 116));
             inputPoints.Add(new Point(-190, -115));
             inputPoints.Add(new Point(100, -72));
             inputPoints.Add(new Point(97, 134));
             inputPoints.Add(new Point(87, 177));
             inputPoints.Add(new Point(-146, -29));
             inputPoints.Add(new Point(-111, 115));
             inputPoints.Add(new Point(-1, 50));
             inputPoints.Add(new Point(-105, 36));
             inputPoints.Add(new Point(-82, 147));
             inputPoints.Add(new Point(70, -179));
             inputPoints.Add(new Point(64, -58));
             inputPoints.Add(new Point(51, -162));
             inputPoints.Add(new Point(73, 11));
             inputPoints.Add(new Point(-55, 29));
             inputPoints.Add(new Point(166, -173));
             inputPoints.Add(new Point(21, -16));
             inputPoints.Add(new Point(-93, 111));
             inputPoints.Add(new Point(-7, 241));
             inputPoints.Add(new Point(-234, 213));
             inputPoints.Add(new Point(-212, -228));
             inputPoints.Add(new Point(219, -231));
             inputPoints.Add(new Point(204, 189));


             foreach (Point P in inputPoints)
                 points.Add(P);

           */
            #region filtering inner points
            List<bool> avaliable = new List<bool>(points.Count);
            for (int i = 0; i < points.Count; i++)
                avaliable.Add(true);
            double distij;
            double distjk;
            double distki;
            int change = 1;
            while (change > 0)
            {
                change = 0;
                for (int i = 0; i < points.Count; i++)
                {
                    if (!avaliable[i])
                        continue;
                    for (int j = 0; j < points.Count; j++)
                    {

                        if (!avaliable[i] || !avaliable[j])
                            continue;

                        if (j == i)
                        {
                            continue;
                        }
                        int k = 0;
                        for (; k < points.Count; k++)
                        {


                            if (!avaliable[k] || !avaliable[j] || !avaliable[i])
                                continue;
                            if (k == i || k == j)
                                continue;

                            if (HelperMethods.PointOnRay(points[i], points[j], points[k]))
                            {
                                distij = Math.Sqrt(Math.Pow(points[i].X - points[j].X, 2) + Math.Pow(points[i].Y - points[j].Y, 2));
                                distjk = Math.Sqrt(Math.Pow(points[k].X - points[j].X, 2) + Math.Pow(points[k].Y - points[j].Y, 2));
                                distki = Math.Sqrt(Math.Pow(points[i].X - points[k].X, 2) + Math.Pow(points[i].Y - points[k].Y, 2));

                                if (distij > distjk && distij > distki)
                                { avaliable[k] = false; change = 1; }
                                if (distjk > distij && distjk > distki)
                                { avaliable[i] = false; change = 1; }
                                if (distki > distjk && distki > distij)
                                { avaliable[j] = false; change = 1; }

                            }
                        }
                    }
                }

            }
 #endregion

            for (int i = 0; i < points.Count; i++)
            {
                if (!avaliable[i])
                    continue;
                for (int j = 0; j < points.Count; j++)
                {
                    if (i == j)
                        continue;
                    if ( !avaliable[j] || !avaliable[i])
                        continue;

                    bool ex = true;
                    for (int k = 0; k < points.Count; k++)
                    {
                        if (!avaliable[k] || !avaliable[j] || !avaliable[i])
                            continue;

                        if (k == i || k == j )
                            continue;
//Enums.TurnType T = HelperMethods.CheckTurn(new Line(points[i], points[j]), points[k - 1]);
                        if (HelperMethods.CheckTurn(new Line(points[i], points[j]), points[k])==Enums.TurnType.Left)
                        {
                            ex = false;
                            break;
                        }

                    }
                    if (ex)
                        L.Add(new Line(points[i], points[(j) % (points.Count)]));

                }
            }
                   for(int i =0;i<L.Count;i++)
                   {
                   if(!outPoints.Contains(outLines[i].Start))
                       outPoints.Add(outLines[i].Start);
                   }
 
        }

        public override string ToString()
        {
            return "Convex Hull - Extreme Segments";
        }
    }
}
