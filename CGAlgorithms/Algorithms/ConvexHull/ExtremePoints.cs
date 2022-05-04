using CGUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGAlgorithms.Algorithms.ConvexHull
{
    public class ExtremePoints : Algorithm
    {
        public override void Run(List<Point> points, List<Line> lines, List<Polygon> polygons, ref List<Point> outPoints, ref List<Line> outLines, ref List<Polygon> outPolygons)
        {
            //
          /*  List<Point> inputPoints = new List<Point>();
            inputPoints.Add(new Point(20, -20));
            inputPoints.Add(new Point(100, 100));
            inputPoints.Add(new Point(0, 0));
            inputPoints.Add(new Point(100, -100));
            inputPoints.Add(new Point(100, 0));
            inputPoints.Add(new Point(-100, -100));
            inputPoints.Add(new Point(0, -100));
            inputPoints.Add(new Point(50, 20));
            inputPoints.Add(new Point(90, -90));
            inputPoints.Add(new Point(-100, -100));
            
            foreach (Point P in inputPoints)
                points.Add(P);*/

            //
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
                                { avaliable[i] = false;change=1; }
                                if (distki > distjk && distki > distij)
                                { avaliable[j] = false; change = 1; }

                            }
                        }
                    }
                }

            }

            for (int i = 0; i < points.Count; i++)
            {
                if (!avaliable[i])
                    continue;
                for (int j = 0; j < points.Count; j++)
                {
                    
                    if (!avaliable[j])
                        continue;

                    if (j == i)
                    {
                        continue;
                    }
                    int k = 0;
                    for (; k < points.Count; k++)
                    {
                       

                        if (!avaliable[k])
                            continue;
                        if (k == i || k ==j)
                            continue;

                       /* if (HelperMethods.PointOnRay(points[i], points[j], points[k]))
                        {
                            double distij = Math.Sqrt(Math.Pow(points[i].X - points[j].X, 2) + Math.Pow(points[i].Y - points[j].Y, 2));
                            double distjk = Math.Sqrt(Math.Pow(points[k].X - points[j].X, 2) + Math.Pow(points[k].Y - points[j].Y, 2));
                            double distki = Math.Sqrt(Math.Pow(points[i].X - points[k].X, 2) + Math.Pow(points[i].Y - points[k].Y, 2));

                            if (distij > distjk && distij > distki)
                            { avaliable[k] = false; }
                            if (distjk > distij && distjk > distki)
                            { avaliable[i] = false; }
                            if (distki > distjk && distki > distij)
                            { avaliable[j] = false; }

                        }*/
                        for (int it = 0; it < points.Count; it++)
                        {
                            if (!avaliable[it])
                                continue;

                            if (it == k || it == j || it == i)
                            { continue; }

                            if (Enums.PointInPolygon.Inside == HelperMethods.PointInTriangle(points[it], points[i], points[j], points[k]))
                                avaliable[it] = false;
                            if (Enums.PointInPolygon.OnEdge == HelperMethods.PointInTriangle(points[it], points[i], points[j], points[k]))
                                avaliable[it] = false;
                        }

                    }

                }
            
            }

            for (int i = 0; i < avaliable.Count; i++)
            {
                if (avaliable[i] && !outPoints.Contains(points[i]))
                    outPoints.Add(points[i]);
            }
        
    }

        public override string ToString()
        {
            return "Convex Hull - Extreme Points";
        }
    }
}
