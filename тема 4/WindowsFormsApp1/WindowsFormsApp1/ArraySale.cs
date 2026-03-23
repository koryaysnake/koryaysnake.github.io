using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using WindowsFormsApp1;

public class ArraySale
{
    List<Sale> sales;
    string nameDiagram;

    public ArraySale()
    {
        sales = new List<Sale>();
        nameDiagram = "Динамика продаж за год";
    }

    public void Add(Sale s)
    {
        sales.Add(s);
    }

    public int Count
    {
        get { return sales.Count; }
    }

    public Sale this[int i]
    {
        get { return sales[i]; }
    }

    // Сохранение в файл
    public void SaveFile(string fileName)
    {
        StreamWriter sw = new StreamWriter(fileName);
        for (int i = 0; i < sales.Count; i++)
        {
            sw.WriteLine(sales[i].Month + ";" + sales[i].Value);
        }
        sw.Close();
    }

    // Загрузка из файла
    public void OpenFile(string fileName)
    {
        sales.Clear();
        StreamReader sr = new StreamReader(fileName);
        string line;

        while ((line = sr.ReadLine()) != null)
        {
            string[] parts = line.Split(';');
            sales.Add(new Sale(parts[0], Convert.ToDouble(parts[1])));
        }

        sr.Close();
    }

    // Построение графика
    public void Diagram(Chart chart)
    {
        chart.Series.Clear();
        chart.Titles.Clear();
        chart.Titles.Add(nameDiagram);

        Series series = new Series("Продажи");
        series.ChartType = SeriesChartType.Line;
        series.BorderWidth = 3;
        series.MarkerStyle = MarkerStyle.Circle;
        series.MarkerSize = 8;

        for (int i = 0; i < sales.Count; i++)
        {
            series.Points.AddXY(sales[i].Month, sales[i].Value);
        }

        chart.Series.Add(series);

        chart.ChartAreas[0].AxisX.Title = "Месяц";
        chart.ChartAreas[0].AxisY.Title = "Продажи";
    }
}
