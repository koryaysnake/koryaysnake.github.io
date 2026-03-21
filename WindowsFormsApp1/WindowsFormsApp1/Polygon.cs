using System;

namespace WindowsFormsApp1
{
    public class Polygon
    {
        // Поле для хранения точек многоугольника
        private Point[] points;

        // Конструктор, принимающий массив точек
        public Polygon(Point[] points)
        {
            if (points == null)
                throw new ArgumentNullException(nameof(points), "Массив точек не может быть null");

            if (points.Length < 3)
                throw new ArgumentException("Многоугольник должен иметь хотя бы 3 точки", nameof(points));

            // Копируем массив, чтобы внешние изменения не влияли на многоугольник
            this.points = new Point[points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                this.points[i] = new Point(points[i]);
            }
        }

        // Метод для вычисления периметра
        public double Perimeter()
        {
            if (points == null || points.Length < 3)
                return 0;

            double perimeter = 0;
            int n = points.Length;

            for (int i = 0; i < n; i++)
            {
                Point p1 = points[i];
                Point p2 = points[(i + 1) % n]; // следующая точка, для последней - первая
                perimeter += Point.Distance(p1, p2);
            }

            return perimeter;
        }

        // Метод для проверки выпуклости многоугольника
        public bool IsConvexPolygon()
        {
            if (points == null || points.Length < 3)
                throw new InvalidOperationException("Многоугольник не инициализирован или имеет недостаточно точек");

            int n = points.Length;
            int sign = 0; // 0 - знак не определен, 1 - положительный, -1 - отрицательный

            for (int i = 0; i < n; i++)
            {
                // Берем три последовательные точки: предыдущую, текущую, следующую
                Point p1 = points[i];
                Point p2 = points[(i + 1) % n];
                Point p3 = points[(i + 2) % n];

                // Вычисляем векторное произведение (z-компоненту) для определения поворота
                double cross = CrossProduct(p1, p2, p3);

                // Если cross близко к 0, точки коллинеарны - пропускаем
                if (Math.Abs(cross) < 1e-10)
                    continue;

                int currentSign = cross > 0 ? 1 : -1;

                // Если знак еще не определен, запоминаем его
                if (sign == 0)
                {
                    sign = currentSign;
                }
                // Если знак изменился - многоугольник невыпуклый
                else if (currentSign != sign)
                {
                    return false;
                }
            }

            return true;
        }

        // Приватный метод для вычисления векторного произведения
        private double CrossProduct(Point p1, Point p2, Point p3)
        {
            // Векторы: p1->p2 и p2->p3
            double v1x = p2.X - p1.X;
            double v1y = p2.Y - p1.Y;
            double v2x = p3.X - p2.X;
            double v2y = p3.Y - p2.Y;

            // Векторное произведение (z-компонента)
            return v1x * v2y - v1y * v2x;
        }

        // Свойство для доступа к точкам (опционально)
        public Point[] Points
        {
            get
            {
                // Возвращаем копию, чтобы защитить данные
                Point[] copy = new Point[points.Length];
                for (int i = 0; i < points.Length; i++)
                {
                    copy[i] = new Point(points[i]);
                }
                return copy;
            }
        }

        // Количество вершин
        public int VertexCount
        {
            get { return points?.Length ?? 0; }
        }
    }
}