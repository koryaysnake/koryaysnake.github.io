using System;

namespace WindowsFormsApp1
{
    public class Point
    {
        private double x;
        private double y;

        public Point()
        {
            x = 0;
            y = 0;
        }

        public Point(double X, double Y)
        {
            x = X;
            y = Y;
        }

        public Point(Point p)
        {
            x = p.x;
            y = p.y;
        }

        public double X { get { return x; } }
        public double Y { get { return y; } }

        public static bool Equals(Point p1, Point p2)
        {
            if (p1 == null || p2 == null)
                return false;
            
            return (p1.x == p2.x && p1.y == p2.y);
        }

        // ГЛАВНЫЙ МЕТОД
        public static double Distance(Point a, Point b)
        {
            return Math.Sqrt((b.x - a.x) * (b.x - a.x) +
                             (b.y - a.y) * (b.y - a.y));
        }
    }
}
