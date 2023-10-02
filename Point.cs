using System;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection;

namespace Point
{
    public struct Point3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public const string point0 = "{0, 0, 0}";
        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString()
        {
            return $"{{{X}, {Y}, {Z}}}";
        }
    }

    public static class Distance
    {
        public static double GetDistance(Point3D pointA, Point3D pointB)
        {
            return Math.Sqrt(Math.Pow(pointB.X - pointA.X, 2) + Math.Pow(pointB.Y - pointA.Y, 2) + Math.Pow(pointB.Z - pointA.Z, 2));
        }
    }

    public class Path
    {
        private List<Point3D> points;

        public Path()
        {
            points = new List<Point3D>();
        }

        public void AddPointToPath(Point3D point)
        {
            points.Add(point);
        }

        public int Size
        {
            get { return points.Count; }
        }

        public List<Point3D> Points
        {
            get { return points; }
        }

        public override string ToString()
        {
            return string.Join(" ", points);
        }
    }

    public static class PathStorage
    {
        public static void SavePathToFile(Path path, string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (Point3D point in path.Points)
                {
                    writer.WriteLine($"{point.X} {point.Y} {point.Z}");
                }
            }
        }

        public static Path LoadPathFromFile(string fileName)
        {
            Path path = new Path();
            using (StreamReader reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    const int countOfElements = 3;
                    string[] parts = reader.ReadLine().Split(' ');
                    if (parts.Length == countOfElements &&
                        double.TryParse(parts[0], out double x) &&
                        double.TryParse(parts[1], out double y) &&
                        double.TryParse(parts[2], out double z))
                    {
                        Point3D point = new Point3D { X = x, Y = y, Z = z };
                        path.AddPointToPath(point);
                    }
                }
            }
            return path;
        }
    }


    public class Program
    {
        static void Main(string[] args)
        {
            Point3D pointA = new Point3D(2, 2, 3);
            Point3D pointB = new Point3D(1, 4, 6);

            Path path = new Path();

            path.AddPointToPath(pointA);
            path.AddPointToPath(pointB);

            Console.WriteLine(path.ToString());

            Console.WriteLine(Distance.GetDistance(pointA, pointB));

            PathStorage.SavePathToFile(path, "text.txt");
        }
    }
}
