using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApp1; // Важно: используем твой Point, Vector, Polygon

namespace UnitTestsProject
{
    [TestClass]
    public class PolygonTests
    {
        // Тест 1: Проверка периметра квадрата (успешный тест)
        [TestMethod]
        public void TestPerimeter_Square_ShouldBe12()
        {
            Point[] squarePoints = new Point[]
            {
                new Point(0,0),
                new Point(3,0),
                new Point(3,3),
                new Point(0,3)
            };

            Polygon polygon = new Polygon(squarePoints);
            double perimeter = polygon.Perimeter();
            Assert.AreEqual(12.0, perimeter, 0.01, "Периметр квадрата должен быть 12");
        }

        [TestMethod]
        public void TestIsConvexPolygon_NonConvex_ShouldBeFalse()
        {
            // Явно невыпуклый многоугольник (вогнутый)
            Point[] nonConvexPoints = new Point[]
            {
        new Point(0, 0),   // вершина 15555
        new Point(3, 0),   // вершина 2
        new Point(1, 1),   // вершина 3 - эта точка создает вогнутость
        new Point(3, 3),   // вершина 4
        new Point(0, 3)    // вершина 5
            };

            Polygon polygon = new Polygon(nonConvexPoints);
            bool isConvex = polygon.IsConvexPolygon();
            Assert.IsFalse(isConvex, "Многоугольник не является выпуклым");
        }

        // Тест 3: Проверка выпуклого треугольника
        [TestMethod]
        public void TestIsConvexPolygon_Triangle_ShouldBeTrue()
        {
            Point[] trianglePoints = new Point[]
            {
                new Point(0,0),
                new Point(1,0),
                new Point(0,1)
            };

            Polygon polygon = new Polygon(trianglePoints);
            bool isConvex = polygon.IsConvexPolygon();
            Assert.IsTrue(isConvex, "Треугольник всегда выпуклый");
        }
    }
}
