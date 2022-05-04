using CGUtilities;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGAlgorithms.Algorithms.ConvexHull
{
   
    public class QuickHull : Algorithm
    {
        public List<Point> QH(Line L, List<Point> points)
        {
            if(points.Count==0)
                return new List<Point>();

            double area = 100;
            double line_len=100;
            double Orthognal_dist = 0;
            double Best_Orthognal_dist = 0;
            int best_Point_indx = 0;

            for (int i = 0; i < points.Count; i++)
            {
                Point v1 = HelperMethods.GetVector(new Line(points[i], L.Start));
                Point v2 = HelperMethods.GetVector(new Line(points[i], L.End));

                 area = HelperMethods.CrossProduct(v1,v2);
                 line_len = Math.Sqrt(Math.Pow(L.Start.X - L.End.X, 2) + Math.Pow(L.Start.Y - L.End.Y, 2));
                 Orthognal_dist = area / line_len;

                 if (Orthognal_dist > Best_Orthognal_dist)
                {
                    Best_Orthognal_dist = Orthognal_dist;
                    best_Point_indx = i;
                }
            }
                
                Enums.TurnType T1, T2;
                List<Point> Left_p = new List<Point>();
                List<Point> Right_p = new List<Point>();

                List<Point> Left_side_res = new List<Point>();
                List<Point> Right_side_res = new List<Point>();

                T1=HelperMethods.CheckTurn(L.Start.Vector(L.End), L.End.Vector(points[best_Point_indx]));
                T2=HelperMethods.CheckTurn(L.End.Vector(L.Start), L.Start.Vector(points[best_Point_indx]));
                if (Enums.TurnType.Left == T1 && Enums.TurnType.Right == T2)
                {
                    for (int k = 0; k < points.Count; k++)
                    {
                        if (Enums.TurnType.Right == HelperMethods.CheckTurn(new Line(L.End, points[best_Point_indx]), points[k]))
                        {
                            Right_p.Add(points[k]);
                        }

                        if (Enums.TurnType.Left == HelperMethods.CheckTurn(new Line(L.Start, points[best_Point_indx]), points[k]))
                        {
                            Left_p.Add(points[k]);
                        }

                    }
                    if(Right_p.Count>0)
                        Right_side_res = QH(new Line(L.End, points[best_Point_indx]), Right_p);
                    if (Left_p.Count > 0)
                        Left_side_res = QH(new Line(L.Start, points[best_Point_indx]), Left_p);
                    
                }
                else if (Enums.TurnType.Left == T2 && Enums.TurnType.Right == T1)
                {
                    for (int k = 0; k < points.Count; k++)
                    {

                        if (HelperMethods.PointInTriangle(points[k], L.Start, L.End, points[best_Point_indx]) != Enums.PointInPolygon.Outside)
                            continue;

                        if (Enums.TurnType.Right == HelperMethods.CheckTurn(new Line(L.End, points[best_Point_indx]), points[k]))
                        {
                            Left_p.Add(points[k]);
                        }

                        if (Enums.TurnType.Left == HelperMethods.CheckTurn(new Line(L.Start, points[best_Point_indx]), points[k]))
                        {
                            Right_p.Add(points[k]);
                        }

                    }
                    List<KeyValuePair<int, double>> AngelList = new List<KeyValuePair<int, double>>();
                    Left_side_res = QH(new Line(L.End, points[best_Point_indx]), Left_p);
                    Right_side_res = QH(new Line(L.Start, points[best_Point_indx]), Right_p);
               
                }

        List<Point> final = new List<Point>();
        final.Add(points[best_Point_indx]);
         
            if(Right_side_res.Count>0)
            {  for(int i =0;i<Right_side_res.Count;i++)
                {
                final.Add(Right_side_res[i]);
                } 
            }
            if (Left_side_res.Count > 0)
            {
                for (int i = 0; i < Left_side_res.Count; i++)
                {
                    final.Add(Left_side_res[i]);
                }
            }
            return final;
        }
        public override void Run(List<Point> points, List<Line> lines, List<Polygon> polygons, ref List<Point> outPoints, ref List<Line> outLines, ref List<Polygon> outPolygons)
        {
/*
               List<KeyValuePair<int, double>> Finding_Angle = new List<KeyValuePair<int, double>>();
       KeyValuePair<int, double> pia = new KeyValuePair<int, double>(1,1);
        
        Finding_Angle.Add(pia);
        Finding_Angle.Add(new KeyValuePair<int, double>(2,14));
        List<KeyValuePair<int, double>> Sorted_Angle = Finding_Angle.OrderByDescending(p => p.Value).ToList();
     */

            List<Point> res = new List<Point>();
           // List<Point> psx = new List<Point>();
           // List<Point> psy = new List<Point>();

           
            List<Point> psx = new List<Point>();
            List<Point> psy = new List<Point>();

            List<Point> Half1 = new List<Point>();
            List<Point> Half2 = new List<Point>();
          
         /*   for(int i=0;i<points.Count;i++)
            {
             psx.Add(points[i]);
             psx.Add(points[i]);
            }*/
            
                psx = points.OrderByDescending(p => p.X).ToList();
                psy = points.OrderByDescending(p => p.Y).ToList();
            
        
            Line L = new Line(psx[0], psx[psx.Count - 1]);
            for (int k = 0; k < points.Count; k++)
            {

                if (Enums.TurnType.Right == HelperMethods.CheckTurn(L, points[k]))
                {
                    Half1.Add(psy[k]);
                }

                if (Enums.TurnType.Left == HelperMethods.CheckTurn(L.Start, points[k]))
                {
                    Half2.Add(psy[k]);
                }

            }
          

            List<Point> Half1_res = QH(L, Half1);

            List<Point> Half2_res = QH(L, Half2);

            res.Add(L.Start);
            res.Add(L.End);
            for (int i = 0; i < Half1_res.Count; i++)
            {
                res.Add(Half1_res[i]);
            } 
            for (int i = 0; i < Half2_res.Count; i++)
            {
                res.Add(Half2_res[i]);
            }

           for (int i = 0; i < res.Count; i++)
            {
                outPoints.Add(res[i]);
            }
        
        }

        public override string ToString()
        {
            return "Convex Hull - Quick Hull";
        }
    }
}
