// using System;
// using System.Collections.Generic;
// using System.Numerics;
// using System.Reflection;

// namespace GenericType
// {
//     public class Matrix<T> where T: struct
//     {
//         private T[,] matrix;

//         public Matrix(int rows, int cols)
//         {
//             matrix = new T[rows, cols];
//         }

//         public T this[int row, int col]
//         {
//             get { return matrix[row, col]; }
//             set { matrix[row, col] = value; }
//         }

//         public int Rows
//         {
//             get { return matrix.GetLength(0); }
//         }

//         public int Columns
//         {
//             get { return matrix.GetLength(1); }
//         }

//         public static Matrix<T> operator +(Matrix<T> matrix1, Matrix<T> matrix2)
//         {
//             if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
//             {
//                 throw new InvalidOperationException("Matrix addition is only defined for matrices of the same size.");
//             }

//             int rows = matrix1.Rows;
//             int cols = matrix1.Columns;

//             for (int i = 0; i < rows; i++)
//             {
//                 for (int j = 0; j < cols; j++)
//                 {
//                     matrix1[i, j] += (dynamic)matrix2[i, j];
//                 }
//             }

//             return matrix1;
//         }

//         public static Matrix<T> operator -(Matrix<T> matrix1, Matrix<T> matrix2)
//         {
//             if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
//             {
//                 throw new InvalidOperationException("Matrix subtraction is only defined for matrices of the same size.");
//             }

//             int rows = matrix1.Rows;
//             int cols = matrix1.Columns;

//             for (int i = 0; i < rows; i++)
//             {
//                 for (int j = 0; j < cols; j++)
//                 {
//                     matrix1[i, j] -= (dynamic)matrix2[i, j];
//                 }
//             }

//             return matrix1;
//         }

//         public static Matrix<T> operator *(Matrix<T> matrix1, Matrix<T> matrix2)
//         {
//             if (matrix1.Columns != matrix2.Rows)
//             {
//                 throw new InvalidOperationException("Number of columns in the first matrix must be equals the number of rows in the second matrix.");
//             }

//             int rows = matrix1.Rows;
//             int cols = matrix2.Columns;

//             Matrix<T> result = new Matrix<T>(rows, cols);

//             for (int i = 0; i < rows; i++)
//             {
//                 for (int j = 0; j < cols; j++)
//                 {
//                     for (int k = 0; k < matrix1.Columns; k++)
//                     {
//                         result[i, j] += (dynamic)matrix1[i, j] * (dynamic)matrix2[i, j];
//                     }
//                 }
//             }
//             return result;
//         }

//         public bool IsNonZero()
//         {
//             for (int i = 0; i < matrix.GetLength(0); i++)
//             {
//                 for (int j = 0; j < matrix.GetLength(1); j++)
//                 {
//                     if (!EqualityComparer<T>.Default.Equals(matrix[i, j], default(T)))
//                     {
//                         return true;
//                     }
//                 }
//             }
//             return false;
//         }

//         public override string ToString()
//         {
//             string result = "";
//             for (int i = 0; i < matrix.GetLength(0); i++)
//             {
//                 for (int j = 0; j < matrix.GetLength(1); j++)
//                 {
//                     result += matrix[i, j] + " ";
//                 }
//                 result += Environment.NewLine;
//             }
//             return result;
//         }
//     }

//     [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface | AttributeTargets.Enum | AttributeTargets.Method)]
//     public class VersionAttribute : Attribute
//     {
//         public string Version { get; }

//         public VersionAttribute(string version)
//         {
//             Version = version;
//         }
//     }

//     [Version("2.11")]
//     public class SampleClass
//     {

//     }

//     public class Program
//     {
//         static void Main(string[] args)
//         {
//             GenericList<int> intList = new GenericList<int>(5);
//             intList.AddElement(10);
//             intList.AddElement(20);
//             intList.AddElement(5);

//             Matrix<int> matrix1 = new Matrix<int>(2, 2);
//             matrix1[0, 0] = 1;
//             matrix1[0, 1] = 2;
//             matrix1[1, 0] = 3;
//             matrix1[1, 1] = 4;

//             Matrix<int> matrix2 = new Matrix<int>(2, 2);
//             matrix2[0, 0] = 5;
//             matrix2[0, 1] = 6;
//             matrix2[1, 0] = 7;
//             matrix2[1, 1] = 8;

//             Matrix<int> sumMatrix = matrix1 + matrix2;
//             Console.WriteLine(sumMatrix);

//             Matrix<int> differenceMatrix = matrix1 - matrix2;
//             Console.WriteLine(differenceMatrix);

//             Matrix<int> productMatrix = matrix1 * matrix2;
//             Console.WriteLine(productMatrix);


//             bool isNonZero = productMatrix.IsNonZero();
//             Console.WriteLine(isNonZero);

//             Type type = typeof(SampleClass);
//             var versionAttribute = type.GetCustomAttribute<VersionAttribute>();

//             Console.WriteLine(versionAttribute.Version);

//         }
//     }
// }