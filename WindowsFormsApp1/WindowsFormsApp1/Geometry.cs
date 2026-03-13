using System;
using System.Collections.Generic;
using System.IO; // Добавлено для работы с файлами
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    /// <summary>
    /// Класс для геометрических вычислений
    /// </summary>
    public class Geometry
    {
        /// <summary>
        /// Структура для представления точки на плоскости
        /// </summary>
        public struct Point
        {
            public double X { get; set; }
            public double Y { get; set; }

            public Point(double x, double y)
            {
                X = x;
                Y = y;
            }

            public override string ToString()
            {
                return $"({X:F2}; {Y:F2})";
            }
        }

        /// <summary>
        /// Вычисление расстояния между двумя точками
        /// </summary>
        public static double Distance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
        }

        /// <summary>
        /// Вычисление расстояния между двумя точками по координатам
        /// </summary>
        public static double Distance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        /// <summary>
        /// Проверка многоугольника на выпуклость
        /// </summary>
        public static bool IsConvexPolygon(Point[] points)
        {
            if (points.Length < 3)
                return false;

            int n = points.Length;
            bool? isPositive = null;

            for (int i = 0; i < n; i++)
            {
                Point p1 = points[i];
                Point p2 = points[(i + 1) % n];
                Point p3 = points[(i + 2) % n];

                // Вычисляем векторное произведение
                double crossProduct = (p2.X - p1.X) * (p3.Y - p2.Y) -
                                     (p2.Y - p1.Y) * (p3.X - p2.X);

                if (Math.Abs(crossProduct) < 1e-10) // Коллинеарные точки
                    continue;

                bool currentPositive = crossProduct > 0;

                if (isPositive == null)
                {
                    isPositive = currentPositive;
                }
                else if (isPositive != currentPositive)
                {
                    return false; // Знак изменился - многоугольник невыпуклый
                }
            }

            return true;
        }

        /// <summary>
        /// Вычисление периметра многоугольника
        /// </summary>
        public static double CalculatePerimeter(Point[] points)
        {
            if (points.Length < 3)
                throw new ArgumentException("Для вычисления периметра нужно минимум 3 точки");

            double perimeter = 0;

            for (int i = 0; i < points.Length; i++)
            {
                Point current = points[i];
                Point next = points[(i + 1) % points.Length]; // Замыкаем на первую точку
                perimeter += Distance(current, next);
            }

            return perimeter;
        }

        /// <summary>
        /// Чтение точек из файла
        /// </summary>
        public static Point[] ReadPointsFromFile(string filePath)
        {
            List<Point> points = new List<Point>();
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] parts = line.Trim().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length >= 2)
                {
                    if (double.TryParse(parts[0].Replace('.', ','), out double x) &&
                        double.TryParse(parts[1].Replace('.', ','), out double y))
                    {
                        points.Add(new Point(x, y));
                    }
                    else
                    {
                        throw new FormatException($"Не удалось распарсить строку: {line}");
                    }
                }
            }

            if (points.Count < 3)
                throw new ArgumentException("В файле должно быть минимум 3 точки");

            return points.ToArray();
        }
    }
}