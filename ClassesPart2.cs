using System;
using System.Collections.Generic;
using Point;

namespace Point
{
    public struct Point3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public static readonly string point0 = "{0, 0, 0}";
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

        public int GetSize
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
                    string[] parts = reader.ReadLine().Split(' ');
                    if (parts.Length == 3 &&
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

    public class GenericList<T>
    {
        private T[] elements;
        private int size;

        public GenericList(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentException("Capacity must be greater than zero.");
            }

            elements = new T[capacity];
            size = 0;
        }

        private void AutoGrow()
        {
            int capacity = elements.Length * 2;
            T[] newElements = new T[capacity];

            for (int i = 0; i < size; i++)
            {
                newElements[i] = elements[i];
            }

            elements = newElements;
        }

        public int Size
        {
            get { return size; }
        }

        public T GetElementByIndex(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            return elements[index];
        }

        public void AddElement(T element)
        {
            if (size >= elements.Length)
            {
                AutoGrow();
            }

            elements[size++] = element;
        }

        public void RemoveElementAtIndex(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            for (int i = index; i < size - 1; i++)
            {
                elements[i] = elements[i + 1];
            }

            size--;
        }

        public void InsertElementByPosition(int index, T element)
        {
            if (index < 0 || index > size)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            if (size >= elements.Length)
            {
                AutoGrow();
            }

            for (int i = size; i > index; i--)
            {
                elements[i] = elements[i - 1];
            }

            elements[index] = element;
            size++;
        }

        public void ClearList()
        {
            size = 0;
        }

        public int GetIndexOf(T element)
        {
            for (int i = 0; i < size; i++)
            {
                if (Comparer<T>.Default.Compare(elements[i], element) == 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public override string ToString()
        {
            string str = "[";
            for (int i = 0; i < size; i++)
            {
                str += elements[i];
                if (i < size - 1)
                {
                    str += ", ";
                }
            }
            str += "]";
            return str;
        }

        public T GetMin()
        {
            int minElIndex = 0;

            if (elements.Length == 0)
            {
                throw new InvalidOperationException("The list is empty.");
            }

            for (int i = 0; i < size; i++)
            {
                if (Comparer<T>.Default.Compare(elements[i], elements[minElIndex]) < 0)
                {
                    minElIndex = i;
                }
            }

            return elements[minElIndex];
        }

        public T GetMax()
        {
            int maxElIndex = 0;

            if (elements.Length == 0)
            {
                throw new InvalidOperationException("The list is empty.");
            }

            for (int i = 0; i < size; i++)
            {
                if (Comparer<T>.Default.Compare(elements[i], elements[maxElIndex]) > 0)
                {
                    maxElIndex = i;
                }
            }

            return elements[maxElIndex];
        }
    }

    public class Matrix<T>
    {
        private T[,] matrix;

        public Matrix(int rows, int cols)
        {
            matrix = new T[rows, cols];
        }

        public T this[int row, int col]
        {
            get { return matrix[row, col]; }
            set { matrix[row, col] = value; }
        }

        public int Rows
        {
            get { return matrix.GetLength(0); }
        }

        public int Columns
        {
            get { return matrix.GetLength(1); }
        }

        public static Matrix<T> operator +(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
            {
                throw new InvalidOperationException("Matrix addition is only defined for matrices of the same size.");
            }

            int rows = matrix1.Rows;
            int cols = matrix1.Columns;

            Matrix<T> result = new Matrix<T>(rows, cols);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = (dynamic)matrix1[i, j] + (dynamic)matrix2[i, j];
                }
            }

            return result;
        }

        public static Matrix<T> operator -(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
            {
                throw new InvalidOperationException("Matrix subtraction is only defined for matrices of the same size.");
            }

            int rows = matrix1.Rows;
            int cols = matrix1.Columns;

            Matrix<T> result = new Matrix<T>(rows, cols);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = (dynamic)matrix1[i, j] - (dynamic)matrix2[i, j];
                }
            }

            return result;
        }

        public static Matrix<T> operator *(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            if (matrix1.Columns != matrix2.Rows)
            {
                throw new InvalidOperationException("Matrix multiplication is only defined when the number of columns in the first matrix equals the number of rows in the second matrix.");
            }

            int rows = matrix1.Rows;
            int cols = matrix2.Columns;

            Matrix<T> result = new Matrix<T>(rows, cols);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    for (int k = 0; k < matrix1.Columns; k++)
                    {
                        result[i, j] += (dynamic)matrix1[i, k] * (dynamic)matrix2[k, j];
                    }
                }
            }

            return result;
        }

        public bool IsNonZero()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (!EqualityComparer<T>.Default.Equals(matrix[i, j], default(T)))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    result += matrix[i, j] + " ";
                }
                result += Environment.NewLine;
            }
            return result;
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

            GenericList<int> intList = new GenericList<int>(5);
            intList.AddElement(10);
            intList.AddElement(20);
            intList.AddElement(5);

            Matrix<int> matrix1 = new Matrix<int>(2, 2);
            matrix1[0, 0] = 1;
            matrix1[0, 1] = 2;
            matrix1[1, 0] = 3;
            matrix1[1, 1] = 4;

            Matrix<int> matrix2 = new Matrix<int>(2, 2);
            matrix2[0, 0] = 5;
            matrix2[0, 1] = 6;
            matrix2[1, 0] = 7;
            matrix2[1, 1] = 8;

            Matrix<int> sumMatrix = matrix1 + matrix2;
            Console.WriteLine(sumMatrix);

            Matrix<int> differenceMatrix = matrix1 - matrix2;
            Console.WriteLine(differenceMatrix);

            Matrix<int> productMatrix = matrix1 * matrix2;
            Console.WriteLine(productMatrix);

            bool isNonZero = productMatrix.IsNonZero();
            Console.WriteLine(isNonZero);
        }
    }
}
