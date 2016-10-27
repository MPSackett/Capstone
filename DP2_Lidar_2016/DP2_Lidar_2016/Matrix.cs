#region Assembly Accord.Math, Version=3.0.2.0, Culture=neutral, PublicKeyToken=fa1a88e29555ccf7
// C:\Users\Capstone 2015\Documents\Visual Studio 2015\Projects\DP2_Lidar_2016\packages\Accord.Math.3.0.2\lib\net45\Accord.Math.dll
#endregion

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Accord.Math.Comparers;
using AForge.Math.Random;

namespace Accord.Math
{
    //
    // Summary:
    //     Static class Matrix. Defines a set of extension methods that operates mainly
    //     on multidimensional arrays and vectors.
    //
    // Remarks:
    //     The matrix class is a static class containing several extension methods. To use
    //     this class, import the Accord.Math and use the standard .NET's matrices and jagged
    //     arrays. When you call the dot (.) operator on those classes, the extension methods
    //     offered by this class should become available through IntelliSense auto-complete.
    public static class Matrix
    {
        //
        // Summary:
        //     Elementwise absolute value.
        public static double[,] Abs(this double[,] value);
        //
        // Summary:
        //     Elementwise absolute value.
        public static double[] Abs(this double[] value);
        //
        // Summary:
        //     Elementwise absolute value.
        public static int[,] Abs(this int[,] value);
        //
        // Summary:
        //     Elementwise absolute value.
        public static int[] Abs(this int[] value);
        //
        // Summary:
        //     Subtracts a scalar to each element of a matrix.
        public static double[,] Add(this double x, double[,] matrix);
        //
        // Summary:
        //     Adds a matrix and a scalar.
        //
        // Parameters:
        //   a:
        //     A matrix.
        //
        //   x:
        //     A scalar.
        //
        // Returns:
        //     The sum of the given matrix and scalar.
        public static double[][] Add(this double[][] a, double x);
        //
        // Summary:
        //     Adds two matrices.
        //
        // Parameters:
        //   a:
        //     A matrix.
        //
        //   b:
        //     A matrix.
        //
        // Returns:
        //     The sum of the given matrices.
        public static double[][] Add(this double[][] a, double[][] b);
        //
        // Summary:
        //     Adds two matrices.
        //
        // Parameters:
        //   a:
        //     A matrix.
        //
        //   b:
        //     A matrix.
        //
        // Returns:
        //     The sum of the given matrices.
        public static double[,] Add(this double[,] a, double[,] b);
        //
        // Summary:
        //     Adds two vectors.
        //
        // Parameters:
        //   a:
        //     A vector.
        //
        //   b:
        //     A vector.
        //
        // Returns:
        //     The addition of the given vectors.
        public static double[] Add(this double[] a, double b);
        //
        // Summary:
        //     Adds two vectors.
        //
        // Parameters:
        //   a:
        //     A vector.
        //
        //   b:
        //     A vector.
        //
        // Returns:
        //     The addition of the given vectors.
        public static double[] Add(this double[] a, double[] b);
        //
        // Summary:
        //     Adds a scalar to each element of a matrix.
        public static double[,] Add(this double[,] matrix, double x);
        //
        // Summary:
        //     Adds a vector to a column or row of a matrix.
        //
        // Parameters:
        //   matrix:
        //     A matrix.
        //
        //   vector:
        //     A vector.
        //
        //   dimension:
        //     Pass 0 if the vector should be added row-wise, or 1 if the vector should be added
        //     column-wise.
        public static double[,] Add(this double[,] matrix, double[] vector, int dimension);
        //
        // Summary:
        //     Adds a scalar to the diagonal of a matrix.
        //
        // Parameters:
        //   matrix:
        //     A matrix.
        //
        //   scalar:
        //     A scalar.
        //
        //   inPlace:
        //     True to perform the operation in-place, overwriting the original matrix; false
        //     to return a new matrix.
        public static double[][] AddToDiagonal(this double[][] matrix, double scalar, bool inPlace = false);
        //
        // Summary:
        //     Adds a scalar to the diagonal of a matrix.
        //
        // Parameters:
        //   matrix:
        //     A matrix.
        //
        //   scalar:
        //     A scalar.
        //
        //   inPlace:
        //     True to perform the operation in-place, overwriting the original matrix; false
        //     to return a new matrix.
        public static double[,] AddToDiagonal(this double[,] matrix, double scalar, bool inPlace = false);
        //
        // Summary:
        //     Applies a function to every element of the array.
        public static TResult[] Apply<TData, TResult>(this IList<TData> vector, Func<TData, TResult> func);
        //
        // Summary:
        //     Applies a function to every element of a matrix.
        public static TResult[,] Apply<TData, TResult>(this TData[,] matrix, Func<TData, TResult> func);
        //
        // Summary:
        //     Applies a function to every element of the array.
        public static TResult[] Apply<TData, TResult>(this TData[] vector, Func<TData, TResult> func);
        //
        // Summary:
        //     Applies a function to every element of a matrix.
        public static void ApplyInPlace<T>(this T[,] matrix, Func<T, int, int, T> func);
        //
        // Summary:
        //     Applies a function to every element of a matrix.
        public static void ApplyInPlace<T>(this T[,] matrix, Func<T, T> func);
        //
        // Summary:
        //     Applies a function to every element of the array.
        public static void ApplyInPlace<T>(this T[] vector, Func<T, int, T> func);
        //
        // Summary:
        //     Applies a function to every element of the array.
        public static void ApplyInPlace<T>(this T[] vector, Func<T, T> func);
        //
        // Summary:
        //     Applies a function to every element of a matrix.
        public static TResult[,] ApplyWithIndex<TData, TResult>(this TData[,] matrix, Func<TData, int, int, TResult> func);
        //
        // Summary:
        //     Applies a function to every element of the array.
        public static TResult[] ApplyWithIndex<TData, TResult>(this TData[] vector, Func<TData, int, TResult> func);
        //
        // Summary:
        //     Retrieves the bottom count values of an array.
        public static int[] Bottom<T>(this T[] values, int count, bool inPlace = false) where T : IComparable;
        //
        // Summary:
        //     Computes the Cartesian product of many sets.
        public static T[][] CartesianProduct<T>(params T[][] sequences);
        //
        // Summary:
        //     Computes the Cartesian product of many sets.
        //
        // Remarks:
        //     References: - http://blogs.msdn.com/b/ericlippert/archive/2010/06/28/computing-a-Cartesian-product-with-linq.aspx
        public static IEnumerable<IEnumerable<T>> CartesianProduct<T>(this IEnumerable<IEnumerable<T>> sequences);
        //
        // Summary:
        //     Computes the Cartesian product of two sets.
        public static T[][] CartesianProduct<T>(this T[] sequence1, T[] sequence2);
        //
        // Summary:
        //     Returns the largest integer greater than or equal than to the specified double-precision
        //     floating-point number for each element of the array.
        public static double[] Ceiling(double[] vector);
        //
        // Summary:
        //     Returns the largest integer greater than or equal than to the specified double-precision
        //     floating-point number for each element of the matrix.
        public static double[,] Ceiling(this double[,] matrix);
        //
        // Summary:
        //     Creates a centering matrix of size N x N in the form (I - 1N) where 1N is a matrix
        //     with all elements equal to 1 / N.
        public static double[,] Centering(int size);
        //
        // Summary:
        //     Gets the number of columns in a jagged matrix.
        //
        // Parameters:
        //   matrix:
        //     The matrix whose number of columns must be computed.
        //
        // Type parameters:
        //   T:
        //     The type of the elements in the matrix.
        //
        // Returns:
        //     The number of columns in the matrix.
        public static int Columns<T>(this T[][] matrix);
        //
        // Summary:
        //     Gets the number of columns in a multidimensional matrix.
        //
        // Parameters:
        //   matrix:
        //     The matrix whose number of columns must be computed.
        //
        // Type parameters:
        //   T:
        //     The type of the elements in the matrix.
        //
        // Returns:
        //     The number of columns in the matrix.
        public static int Columns<T>(this T[,] matrix);
        //
        // Summary:
        //     Creates a matrix with a single column vector.
        public static T[,] ColumnVector<T>(params T[] values);
        //
        // Summary:
        //     Combines a matrix and a vector horizontally.
        public static T[][] Concatenate<T>(params T[][][] matrices);
        //
        // Summary:
        //     Combine vectors horizontally.
        public static T[] Concatenate<T>(this T[][] vectors);
        //
        // Summary:
        //     Combines a matrix and a vector horizontally.
        public static T[,] Concatenate<T>(params T[][,] matrices);
        //
        // Summary:
        //     Combines a vector and a element horizontally.
        public static T[] Concatenate<T>(this T[] vector, T element);
        //
        // Summary:
        //     Combines two matrices horizontally.
        public static T[][] Concatenate<T>(this T[][] a, T[][] b);
        //
        // Summary:
        //     Combines two matrices horizontally.
        public static T[,] Concatenate<T>(this T[,] a, T[,] b);
        //
        // Summary:
        //     Combines a matrix and a vector horizontally.
        public static T[,] Concatenate<T>(this T[,] matrix, T[] vector);
        //
        // Summary:
        //     Combines a vector and a element horizontally.
        public static T[] Concatenate<T>(this T element, T[] vector);
        //
        // Summary:
        //     Combines two vectors horizontally.
        public static T[] Concatenate<T>(this T[] a, T[] b);
        //
        // Summary:
        //     Converts the values of a matrix using the given converter expression.
        //
        // Parameters:
        //   matrix:
        //     The vector to be converted.
        //
        //   converter:
        //     The converter function.
        //
        // Type parameters:
        //   TInput:
        //     The type of the input.
        //
        //   TOutput:
        //     The type of the output.
        public static TOutput[,] Convert<TInput, TOutput>(this TInput[,] matrix, Converter<TInput, TOutput> converter);
        //
        // Summary:
        //     Converts the values of a matrix using the given converter expression.
        //
        // Parameters:
        //   matrix:
        //     The matrix to be converted.
        //
        //   converter:
        //     The converter function.
        //
        // Type parameters:
        //   TInput:
        //     The type of the input.
        //
        //   TOutput:
        //     The type of the output.
        public static TOutput[][] Convert<TInput, TOutput>(this TInput[][] matrix, Converter<TInput, TOutput> converter);
        //
        // Summary:
        //     Converts the values of a vector using the given converter expression.
        //
        // Parameters:
        //   vector:
        //     The vector to be converted.
        //
        //   converter:
        //     The converter function.
        //
        // Type parameters:
        //   TInput:
        //     The type of the input.
        //
        //   TOutput:
        //     The type of the output.
        public static TOutput[] Convert<TInput, TOutput>(this TInput[] vector, Converter<TInput, TOutput> converter);
        //
        // Summary:
        //     Convolves an array with the given kernel.
        //
        // Parameters:
        //   a:
        //     A floating number array.
        //
        //   kernel:
        //     A convolution kernel.
        public static double[] Convolve(this double[] a, double[] kernel);
        //
        // Summary:
        //     Convolves an array with the given kernel.
        //
        // Parameters:
        //   a:
        //     A floating number array.
        //
        //   kernel:
        //     A convolution kernel.
        //
        //   trim:
        //     If true the resulting array will be trimmed to have the same length as the input
        //     array. Default is false.
        public static double[] Convolve(this double[] a, double[] kernel, bool trim);
        //
        // Summary:
        //     Gets the number of elements matching a certain criteria.
        //
        // Parameters:
        //   data:
        //     The array to search inside.
        //
        //   func:
        //     The search criteria.
        //
        // Type parameters:
        //   T:
        //     The type of the array.
        public static int Count<T>(this T[] data, Func<T, bool> func);
        //
        // Summary:
        //     Returns a new multidimensional matrix.
        public static T[,] Create<T>(int size);
        //
        // Summary:
        //     Returns a new multidimensional matrix.
        public static T[,] Create<T>(int rows, int cols);
        //
        // Summary:
        //     Returns a matrix with all elements set to a given value.
        public static T[,] Create<T>(int size, T value);
        //
        // Summary:
        //     Returns a matrix with all elements set to a given value.
        public static T[,] Create<T>(int rows, int cols, T value);
        //
        // Summary:
        //     Calculates a vector cumulative sum.
        public static double[] CumulativeSum(this double[] vector);
        //
        // Summary:
        //     Calculates the matrix Sum vector.
        //
        // Parameters:
        //   matrix:
        //     A matrix whose sums will be calculated.
        //
        //   dimension:
        //     The dimension in which the cumulative sum will be calculated.
        //
        // Returns:
        //     Returns a vector containing the sums of each variable in the given matrix.
        public static double[][] CumulativeSum(this double[,] matrix, int dimension);
        //
        // Summary:
        //     Gets the determinant of a matrix.
        public static double Determinant(this double[,] matrix);
        //
        // Summary:
        //     Gets the determinant of a matrix.
        public static double Determinant(this double[,] matrix, bool symmetric);
        //
        // Summary:
        //     Gets the diagonal vector from a matrix.
        //
        // Parameters:
        //   matrix:
        //     A matrix.
        //
        // Returns:
        //     The diagonal vector from the given matrix.
        public static T[] Diagonal<T>(this T[,] matrix);
        //
        // Summary:
        //     Gets the diagonal vector from a matrix.
        //
        // Parameters:
        //   matrix:
        //     A matrix.
        //
        // Returns:
        //     The diagonal vector from the given matrix.
        public static T[] Diagonal<T>(this T[][] matrix);
        //
        // Summary:
        //     Return a square matrix with a vector of values on its diagonal.
        public static T[,] Diagonal<T>(T[] values);
        //
        // Summary:
        //     Return a square matrix with a vector of values on its diagonal.
        public static T[,] Diagonal<T>(int size, T[] values);
        //
        // Summary:
        //     Returns a square diagonal matrix of the given size.
        public static T[,] Diagonal<T>(int size, T value);
        //
        // Summary:
        //     Returns a matrix with a vector of values on its diagonal.
        public static T[,] Diagonal<T>(int rows, int cols, T[] values);
        //
        // Summary:
        //     Returns a matrix of the given size with value on its diagonal.
        public static T[,] Diagonal<T>(int rows, int cols, T value);
        //
        // Summary:
        //     Retrieves only distinct values contained in an array.
        //
        // Parameters:
        //   values:
        //     The array.
        //
        // Returns:
        //     An array containing only the distinct values in values.
        public static T[] Distinct<T>(this T[] values);
        //
        // Summary:
        //     Retrieves a list of the distinct values for each matrix column.
        //
        // Parameters:
        //   values:
        //     The matrix.
        //
        // Returns:
        //     An array containing arrays of distinct values for each column in the values.
        public static T[][] Distinct<T>(this T[][] values);
        //
        // Summary:
        //     Retrieves a list of the distinct values for each matrix column.
        //
        // Parameters:
        //   values:
        //     The matrix.
        //
        // Returns:
        //     An array containing arrays of distinct values for each column in the values.
        public static T[][] Distinct<T>(this T[,] values);
        //
        // Summary:
        //     Retrieves only distinct values contained in an array.
        //
        // Parameters:
        //   values:
        //     The array.
        //
        //   allowNulls:
        //     Whether to allow null values in the method's output. Default is true.
        //
        // Returns:
        //     An array containing only the distinct values in values.
        public static T[] Distinct<T>(this T[] values, bool allowNulls) where T : class;
        //
        // Summary:
        //     Retrieves only distinct values contained in an array.
        //
        // Parameters:
        //   values:
        //     The array.
        //
        //   property:
        //     The property of the object used to determine distinct instances.
        //
        // Returns:
        //     An array containing only the distinct values in values.
        public static T[] Distinct<T, TProperty>(this T[] values, Func<T, TProperty> property) where TProperty : IComparable<TProperty>;
        //
        // Summary:
        //     Divides a vector by a scalar.
        //
        // Parameters:
        //   vector:
        //     A vector.
        //
        //   x:
        //     A scalar.
        //
        // Returns:
        //     The division quotient of the given vector a and scalar b.
        public static float[] Divide(this float[] vector, float x);
        //
        // Summary:
        //     Divides two matrices by multiplying A by the inverse of B.
        //
        // Parameters:
        //   a:
        //     The first matrix.
        //
        //   b:
        //     The second matrix (which will be inverted).
        //
        // Returns:
        //     The result from the division AB^-1 of the given matrices.
        public static double[,] Divide(this double[,] a, double[,] b);
        //
        // Summary:
        //     Elementwise divides a scalar by a matrix.
        //
        // Parameters:
        //   x:
        //     A scalar.
        //
        //   matrix:
        //     A matrix.
        //
        // Returns:
        //     The elementwise division of the given scalar and matrix.
        public static double[,] Divide(this int x, double[,] matrix);
        //
        // Summary:
        //     Elementwise divides a scalar by a matrix.
        //
        // Parameters:
        //   x:
        //     A scalar.
        //
        //   matrix:
        //     A matrix.
        //
        // Returns:
        //     The elementwise division of the given scalar and matrix.
        public static double[,] Divide(this double x, double[,] matrix);
        //
        // Summary:
        //     Divides a matrix by a scalar.
        //
        // Parameters:
        //   matrix:
        //     A matrix.
        //
        //   x:
        //     A scalar.
        //
        // Returns:
        //     The division quotient of the given matrix and scalar.
        public static float[,] Divide(this uint[,] matrix, float x);
        //
        // Summary:
        //     Elementwise divides a scalar by a vector.
        //
        // Parameters:
        //   vector:
        //     A vector.
        //
        //   x:
        //     A scalar.
        //
        // Returns:
        //     The division quotient of the given scalar a and vector b.
        public static double[] Divide(this double x, double[] vector);
        //
        // Summary:
        //     Divides a vector by a scalar.
        //
        // Parameters:
        //   vector:
        //     A vector.
        //
        //   x:
        //     A scalar.
        //
        // Returns:
        //     The division quotient of the given vector a and scalar b.
        public static double[] Divide(this int[] vector, double x);
        //
        // Summary:
        //     Divides a scalar by a vector.
        //
        // Parameters:
        //   vector:
        //     A vector.
        //
        //   x:
        //     A scalar.
        //
        //   inPlace:
        //     True to perform the operation in-place, overwriting the original array; false
        //     to return a new array.
        //
        // Returns:
        //     The division quotient of the given vector a and scalar b.
        public static double[] Divide(this int x, double[] vector, bool inPlace = false);
        //
        // Summary:
        //     Divides a vector by a scalar.
        //
        // Parameters:
        //   vector:
        //     A vector.
        //
        //   x:
        //     A scalar.
        //
        //   inPlace:
        //     True to perform the operation in-place, overwriting the original array; false
        //     to return a new array.
        //
        // Returns:
        //     The division quotient of the given vector a and scalar b.
        public static double[] Divide(this double[] vector, double x, bool inPlace = false);
        //
        // Summary:
        //     Divides a matrix by a scalar.
        //
        // Parameters:
        //   matrix:
        //     A matrix.
        //
        //   x:
        //     A scalar.
        //
        //   inPlace:
        //     True to perform the operation in-place, overwriting the original matrix; false
        //     to return a new matrix.
        //
        // Returns:
        //     The division quotient of the given matrix and scalar.
        public static double[,] Divide(this double[,] matrix, double x, bool inPlace = false);
        //
        // Summary:
        //     Divides a scalar by a vector.
        //
        // Parameters:
        //   vector:
        //     A vector.
        //
        //   x:
        //     A scalar.
        //
        //   inPlace:
        //     True to perform the operation in-place, overwriting the original array; false
        //     to return a new array.
        //
        // Returns:
        //     The division quotient of the given vector a and scalar b.
        public static double[] Divide(this double x, double[] vector, bool inPlace = false);
        //
        // Summary:
        //     Computes the product A*inv(B) of matrix A and diagonal matrix B.
        //
        // Parameters:
        //   a:
        //     The left matrix A.
        //
        //   b:
        //     The diagonal vector of inverse right matrix B.
        //
        // Returns:
        //     The product A*B of the given matrices A and B.
        public static double[,] DivideByDiagonal(this double[,] a, double[] b);
        //
        // Summary:
        //     Computes the product A*inv(B) of matrix A and diagonal matrix B.
        //
        // Parameters:
        //   a:
        //     The left matrix A.
        //
        //   b:
        //     The diagonal vector of inverse right matrix B.
        //
        //   result:
        //     The matrix R to store the product R = A*B of the given matrices A and B.
        public static void DivideByDiagonal(this double[,] a, double[] b, double[,] result);
        //
        // Summary:
        //     Elementwise divide operation.
        public static double[,] ElementwiseDivide(this double[,] a, double[,] b);
        //
        // Summary:
        //     Elementwise divide operation.
        public static float[,] ElementwiseDivide(this float[,] a, float[,] b);
        //
        // Summary:
        //     Elementwise divide operation.
        public static double[] ElementwiseDivide(this double[] a, double[] b);
        //
        // Summary:
        //     Elementwise division.
        public static double[,] ElementwiseDivide(this int[,] a, int[] b, int dimension);
        //
        // Summary:
        //     Elementwise division.
        public static double[][] ElementwiseDivide(this double[][] a, double[] b, int dimension = 0, bool inPlace = false);
        //
        // Summary:
        //     Elementwise division.
        public static double[,] ElementwiseDivide(this double[,] a, double[] b, int dimension = 0, bool inPlace = false);
        //
        // Summary:
        //     Elementwise multiply operation.
        public static int[] ElementwiseMultiply(this int[] a, int[] b);
        //
        // Summary:
        //     Elementwise multiply operation.
        public static double[,] ElementwiseMultiply(this double[,] a, double[,] b);
        //
        // Summary:
        //     Elementwise multiply operation.
        public static double[] ElementwiseMultiply(this double[] a, int[] b);
        //
        // Summary:
        //     Elementwise multiplication.
        public static int[,] ElementwiseMultiply(this int[,] a, int[,] b);
        //
        // Summary:
        //     Elementwise multiply operation.
        public static double[] ElementwiseMultiply(this double[] a, double[] b);
        //
        // Summary:
        //     Elementwise multiplication.
        //
        // Parameters:
        //   a:
        //     The left matrix a.
        //
        //   b:
        //     The right vector b.
        //
        //   dimension:
        //     If set to 0, b will be multiplied with every row vector in a. If set to 1, b
        //     will be multiplied with every column vector.
        public static double[,] ElementwiseMultiply(this double[,] a, double[] b, int dimension);
        //
        // Summary:
        //     Elementwise multiplication.
        //
        // Parameters:
        //   a:
        //     The left matrix a.
        //
        //   b:
        //     The right vector b.
        //
        //   r:
        //     The result vector r.
        //
        //   dimension:
        //     If set to 0, b will be multiplied with every row vector in a. If set to 1, b
        //     will be multiplied with every column vector.
        public static double[,] ElementwiseMultiply(this double[,] a, double[] b, double[,] r, int dimension);
        //
        // Summary:
        //     Elementwise power operation.
        //
        // Parameters:
        //   x:
        //     A matrix.
        //
        //   y:
        //     A power.
        //
        // Returns:
        //     Returns x elevated to the power of y.
        public static double[] ElementwisePower(this double[] x, double y);
        //
        // Summary:
        //     Elementwise power operation.
        //
        // Parameters:
        //   x:
        //     A matrix.
        //
        //   y:
        //     A power.
        //
        // Returns:
        //     Returns x elevated to the power of y.
        public static double[,] ElementwisePower(this double[,] x, double y);
        //
        // Summary:
        //     This method should not be called. Use Matrix.IsEqual instead.
        public static bool Equals(object value);
        //
        // Summary:
        //     Elementwise Exp operation.
        public static double[] Exp(this double[] value);
        //
        // Summary:
        //     Elementwise Exp operation.
        public static double[,] Exp(this double[,] value);
        //
        // Summary:
        //     Expands a data matrix given in summary form.
        //
        // Parameters:
        //   matrix:
        //     A base matrix.
        //
        //   count:
        //     An array containing by how much each line should be replicated.
        public static T[,] Expand<T>(T[,] matrix, int[] count);
        //
        // Summary:
        //     Expands a data vector given in summary form.
        //
        // Parameters:
        //   vector:
        //     A base vector.
        //
        //   count:
        //     An array containing by how much each line should be replicated.
        public static T[] Expand<T>(T[] vector, int[] count);
        //
        // Summary:
        //     Gets the indices of all elements matching a certain criteria.
        //
        // Parameters:
        //   data:
        //     The array to search inside.
        //
        //   func:
        //     The search criteria.
        //
        // Type parameters:
        //   T:
        //     The type of the array.
        public static int[][] Find<T>(this T[,] data, Func<T, bool> func);
        //
        // Summary:
        //     Gets the indices of all elements matching a certain criteria.
        //
        // Parameters:
        //   data:
        //     The array to search inside.
        //
        //   func:
        //     The search criteria.
        //
        // Type parameters:
        //   T:
        //     The type of the array.
        public static int[] Find<T>(this T[] data, Func<T, bool> func);
        //
        // Summary:
        //     Gets the indices of all elements matching a certain criteria.
        //
        // Parameters:
        //   data:
        //     The array to search inside.
        //
        //   func:
        //     The search criteria.
        //
        //   firstOnly:
        //     Set to true to stop when the first element is found, set to false to get all
        //     elements.
        //
        // Type parameters:
        //   T:
        //     The type of the array.
        public static int[][] Find<T>(this T[,] data, Func<T, bool> func, bool firstOnly);
        //
        // Summary:
        //     Gets the indices of all elements matching a certain criteria.
        //
        // Parameters:
        //   data:
        //     The array to search inside.
        //
        //   func:
        //     The search criteria.
        //
        //   firstOnly:
        //     Set to true to stop when the first element is found, set to false to get all
        //     elements.
        //
        // Type parameters:
        //   T:
        //     The type of the array.
        public static int[] Find<T>(this T[] data, Func<T, bool> func, bool firstOnly);
        //
        // Summary:
        //     Gets the indices of the first element matching a certain criteria.
        //
        // Parameters:
        //   data:
        //     The array to search inside.
        //
        //   func:
        //     The search criteria.
        //
        // Type parameters:
        //   T:
        //     The type of the array.
        public static int First<T>(this T[] data, Func<T, bool> func);
        //
        // Summary:
        //     Returns the largest integer less than or equal than to the specified double-precision
        //     floating-point number for each element of the array.
        public static double[] Floor(double[] vector);
        //
        // Summary:
        //     Returns the largest integer less than or equal than to the specified double-precision
        //     floating-point number for each element of the matrix.
        public static double[,] Floor(this double[,] matrix);
        //
        // Summary:
        //     Gets a column vector from a matrix.
        public static T[] GetColumn<T>(this T[][] m, int index);
        //
        // Summary:
        //     Gets a column vector from a matrix.
        public static T[] GetColumn<T>(this T[,] m, int index);
        //
        // Summary:
        //     Gets a column vector from a matrix.
        public static T[,] GetColumns<T>(this T[,] m, params int[] index);
        //
        // Summary:
        //     Gets a column vector from a matrix.
        public static T[][] GetColumns<T>(this T[][] m, params int[] index);
        //
        // Summary:
        //     Gets the dimensions of an array.
        public static int[] GetDimensions(this Array array);
        //
        // Summary:
        //     Creates a vector containing every index that can be used to address a given array,
        //     in order.
        //
        // Parameters:
        //   array:
        //     The array whose indices will be returned.
        //
        // Returns:
        //     An enumerable object that can be used to iterate over all positions of the given
        //     array.
        public static IEnumerable<int[]> GetIndices(this Array array);
        //
        // Summary:
        //     Gets a row vector from a matrix.
        public static T[] GetRow<T>(this T[,] m, int index);
        //
        // Summary:
        //     Gets a row vector from a matrix.
        public static T[] GetRow<T>(this T[][] m, int index);
        //
        // Summary:
        //     Gets a row vector from a matrix.
        public static T[][] GetRows<T>(this T[][] m, params int[] index);
        //
        // Summary:
        //     Returns a value indicating whether the specified matrix contains a value within
        //     a given tolerance.
        //
        // Parameters:
        //   matrix:
        //     A single-precision multidimensional matrix.
        //
        //   value:
        //     The value to search for in the matrix.
        //
        //   tolerance:
        //     The relative tolerance that a value must be in order to be considered equal to
        //     the value being searched.
        //
        // Returns:
        //     True if the matrix contains the value, false otherwise.
        public static bool Has(this float[,] matrix, float value, double tolerance = 0);
        //
        // Summary:
        //     Returns a value indicating whether the specified matrix contains a value within
        //     a given tolerance.
        //
        // Parameters:
        //   matrix:
        //     A double-precision multidimensional matrix.
        //
        //   value:
        //     The value to search for in the matrix.
        //
        //   tolerance:
        //     The relative tolerance that a value must be in order to be considered equal to
        //     the value being searched.
        //
        // Returns:
        //     True if the matrix contains the value, false otherwise.
        public static bool Has(this double[,] matrix, double value, double tolerance = 0);
        //
        // Summary:
        //     Returns a value indicating whether the specified matrix contains a infinity value.
        //
        // Parameters:
        //   matrix:
        //     A double-precision multidimensional matrix.
        //
        // Returns:
        //     True if the matrix contains a infinity value, false otherwise.
        public static bool HasInfinity(this double[][] matrix);
        //
        // Summary:
        //     Returns a value indicating whether the specified matrix contains a infinity value.
        //
        // Parameters:
        //   matrix:
        //     A double-precision multidimensional matrix.
        //
        // Returns:
        //     True if the matrix contains a infinity value, false otherwise.
        public static bool HasInfinity(this double[] matrix);
        //
        // Summary:
        //     Returns a value indicating whether the specified matrix contains a infinity value.
        //
        // Parameters:
        //   matrix:
        //     A double-precision multidimensional matrix.
        //
        // Returns:
        //     True if the matrix contains infinity values, false otherwise.
        public static bool HasInfinity(this double[,] matrix);
        //
        // Summary:
        //     Returns a value indicating whether the specified matrix contains a value that
        //     is not a number (NaN).
        //
        // Parameters:
        //   matrix:
        //     A double-precision multidimensional matrix.
        //
        // Returns:
        //     True if the matrix contains a value that is not a number, false otherwise.
        public static bool HasNaN(this double[] matrix);
        //
        // Summary:
        //     Returns a value indicating whether the specified matrix contains a value that
        //     is not a number (NaN).
        //
        // Parameters:
        //   matrix:
        //     A double-precision multidimensional matrix.
        //
        // Returns:
        //     True if the matrix contains a value that is not a number, false otherwise.
        public static bool HasNaN(this double[][] matrix);
        //
        // Summary:
        //     Returns a value indicating whether the specified matrix contains a value that
        //     is not a number (NaN).
        //
        // Parameters:
        //   matrix:
        //     A double-precision multidimensional matrix.
        //
        // Returns:
        //     True if the matrix contains a value that is not a number, false otherwise.
        public static bool HasNaN(this double[,] matrix);
        //
        // Summary:
        //     Returns the Identity matrix of the given size.
        public static double[,] Identity(int size);
        //
        // Summary:
        //     Searches for the specified value and returns the index of the first occurrence
        //     within the array.
        //
        // Parameters:
        //   data:
        //     The array to search.
        //
        //   value:
        //     The value to be searched.
        //
        // Type parameters:
        //   T:
        //     The type of the array.
        //
        // Returns:
        //     The index of the searched value within the array, or -1 if not found.
        public static int IndexOf<T>(this T[] data, T value);
        //
        // Summary:
        //     Creates a index vector.
        public static int[] Indices(int to);
        //
        // Summary:
        //     Creates a index vector.
        public static int[] Indices(int from, int to);
        //
        // Summary:
        //     Gets the inner product (scalar product) between two vectors (a'*b).
        //
        // Parameters:
        //   a:
        //     A vector.
        //
        //   b:
        //     A vector.
        //
        // Returns:
        //     The inner product of the multiplication of the vectors.
        //
        // Remarks:
        //     In mathematics, the dot product is an algebraic operation that takes two equal-length
        //     sequences of numbers (usually coordinate vectors) and returns a single number
        //     obtained by multiplying corresponding entries and adding up those products. The
        //     name is derived from the dot that is often used to designate this operation;
        //     the alternative name scalar product emphasizes the scalar (rather than vector)
        //     nature of the result.
        //     The principal use of this product is the inner product in a Euclidean vector
        //     space: when two vectors are expressed on an orthonormal basis, the dot product
        //     of their coordinate vectors gives their inner product.
        public static float InnerProduct(this float[] a, float[] b);
        //
        // Summary:
        //     Gets the inner product (scalar product) between two vectors (a'*b).
        //
        // Parameters:
        //   a:
        //     A vector.
        //
        //   b:
        //     A vector.
        //
        // Returns:
        //     The inner product of the multiplication of the vectors.
        //
        // Remarks:
        //     In mathematics, the dot product is an algebraic operation that takes two equal-length
        //     sequences of numbers (usually coordinate vectors) and returns a single number
        //     obtained by multiplying corresponding entries and adding up those products. The
        //     name is derived from the dot that is often used to designate this operation;
        //     the alternative name scalar product emphasizes the scalar (rather than vector)
        //     nature of the result.
        //     The principal use of this product is the inner product in a Euclidean vector
        //     space: when two vectors are expressed on an orthonormal basis, the dot product
        //     of their coordinate vectors gives their inner product.
        public static double InnerProduct(this double[] a, double[] b);
        //
        // Summary:
        //     Returns a new matrix with a new column vector inserted at the end of the original
        //     matrix.
        public static T[][] InsertColumn<T>(this T[][] matrix);
        //
        // Summary:
        //     Returns a new matrix with a new column vector inserted at the end of the original
        //     matrix.
        public static T[,] InsertColumn<T>(this T[,] matrix);
        //
        // Summary:
        //     Returns a new matrix with a given column vector inserted at the end of the original
        //     matrix.
        public static T[][] InsertColumn<T, TSource>(this T[][] matrix, TSource[] column);
        //
        // Summary:
        //     Returns a new matrix with a given column vector inserted at the end of the original
        //     matrix.
        public static T[,] InsertColumn<T, TSource>(this T[,] matrix, TSource[] column);
        //
        // Summary:
        //     Returns a new matrix with a given column vector inserted at a given index.
        public static T[][] InsertColumn<T, TSource>(this T[][] matrix, TSource[] column, int index);
        //
        // Summary:
        //     Returns a new matrix with a given column vector inserted at a given index.
        public static T[,] InsertColumn<T, TSource>(this T[,] matrix, TSource[] column, int index);
        //
        // Summary:
        //     Returns a new matrix with a new row vector inserted at the end of the original
        //     matrix.
        public static T[][] InsertRow<T>(this T[][] matrix);
        //
        // Summary:
        //     Returns a new matrix with a new row vector inserted at the end of the original
        //     matrix.
        public static T[,] InsertRow<T>(this T[,] matrix);
        //
        // Summary:
        //     Returns a new matrix with a given row vector inserted at the end of the original
        //     matrix.
        public static T[][] InsertRow<T, TSource>(this T[][] matrix, TSource[] row);
        //
        // Summary:
        //     Returns a new matrix with a given row vector inserted at the end of the original
        //     matrix.
        public static T[,] InsertRow<T, TSource>(this T[,] matrix, TSource[] row);
        //
        // Summary:
        //     Returns a new matrix with a given row vector inserted at a given index.
        public static T[][] InsertRow<T, TSource>(this T[][] matrix, TSource[] row, int index);
        //
        // Summary:
        //     Returns a new matrix with a given row vector inserted at a given index.
        public static T[,] InsertRow<T, TSource>(this T[,] matrix, TSource[] row, int index);
        //
        // Summary:
        //     Creates an interval vector.
        public static double[] Interval(AForge.DoubleRange range, int steps);
        //
        // Summary:
        //     Creates an interval vector.
        public static double[] Interval(AForge.DoubleRange range, double stepSize);
        //
        // Summary:
        //     Creates an interval vector.
        public static int[] Interval(int from, int to);
        //
        // Summary:
        //     Creates an interval vector.
        public static double[] Interval(double from, double to, int steps);
        //
        // Summary:
        //     Creates an interval vector.
        public static float[] Interval(float from, float to, double stepSize);
        //
        // Summary:
        //     Creates an interval vector.
        public static double[] Interval(double from, double to, double stepSize);
        //
        // Summary:
        //     Computes the inverse of a matrix.
        public static double[][] Inverse(this double[][] matrix);
        //
        // Summary:
        //     Computes the inverse of a matrix.
        public static double[,] Inverse(this double[,] matrix);
        //
        // Summary:
        //     Computes the inverse of a matrix.
        public static double[][] Inverse(this double[][] matrix, bool inPlace);
        //
        // Summary:
        //     Computes the inverse of a matrix.
        public static double[,] Inverse(this double[,] matrix, bool inPlace);
        //
        // Summary:
        //     Returns true if a matrix is lower triangular.
        //
        // Parameters:
        //   matrix:
        public static bool IsDiagonal<T>(this T[][] matrix) where T : IComparable;
        //
        // Summary:
        //     Returns true if a matrix is lower triangular.
        //
        // Parameters:
        //   matrix:
        public static bool IsDiagonal<T>(this T[,] matrix) where T : IComparable;
        //
        // Summary:
        //     Compares each member of a matrix for equality with a scalar value x.
        public static bool IsEqual(this double[,] matrix, double scalar);
        //
        // Summary:
        //     Compares each member of a vector for equality with a scalar value x.
        public static bool IsEqual(this double[] vector, double scalar);
        //
        // Summary:
        //     Compares two matrices for equality, considering an acceptance threshold.
        public static bool IsEqual(this float[][] objA, float[][] objB, double threshold);
        //
        // Summary:
        //     Compares two matrices for equality, considering an acceptance threshold.
        public static bool IsEqual(this double[][] objA, double[][] objB, double threshold);
        //
        // Summary:
        //     Compares two matrices for equality, considering an acceptance threshold.
        public static bool IsEqual(this float[,] objA, float[,] objB, double threshold);
        //
        // Summary:
        //     Compares each member of a vector for equality with a scalar value x.
        public static bool IsEqual(this double[] vector, double scalar, double threshold);
        //
        // Summary:
        //     Compares each member of a matrix for equality with a scalar value x.
        public static bool IsEqual(this double[,] matrix, double scalar, double threshold);
        //
        // Summary:
        //     Compares two matrices for equality, considering an acceptance threshold.
        public static bool IsEqual(this double[,] objA, double[,] objB, double threshold);
        //
        // Summary:
        //     Compares two vectors for equality, considering an acceptance threshold.
        public static bool IsEqual(this double[] objA, double[] objB, double threshold);
        //
        // Summary:
        //     Compares two vectors for equality, considering an acceptance threshold.
        public static bool IsEqual(this float[] objA, float[] objB, double threshold);
        //
        // Summary:
        //     Compares two matrices for equality, considering an acceptance threshold.
        public static bool IsEqual(this double a, double b, double threshold);
        //
        // Summary:
        //     Compares two vectors for equality.
        public static bool IsEqual<T>(this T[] objA, params T[] objB);
        //
        // Summary:
        //     Compares two matrices for equality.
        public static bool IsEqual<T>(this T[,] objA, T[,] objB);
        //
        // Summary:
        //     Compares two matrices for equality.
        public static bool IsEqual<T>(this T[][] objA, T[][] objB);
        //
        // Summary:
        //     Determines whether a number is an integer, given a tolerance threshold.
        //
        // Parameters:
        //   x:
        //     The value to be compared.
        //
        //   threshold:
        //     The maximum that the number can deviate from its closest integer number.
        //
        // Returns:
        //     True if the number if an integer, false otherwise.
        public static bool IsInteger(this double x, double threshold);
        //
        // Summary:
        //     Returns true if a matrix is lower triangular.
        //
        // Parameters:
        //   matrix:
        public static bool IsLowerTriangular<T>(this T[,] matrix) where T : IComparable;
        //
        // Summary:
        //     Returns true if a matrix is lower triangular.
        //
        // Parameters:
        //   matrix:
        public static bool IsLowerTriangular<T>(this T[][] matrix) where T : IComparable;
        //
        // Summary:
        //     Gets whether a matrix is positive definite.
        public static bool IsPositiveDefinite(this double[][] matrix);
        //
        // Summary:
        //     Gets whether a matrix is positive definite.
        public static bool IsPositiveDefinite(this double[,] matrix);
        //
        // Summary:
        //     Compares two values for equality, considering a relative acceptance threshold.
        public static bool IsRelativelyEqual(this double a, double b, double threshold);
        //
        // Summary:
        //     Gets whether a matrix is singular.
        public static bool IsSingular(this double[,] matrix);
        //
        // Summary:
        //     Returns true if a vector of real-valued observations is ordered in ascending
        //     or descending order.
        //
        // Parameters:
        //   values:
        //     An array of values.
        //
        //   direction:
        //     The sort order direction.
        public static bool IsSorted<T>(this T[] values, ComparerDirection direction) where T : IComparable<T>;
        //
        // Summary:
        //     Returns true if a matrix is square.
        public static bool IsSquare<T>(this T[,] matrix);
        //
        // Summary:
        //     Returns true if a matrix is symmetric.
        //
        // Parameters:
        //   matrix:
        public static bool IsSymmetric<T>(this T[][] matrix) where T : IComparable;
        //
        // Summary:
        //     Returns true if a matrix is symmetric.
        //
        // Parameters:
        //   matrix:
        public static bool IsSymmetric<T>(this T[,] matrix) where T : IComparable;
        //
        // Summary:
        //     Returns true if a matrix is upper triangular.
        //
        // Parameters:
        //   matrix:
        public static bool IsUpperTriangular<T>(this T[,] matrix) where T : IComparable;
        //
        // Summary:
        //     Returns true if a matrix is upper triangular.
        //
        // Parameters:
        //   matrix:
        public static bool IsUpperTriangular<T>(this T[][] matrix) where T : IComparable;
        //
        // Summary:
        //     Returns a new jagged matrix.
        public static T[,] Jagged<T>(int size);
        //
        // Summary:
        //     Returns a new jagged matrix.
        public static T[][] Jagged<T>(int rows, int cols);
        //
        // Summary:
        //     Returns a matrix with all elements set to a given value.
        public static T[,] Jagged<T>(int size, T value);
        //
        // Summary:
        //     Returns a matrix with all elements set to a given value.
        public static T[][] Jagged<T>(int rows, int cols, T value);
        //
        // Summary:
        //     Return a jagged matrix with a vector of values on its diagonal.
        public static T[][] JaggedDiagonal<T>(T[] values);
        //
        // Summary:
        //     Returns a square diagonal matrix of the given size.
        public static T[][] JaggedDiagonal<T>(int size, T value);
        //
        // Summary:
        //     Returns the Identity matrix of the given size.
        public static double[][] JaggedIdentity(int size);
        //
        // Summary:
        //     Creates a jagged magic square matrix.
        public static double[][] JaggedMagic(int size);
        //
        // Summary:
        //     Computes the Kronecker product between two vectors.
        //
        // Parameters:
        //   a:
        //     The left vector a.
        //
        //   b:
        //     The right vector b.
        //
        // Returns:
        //     The Kronecker product of the two vectors.
        public static double[] KroneckerProduct(this double[] a, double[] b);
        //
        // Summary:
        //     Computes the Kronecker product between two matrices.
        //
        // Parameters:
        //   a:
        //     The left matrix a.
        //
        //   b:
        //     The right matrix b.
        //
        // Returns:
        //     The Kronecker product of the two matrices.
        public static double[,] KroneckerProduct(this double[,] a, double[,] b);
        //
        // Summary:
        //     Elementwise Log operation.
        public static double[] Log(this double[] value);
        //
        // Summary:
        //     Elementwise Log operation.
        public static double[] Log(this int[] value);
        //
        // Summary:
        //     Elementwise Log operation.
        public static double[,] Log(this double[,] value);
        //
        // Summary:
        //     Gets the log-determinant of a matrix.
        public static double LogDeterminant(this double[,] matrix);
        //
        // Summary:
        //     Gets the log-determinant of a matrix.
        public static double LogDeterminant(this double[,] matrix, bool symmetric);
        //
        // Summary:
        //     Gets the log of the pseudo-determinant of a matrix.
        public static double LogPseudoDeterminant(this double[,] matrix);
        //
        // Summary:
        //     Creates a magic square matrix.
        public static double[,] Magic(int size);
        //
        // Summary:
        //     Gets the maximum value of a matrix.
        public static T Max<T>(this T[][] matrix) where T : IComparable;
        //
        // Summary:
        //     Gets the maximum value of a matrix.
        public static T Max<T>(this T[,] matrix) where T : IComparable;
        //
        // Summary:
        //     Gets the maximum element in a vector.
        public static T Max<T>(this T[] values) where T : IComparable;
        //
        // Summary:
        //     Gets the maximum value of a matrix.
        public static T Max<T>(this T[][] matrix, out Tuple<int, int> imax) where T : IComparable;
        //
        // Summary:
        //     Gets the maximum value of a matrix.
        public static T Max<T>(this T[,] matrix, out Tuple<int, int> imax) where T : IComparable;
        //
        // Summary:
        //     Gets the maximum values across one dimension of a matrix.
        public static T[] Max<T>(this T[,] matrix, int dimension) where T : IComparable;
        //
        // Summary:
        //     Gets the maximum values across one dimension of a matrix.
        public static T[] Max<T>(this T[][] matrix, int dimension) where T : IComparable;
        //
        // Summary:
        //     Gets the maximum element in a vector up to a fixed length.
        public static T Max<T>(this T[] values, int length) where T : IComparable;
        //
        // Summary:
        //     Gets the maximum element in a vector.
        public static T Max<T>(this T[] values, out int imax) where T : IComparable;
        //
        // Summary:
        //     Gets the maximum non-null element in a vector.
        public static T? Max<T>(this T?[] values, out int imax) where T : struct, IComparable;
        //
        // Summary:
        //     Gets the maximum values across one dimension of a matrix.
        public static T[] Max<T>(this T[,] matrix, int dimension, out int[] imax) where T : IComparable;
        //
        // Summary:
        //     Gets the maximum element in a vector up to a fixed length.
        public static T Max<T>(this T[] values, int length, out int imax) where T : IComparable;
        //
        // Summary:
        //     Gets the maximum values across one dimension of a matrix.
        public static T[] Max<T>(this T[][] matrix, int dimension, out int[] imax) where T : IComparable;
        //
        // Summary:
        //     Gets the maximum element in a vector.
        public static T Max<T>(this T[] values, out int imax, bool alreadySorted) where T : IComparable;
        //
        // Summary:
        //     Creates a memberwise copy of a multidimensional matrix. Matrix elements themselves
        //     are copied only in a shallowed manner (i.e. not cloned).
        public static T[,] MemberwiseClone<T>(this T[,] a);
        //
        // Summary:
        //     Creates a memberwise copy of a jagged matrix. Matrix elements themselves are
        //     copied only in a shallowed manner (i.e. not cloned).
        public static T[][] MemberwiseClone<T>(this T[][] a);
        //
        // Summary:
        //     Merges a series of vectors into a single vector. This operation can be reverted
        //     using Accord.Math.Matrix.Split``1(``0[],System.Int32).
        //
        // Parameters:
        //   vectors:
        //     The vectors to be merged.
        //
        // Returns:
        //     A single array containing the given vectors.
        public static T[] Merge<T>(this T[][] vectors);
        //
        // Summary:
        //     Merges a series of vectors into a single vector. This operation can be reverted
        //     using Accord.Math.Matrix.Split``1(``0[],System.Int32).
        //
        // Parameters:
        //   vectors:
        //     The vectors to be merged.
        //
        //   size:
        //     The size of the inner vectors.
        //
        // Returns:
        //     A single array containing the given vectors.
        public static T[] Merge<T>(this T[][] vectors, int size);
        //
        // Summary:
        //     Creates a bi-dimensional mesh matrix.
        public static double[][] Mesh(AForge.DoubleRange rowRange, AForge.DoubleRange colRange, double rowStepSize, double colStepSize);
        //
        // Summary:
        //     Creates a bi-dimensional mesh matrix.
        public static int[][] Mesh(int rowMin, int rowMax, int colMin, int colMax);
        //
        // Summary:
        //     Creates a bi-dimensional mesh matrix.
        public static double[][] Mesh(double rowMin, double rowMax, int rowSteps, double colMin, double colMax, int colSteps);
        //
        // Summary:
        //     Creates a bi-dimensional mesh matrix.
        public static double[][] Mesh(double rowMin, double rowMax, double rowStepSize, double colMin, double colMax, double colStepSize);
        //
        // Summary:
        //     Creates a bi-dimensional mesh matrix.
        //
        // Parameters:
        //   x:
        //     The values to be replicated vertically.
        //
        //   y:
        //     The values to be replicated horizontally.
        public static T[][] Mesh<T>(this T[] x, T[] y);
        //
        // Summary:
        //     Generates a 2-D mesh grid from two vectors a and b, generating two matrices len(a)
        //     x len(b) with all all possible combinations of values between the two vectors.
        //     This method is analogous to MATLAB/Octave's meshgrid function.
        //
        // Returns:
        //     A tuple containing two matrices: the first containing values for the x-coordinates
        //     and the second for the y-coordinates.
        public static Tuple<T[,], T[,]> MeshGrid<T>(this T[] x, T[] y);
        //
        // Summary:
        //     Gets the minimum value of a matrix.
        public static T Min<T>(this T[][] matrix) where T : IComparable;
        //
        // Summary:
        //     Gets the minimum value of a matrix.
        public static T Min<T>(this T[,] matrix) where T : IComparable;
        //
        // Summary:
        //     Gets the minimum element in a vector.
        public static T Min<T>(this T[] values) where T : IComparable;
        //
        // Summary:
        //     Gets the minimum values across one dimension of a matrix.
        public static T[] Min<T>(this T[][] matrix, int dimension) where T : IComparable;
        //
        // Summary:
        //     Gets the minimum values across one dimension of a matrix.
        public static T[] Min<T>(this T[,] matrix, int dimension) where T : IComparable;
        //
        // Summary:
        //     Gets the minimum value of a matrix.
        public static T Min<T>(this T[][] matrix, out Tuple<int, int> imin) where T : IComparable;
        //
        // Summary:
        //     Gets the minimum element in a vector up to a fixed length.
        public static T Min<T>(this T[] values, int length) where T : IComparable;
        //
        // Summary:
        //     Gets the minimum value of a matrix.
        public static T Min<T>(this T[,] matrix, out Tuple<int, int> imin) where T : IComparable;
        //
        // Summary:
        //     Gets the minimum element in a vector.
        public static T Min<T>(this T[] values, out int imax) where T : IComparable;
        //
        // Summary:
        //     Gets the minimum values across one dimension of a matrix.
        public static T[] Min<T>(this T[][] matrix, int dimension, out int[] imin) where T : IComparable;
        //
        // Summary:
        //     Gets the minimum values across one dimension of a matrix.
        public static T[] Min<T>(this T[,] matrix, int dimension, out int[] imin) where T : IComparable;
        //
        // Summary:
        //     Gets the minimum element in a vector up to a fixed length.
        public static T Min<T>(this T[] values, int length, out int imax) where T : IComparable;
        //
        // Summary:
        //     Computes the product A*B of two matrices A and B.
        //
        // Parameters:
        //   a:
        //     The left matrix A.
        //
        //   b:
        //     The right matrix B.
        //
        // Returns:
        //     The product A*B of the given matrices A and B.
        public static float[][] Multiply(this float[][] a, float[][] b);
        //
        // Summary:
        //     Computes the product A*B of two matrices A and B.
        //
        // Parameters:
        //   a:
        //     The left matrix A.
        //
        //   b:
        //     The right matrix B.
        //
        // Returns:
        //     The product A*B of the given matrices A and B.
        public static float[,] Multiply(this float[,] a, float[,] b);
        //
        // Summary:
        //     Multiplies a row vector v and a matrix A, giving the product v'*A.
        //
        // Parameters:
        //   rowVector:
        //     The row vector v.
        //
        //   matrix:
        //     The matrix A.
        //
        // Returns:
        //     The product v'*Aof the multiplication of the given row vector v and matrix A.
        public static float[] Multiply(this float[] rowVector, float[,] matrix);
        //
        // Summary:
        //     Multiplies a matrix A and a column vector v, giving the product A*v
        //
        // Parameters:
        //   matrix:
        //     The matrix A.
        //
        //   columnVector:
        //     The column vector v.
        //
        // Returns:
        //     The product A*v of the multiplication of the given matrix A and column vector
        //     v.
        public static float[] Multiply(this float[][] matrix, float[] columnVector);
        //
        // Summary:
        //     Multiplies a matrix A by a scalar x.
        //
        // Parameters:
        //   matrix:
        //     The matrix A.
        //
        //   x:
        //     The scalar x.
        //
        // Returns:
        //     The product A*x of the multiplication of the given matrix A and scalar x.
        public static double[,] Multiply(this double[,] matrix, double x);
        //
        // Summary:
        //     Multiplies a vector v by a scalar x.
        //
        // Parameters:
        //   vector:
        //     The vector v.
        //
        //   x:
        //     The scalar x.
        //
        // Returns:
        //     The product v*x of the multiplication of the given vector v and scalar x.
        public static double[] Multiply(this double[] vector, double x);
        //
        // Summary:
        //     Multiplies a scalar x by a matrix A.
        //
        // Parameters:
        //   x:
        //     The scalar x.
        //
        //   matrix:
        //     The matrix A.
        //
        // Returns:
        //     The product x*A of the multiplication of the given scalar x and matrix A.
        public static double[,] Multiply(this double x, double[,] matrix);
        //
        // Summary:
        //     Multiplies a vector v by a scalar x.
        //
        // Parameters:
        //   vector:
        //     The vector v.
        //
        //   x:
        //     The scalar x.
        //
        // Returns:
        //     The product v*x of the multiplication of the given vector v and scalar x.
        public static float[] Multiply(this float[] vector, float x);
        //
        // Summary:
        //     Multiplies a matrix A by a scalar x.
        //
        // Parameters:
        //   matrix:
        //     The matrix A.
        //
        //   x:
        //     The scalar x.
        //
        // Returns:
        //     The product A*x of the multiplication of the given matrix A and scalar x.
        public static float[,] Multiply(this float[,] matrix, float x);
        //
        // Summary:
        //     Multiplies a matrix A and a column vector v, giving the product A*v
        //
        // Parameters:
        //   matrix:
        //     The matrix A.
        //
        //   columnVector:
        //     The column vector v.
        //
        // Returns:
        //     The product A*v of the multiplication of the given matrix A and column vector
        //     v.
        public static float[] Multiply(this float[,] matrix, float[] columnVector);
        //
        // Summary:
        //     Multiplies a matrix A and a column vector v, giving the product A*v
        //
        // Parameters:
        //   matrix:
        //     The matrix A.
        //
        //   columnVector:
        //     The column vector v.
        //
        // Returns:
        //     The product A*v of the multiplication of the given matrix A and column vector
        //     v.
        public static double[] Multiply(this double[][] matrix, double[] columnVector);
        //
        // Summary:
        //     Multiplies a matrix A and a column vector v, giving the product A*v
        //
        // Parameters:
        //   matrix:
        //     The matrix A.
        //
        //   columnVector:
        //     The column vector v.
        //
        // Returns:
        //     The product A*v of the multiplication of the given matrix A and column vector
        //     v.
        public static double[] Multiply(this double[,] matrix, double[] columnVector);
        //
        // Summary:
        //     Multiplies a row vector v and a matrix A, giving the product v'*A.
        //
        // Parameters:
        //   rowVector:
        //     The row vector v.
        //
        //   matrix:
        //     The matrix A.
        //
        // Returns:
        //     The product v'*Aof the multiplication of the given row vector v and matrix A.
        public static double[] Multiply(this double[] rowVector, double[,] matrix);
        //
        // Summary:
        //     Computes the product A*B of two matrices A and B.
        //
        // Parameters:
        //   a:
        //     The left matrix A.
        //
        //   b:
        //     The right matrix B.
        //
        // Returns:
        //     The product A*B of the given matrices A and B.
        public static double[][] Multiply(this float[][] a, double[][] b);
        //
        // Summary:
        //     Computes the product A*B of two matrices A and B.
        //
        // Parameters:
        //   a:
        //     The left matrix A.
        //
        //   b:
        //     The right matrix B.
        //
        // Returns:
        //     The product A*B of the given matrices A and B.
        public static double[][] Multiply(this double[][] a, double[][] b);
        //
        // Summary:
        //     Multiplies a scalar x by a matrix A.
        //
        // Parameters:
        //   x:
        //     The scalar x.
        //
        //   matrix:
        //     The matrix A.
        //
        // Returns:
        //     The product x*A of the multiplication of the given scalar x and matrix A.
        public static float[,] Multiply(this float x, float[,] matrix);
        //
        // Summary:
        //     Multiplies a scalar x by a vector v.
        //
        // Parameters:
        //   x:
        //     The scalar x.
        //
        //   vector:
        //     The vector v.
        //
        // Returns:
        //     The product x*v of the multiplication of the given scalar x and vector v.
        public static float[] Multiply(this float x, float[] vector);
        //
        // Summary:
        //     Multiplies a scalar x by a vector v.
        //
        // Parameters:
        //   x:
        //     The scalar x.
        //
        //   vector:
        //     The vector v.
        //
        // Returns:
        //     The product x*v of the multiplication of the given scalar x and vector v.
        public static float[] Multiply(this int x, float[] vector);
        //
        // Summary:
        //     Multiplies a scalar x by a vector v.
        //
        // Parameters:
        //   x:
        //     The scalar x.
        //
        //   vector:
        //     The vector v.
        //
        // Returns:
        //     The product x*v of the multiplication of the given scalar x and vector v.
        public static double[] Multiply(this int x, double[] vector);
        //
        // Summary:
        //     Multiplies a scalar x by a vector v.
        //
        // Parameters:
        //   x:
        //     The scalar x.
        //
        //   vector:
        //     The vector v.
        //
        // Returns:
        //     The product x*v of the multiplication of the given scalar x and vector v.
        public static double[] Multiply(this double x, double[] vector);
        //
        // Summary:
        //     Computes the product A*B of two matrices A and B.
        //
        // Parameters:
        //   a:
        //     The left matrix A.
        //
        //   b:
        //     The right matrix B.
        //
        // Returns:
        //     The product A*B of the given matrices A and B.
        public static double[,] Multiply(this double[,] a, double[,] b);
        //
        // Summary:
        //     Multiplies a matrix A by a scalar x.
        //
        // Parameters:
        //   matrix:
        //     The matrix A.
        //
        //   x:
        //     The scalar x.
        //
        //   result:
        //     The matrix R to store the product R=A*x of the multiplication of the given matrix
        //     A and scalar x.
        public static void Multiply(this double[,] matrix, double x, double[,] result);
        //
        // Summary:
        //     Multiplies a vector v by a scalar x.
        //
        // Parameters:
        //   vector:
        //     The vector v.
        //
        //   x:
        //     The scalar x.
        //
        //   inPlace:
        //     True to perform the operation in-place, overwriting the original matrix; false
        //     to return a new matrix.
        //
        // Returns:
        //     The product v*x of the multiplication of the given vector v and scalar x.
        public static double[] Multiply(this double[] vector, double x, bool inPlace);
        //
        // Summary:
        //     Multiplies a matrix A by a scalar x.
        //
        // Parameters:
        //   matrix:
        //     The matrix A.
        //
        //   x:
        //     The scalar x.
        //
        //   result:
        //     The matrix R to store the product R=A*x of the multiplication of the given matrix
        //     A and scalar x.
        public static void Multiply(this float[,] matrix, float x, float[,] result);
        //
        // Summary:
        //     Computes the product R = A*B of two matrices A and B, storing the result in matrix
        //     R.
        //
        // Parameters:
        //   a:
        //     The left matrix A.
        //
        //   b:
        //     The right matrix B.
        //
        //   result:
        //     The matrix R to store the product R = A*B of the given matrices A and B.
        public static void Multiply(this float[][] a, float[][] b, float[][] result);
        //
        // Summary:
        //     Multiplies a matrix A by a scalar x.
        //
        // Parameters:
        //   matrix:
        //     The matrix A.
        //
        //   x:
        //     The scalar x.
        //
        //   inPlace:
        //     True to perform the operation in-place, overwriting the original matrix; false
        //     to return a new matrix.
        //
        // Returns:
        //     The product A*x of the multiplication of the given matrix A and scalar x.
        public static double[,] Multiply(this double[,] matrix, double x, bool inPlace = false);
        //
        // Summary:
        //     Computes the product R = A*B of two matrices A and B, storing the result in matrix
        //     R.
        //
        // Parameters:
        //   a:
        //     The left matrix A.
        //
        //   b:
        //     The right matrix B.
        //
        //   result:
        //     The matrix R to store the product R = A*B of the given matrices A and B.
        public static void Multiply(this float[,] a, float[,] b, float[,] result);
        //
        // Summary:
        //     Computes the product R = A*B of two matrices A and B, storing the result in matrix
        //     R.
        //
        // Parameters:
        //   a:
        //     The left matrix A.
        //
        //   b:
        //     The right matrix B.
        //
        //   result:
        //     The matrix R to store the product R = A*B of the given matrices A and B.
        public static void Multiply(this float[][] a, double[][] b, double[][] result);
        //
        // Summary:
        //     Computes the product R = A*B of two matrices A and B, storing the result in matrix
        //     R.
        //
        // Parameters:
        //   a:
        //     The left matrix A.
        //
        //   b:
        //     The right matrix B.
        //
        //   result:
        //     The matrix R to store the product R = A*B of the given matrices A and B.
        public static void Multiply(this double[,] a, double[,] b, double[][] result);
        //
        // Summary:
        //     Computes the product R = A*B of two matrices A and B, storing the result in matrix
        //     R.
        //
        // Parameters:
        //   a:
        //     The left matrix A.
        //
        //   b:
        //     The right matrix B.
        //
        //   result:
        //     The matrix R to store the product R = A*B of the given matrices A and B.
        public static void Multiply(this double[][] a, double[][] b, double[][] result);
        //
        // Summary:
        //     Computes the product R = A*B of two matrices A and B, storing the result in matrix
        //     R.
        //
        // Parameters:
        //   a:
        //     The left matrix A.
        //
        //   b:
        //     The right matrix B.
        //
        //   result:
        //     The matrix R to store the product R = A*B of the given matrices A and B.
        public static void Multiply(this double[,] a, double[,] b, double[,] result);
        //
        // Summary:
        //     Computes the product A*B of matrix A and diagonal matrix B.
        //
        // Parameters:
        //   a:
        //     The left matrix A.
        //
        //   b:
        //     The diagonal vector of right matrix B.
        //
        // Returns:
        //     The product A*B of the given matrices A and B.
        public static float[,] MultiplyByDiagonal(this float[,] a, float[] b);
        //
        // Summary:
        //     Computes the product A*B of matrix A and diagonal matrix B.
        //
        // Parameters:
        //   a:
        //     The left matrix A.
        //
        //   b:
        //     The diagonal vector of right matrix B.
        //
        // Returns:
        //     The product A*B of the given matrices A and B.
        public static float[][] MultiplyByDiagonal(this float[][] a, float[] b);
        //
        // Summary:
        //     Computes the product A*B of matrix A and diagonal matrix B.
        //
        // Parameters:
        //   a:
        //     The left matrix A.
        //
        //   b:
        //     The diagonal vector of right matrix B.
        //
        // Returns:
        //     The product A*B of the given matrices A and B.
        public static double[,] MultiplyByDiagonal(this double[,] a, double[] b);
        //
        // Summary:
        //     Computes the product A*B of matrix A and diagonal matrix B.
        //
        // Parameters:
        //   a:
        //     The left matrix A.
        //
        //   b:
        //     The diagonal vector of right matrix B.
        //
        // Returns:
        //     The product A*B of the given matrices A and B.
        public static double[][] MultiplyByDiagonal(this double[][] a, double[] b);
        //
        // Summary:
        //     Computes the product A*B of matrix A and diagonal matrix B.
        //
        // Parameters:
        //   a:
        //     The left matrix A.
        //
        //   b:
        //     The diagonal vector of right matrix B.
        //
        //   result:
        //     The matrix R to store the product R = A*B of the given matrices A and B.
        public static void MultiplyByDiagonal(this double[][] a, double[] b, double[][] result);
        //
        // Summary:
        //     Computes the product A*B of matrix A and diagonal matrix B.
        //
        // Parameters:
        //   a:
        //     The left matrix A.
        //
        //   b:
        //     The diagonal vector of right matrix B.
        //
        //   result:
        //     The matrix R to store the product R = A*B of the given matrices A and B.
        public static void MultiplyByDiagonal(this float[,] a, float[] b, float[,] result);
        //
        // Summary:
        //     Computes the product A*B of matrix A and diagonal matrix B.
        //
        // Parameters:
        //   a:
        //     The left matrix A.
        //
        //   b:
        //     The diagonal vector of right matrix B.
        //
        //   result:
        //     The matrix R to store the product R = A*B of the given matrices A and B.
        public static void MultiplyByDiagonal(this float[][] a, float[] b, float[][] result);
        //
        // Summary:
        //     Computes the product A*B of matrix A and diagonal matrix B.
        //
        // Parameters:
        //   a:
        //     The left matrix A.
        //
        //   b:
        //     The diagonal vector of right matrix B.
        //
        //   result:
        //     The matrix R to store the product R = A*B of the given matrices A and B.
        public static void MultiplyByDiagonal(this double[,] a, double[] b, double[,] result);
        //
        // Summary:
        //     Computes the product A*B' of matrix A and transpose of B.
        //
        // Parameters:
        //   a:
        //     The left matrix A.
        //
        //   b:
        //     The transposed right matrix B.
        //
        // Returns:
        //     The product A*B' of the given matrices A and B.
        public static float[,] MultiplyByTranspose(this float[,] a, float[,] b);
        //
        // Summary:
        //     Computes the product A*B' of matrix A and transpose of B.
        //
        // Parameters:
        //   a:
        //     The left matrix A.
        //
        //   b:
        //     The transposed right matrix B.
        //
        // Returns:
        //     The product A*B' of the given matrices A and B.
        public static double[,] MultiplyByTranspose(this double[,] a, double[,] b);
        //
        // Summary:
        //     Computes the product A*B' of matrix A and transpose of B, storing the result
        //     in matrix R.
        //
        // Parameters:
        //   a:
        //     The left matrix A.
        //
        //   b:
        //     The transposed right matrix B.
        //
        //   result:
        //     The matrix R to store the product R = A*B' of the given matrices A and B.
        public static void MultiplyByTranspose(this float[,] a, float[,] b, float[,] result);
        //
        // Summary:
        //     Computes the product A*B' of matrix A and transpose of B, storing the result
        //     in matrix R.
        //
        // Parameters:
        //   a:
        //     The left matrix A.
        //
        //   b:
        //     The transposed right matrix B.
        //
        //   result:
        //     The matrix R to store the product R = A*B' of the given matrices A and B.
        public static void MultiplyByTranspose(this double[,] a, double[,] b, double[,] result);
        //
        // Summary:
        //     Normalizes a vector to have unit length.
        //
        // Parameters:
        //   vector:
        //     A vector.
        //
        //   inPlace:
        //     True to perform the operation in-place, overwriting the original array; false
        //     to return a new array.
        //
        // Returns:
        //     A multiple of vector a where ||a|| = 1.
        public static float[] Normalize(this float[] vector, bool inPlace = false);
        //
        // Summary:
        //     Normalizes a vector to have unit length.
        //
        // Parameters:
        //   vector:
        //     A vector.
        //
        //   inPlace:
        //     True to perform the operation in-place, overwriting the original array; false
        //     to return a new array.
        //
        // Returns:
        //     A multiple of vector a where ||a|| = 1.
        public static double[] Normalize(this double[] vector, bool inPlace = false);
        //
        // Summary:
        //     Normalizes a vector to have unit length.
        //
        // Parameters:
        //   vector:
        //     A vector.
        //
        //   norm:
        //     A norm to use. Default is Accord.Math.Norm.Euclidean(System.Single[]).
        //
        //   inPlace:
        //     True to perform the operation in-place, overwriting the original array; false
        //     to return a new array.
        //
        // Returns:
        //     A multiple of vector a where ||a|| = 1.
        public static float[] Normalize(this float[] vector, Func<float[], float> norm, bool inPlace = false);
        //
        // Summary:
        //     Normalizes a vector to have unit length.
        //
        // Parameters:
        //   vector:
        //     A vector.
        //
        //   norm:
        //     A norm to use. Default is Accord.Math.Norm.Euclidean(System.Double[]).
        //
        //   inPlace:
        //     True to perform the operation in-place, overwriting the original array; false
        //     to return a new array.
        //
        // Returns:
        //     A multiple of vector a where ||a|| = 1.
        public static double[] Normalize(this double[] vector, Func<double[], double> norm, bool inPlace = false);
        //
        // Summary:
        //     Gets the outer product (matrix product) between two vectors (a*bT).
        //
        // Remarks:
        //     In linear algebra, the outer product typically refers to the tensor product of
        //     two vectors. The result of applying the outer product to a pair of vectors is
        //     a matrix. The name contrasts with the inner product, which takes as input a pair
        //     of vectors and produces a scalar.
        public static double[,] OuterProduct(this double[] a, double[] b);
        //
        // Summary:
        //     Pads a matrix by filling all of its sides with zeros.
        //
        // Parameters:
        //   matrix:
        //     The matrix whose contents will be padded.
        //
        //   all:
        //     How many rows and columns to add at each side of the matrix.
        //
        // Returns:
        //     The original matrix with an extra row of zeros at the selected places.
        public static T[,] Pad<T>(this T[,] matrix, int all);
        //
        // Summary:
        //     Pads a matrix by filling all of its sides with zeros.
        //
        // Parameters:
        //   matrix:
        //     The matrix whose contents will be padded.
        //
        //   rightLeft:
        //     How many columns to add at the sides of the matrix.
        //
        //   topBottom:
        //     How many rows to add at the bottom and top of the matrix.
        //
        // Returns:
        //     The original matrix with an extra row of zeros at the selected places.
        public static T[,] Pad<T>(this T[,] matrix, int topBottom, int rightLeft);
        //
        // Summary:
        //     Pads a matrix by filling all of its sides with zeros.
        //
        // Parameters:
        //   matrix:
        //     The matrix whose contents will be padded.
        //
        //   bottom:
        //     How many rows to add at the bottom.
        //
        //   top:
        //     How many rows to add at the top.
        //
        //   sides:
        //     How many columns to add at the sides.
        //
        // Returns:
        //     The original matrix with an extra row of zeros at the selected places.
        public static T[,] Pad<T>(this T[,] matrix, int top, int sides, int bottom);
        //
        // Summary:
        //     Pads a matrix by filling all of its sides with zeros.
        //
        // Parameters:
        //   matrix:
        //     The matrix whose contents will be padded.
        //
        //   bottom:
        //     How many rows to add at the bottom.
        //
        //   top:
        //     How many rows to add at the top.
        //
        //   left:
        //     How many columns to add at the left side.
        //
        //   right:
        //     How many columns to add at the right side.
        //
        // Returns:
        //     The original matrix with an extra row of zeros at the selected places.
        public static T[,] Pad<T>(this T[,] matrix, int top, int right, int bottom, int left);
        //
        // Summary:
        //     Converts the string representation of a matrix to its double-precision floating-point
        //     number matrix equivalent.
        //
        // Parameters:
        //   str:
        //     The string representation of the matrix.
        //
        // Returns:
        //     A double-precision floating-point number matrix parsed from the given string
        //     using the given format provider.
        public static double[,] Parse(string str);
        //
        // Summary:
        //     Converts the string representation of a matrix to its double-precision floating-point
        //     number matrix equivalent.
        //
        // Parameters:
        //   str:
        //     The string representation of the matrix.
        //
        //   provider:
        //     The format provider to use in the conversion. Default is to use Accord.Math.DefaultMatrixFormatProvider.CurrentCulture.
        //
        // Returns:
        //     A double-precision floating-point number matrix parsed from the given string
        //     using the given format provider.
        public static double[,] Parse(string str, IMatrixFormatProvider provider);
        //
        // Summary:
        //     Converts the string representation of a matrix to its double-precision floating-point
        //     number matrix equivalent.
        //
        // Parameters:
        //   s:
        //     The string representation of the matrix.
        //
        //   provider:
        //     The format provider to use in the conversion. Default is to use Accord.Math.DefaultMatrixFormatProvider.CurrentCulture.
        //
        // Returns:
        //     A double-precision floating-point number matrix parsed from the given string
        //     using the given format provider.
        public static double[][] ParseJagged(string s, IMatrixFormatProvider provider);
        //
        // Summary:
        //     Multiplies a matrix by itself n times.
        public static double[,] Power(this double[,] matrix, int n);
        //
        // Summary:
        //     Gets the product of all elements in a vector.
        public static int Product(this int[] vector);
        //
        // Summary:
        //     Gets the product of all elements in a vector.
        public static double Product(this double[] vector);
        //
        // Summary:
        //     Gets the pseudo-determinant of a matrix.
        public static double PseudoDeterminant(this double[,] matrix);
        //
        // Summary:
        //     Computes the pseudo-inverse of a matrix.
        public static double[][] PseudoInverse(this double[][] matrix);
        //
        // Summary:
        //     Computes the pseudo-inverse of a matrix.
        public static double[,] PseudoInverse(this double[,] matrix);
        //
        // Summary:
        //     Creates a vector with random data drawn from a given distribution.
        public static double[] Random(int size, IRandomNumberGenerator generator);
        //
        // Summary:
        //     Creates a rows-by-cols matrix with uniformly distributed random data.
        public static double[,] Random(int rows, int cols);
        //
        // Summary:
        //     Creates a vector with uniformly distributed random data.
        public static double[] Random(int size, double minValue, double maxValue);
        //
        // Summary:
        //     Creates a vector with uniformly distributed random data.
        public static float[] Random(int size, float minValue, float maxValue);
        //
        // Summary:
        //     Creates a rows-by-cols matrix random data drawn from a given distribution.
        public static double[,] Random(int rows, int cols, IRandomNumberGenerator generator);
        //
        // Summary:
        //     Creates a rows-by-cols matrix with uniformly distributed random data.
        public static double[,] Random(int rows, int cols, double minValue, double maxValue);
        //
        // Summary:
        //     Creates a rows-by-cols matrix with uniformly distributed random data.
        public static double[,] Random(int size, bool symmetric, double minValue, double maxValue);
        //
        // Summary:
        //     Gets the range of the values across a matrix.
        //
        // Parameters:
        //   value:
        //     The matrix whose ranges should be computed.
        public static AForge.DoubleRange Range(this double[,] value);
        //
        // Summary:
        //     Gets the range of the values across a matrix.
        //
        // Parameters:
        //   value:
        //     The matrix whose ranges should be computed.
        public static AForge.IntRange Range(this int[,] value);
        //
        // Summary:
        //     Gets the range of the values in a vector.
        //
        // Parameters:
        //   values:
        //     The matrix whose ranges should be computed.
        public static AForge.IntRange Range(this int[] values);
        //
        // Summary:
        //     Gets the range of the values in a vector.
        //
        // Parameters:
        //   values:
        //     The matrix whose ranges should be computed.
        public static AForge.DoubleRange Range(this double[] values);
        //
        // Summary:
        //     Gets the range of the values across the columns of a matrix.
        //
        // Parameters:
        //   value:
        //     The matrix whose ranges should be computed.
        //
        //   dimension:
        //     Pass 0 if the range should be computed for each of the columns. Pass 1 if the
        //     range should be computed for each row. Default is 0.
        public static AForge.DoubleRange[] Range(this double[][] value, int dimension);
        //
        // Summary:
        //     Gets the range of the values across the columns of a matrix.
        //
        // Parameters:
        //   value:
        //     The matrix whose ranges should be computed.
        //
        //   dimension:
        //     Pass 0 if the range should be computed for each of the columns. Pass 1 if the
        //     range should be computed for each row. Default is 0.
        public static AForge.DoubleRange[] Range(this double[,] value, int dimension);
        //
        // Summary:
        //     Gets the determinant of a matrix.
        public static int Rank(this float[,] matrix);
        //
        // Summary:
        //     Gets the determinant of a matrix.
        public static int Rank(this double[,] matrix);
        //
        // Summary:
        //     Returns a sub matrix extracted from the current matrix.
        //
        // Parameters:
        //   data:
        //     The matrix to return the submatrix from.
        //
        //   rowIndexes:
        //     Array of row indices. Pass null to select all indices.
        //
        //   columnIndexes:
        //     Array of column indices. Pass null to select all indices.
        public static T[,] Remove<T>(this T[,] data, int[] rowIndexes, int[] columnIndexes);
        //
        // Summary:
        //     Removes an element from a vector.
        public static T[] RemoveAt<T>(this T[] array, int index);
        //
        // Summary:
        //     Returns a new matrix without one of its columns.
        public static T[,] RemoveColumn<T>(this T[,] matrix, int index);
        //
        // Summary:
        //     Returns a new matrix without one of its columns.
        public static T[][] RemoveColumn<T>(this T[][] matrix, int index);
        //
        // Summary:
        //     Returns a new matrix without one of its rows.
        public static T[,] RemoveRow<T>(this T[,] matrix, int index);
        //
        // Summary:
        //     Transforms a jagged array matrix into a single vector.
        //
        // Parameters:
        //   array:
        //     A jagged array.
        public static T[] Reshape<T>(this T[][] array);
        //
        // Summary:
        //     Transforms a matrix into a single vector.
        //
        // Parameters:
        //   matrix:
        //     A matrix.
        public static T[] Reshape<T>(this T[,] matrix);
        //
        // Summary:
        //     Transforms a jagged array matrix into a single vector.
        //
        // Parameters:
        //   array:
        //     A jagged array.
        //
        //   dimension:
        //     The direction to perform copying. Pass 0 to perform a row-wise copy. Pass 1 to
        //     perform a column-wise copy. Default is 0.
        public static T[] Reshape<T>(this T[][] array, int dimension);
        //
        // Summary:
        //     Transforms a matrix into a single vector.
        //
        // Parameters:
        //   matrix:
        //     A matrix.
        //
        //   dimension:
        //     The direction to perform copying. Pass 0 to perform a row-wise copy. Pass 1 to
        //     perform a column-wise copy. Default is 0.
        public static T[] Reshape<T>(this T[,] matrix, int dimension);
        //
        // Summary:
        //     Transforms a vector into a matrix of given dimensions.
        public static T[,] Reshape<T>(this T[] array, int rows, int cols);
        //
        // Summary:
        //     Rounds a double-precision floating-point number array to a specified number of
        //     fractional digits.
        public static double[] Round(double[] vector, int decimals = 0);
        //
        // Summary:
        //     Rounds a double-precision floating-point matrix to a specified number of fractional
        //     digits.
        public static double[,] Round(this double[,] matrix, int decimals = 0);
        //
        // Summary:
        //     Gets the number of rows in a jagged matrix.
        //
        // Parameters:
        //   matrix:
        //     The matrix whose number of rows must be computed.
        //
        // Type parameters:
        //   T:
        //     The type of the elements in the matrix.
        //
        // Returns:
        //     The number of rows in the matrix.
        public static int Rows<T>(this T[][] matrix);
        //
        // Summary:
        //     Gets the number of rows in a multidimensional matrix.
        //
        // Parameters:
        //   matrix:
        //     The matrix whose number of rows must be computed.
        //
        // Type parameters:
        //   T:
        //     The type of the elements in the matrix.
        //
        // Returns:
        //     The number of rows in the matrix.
        public static int Rows<T>(this T[,] matrix);
        //
        // Summary:
        //     Creates a matrix with a single row vector.
        public static T[,] RowVector<T>(params T[] values);
        //
        // Summary:
        //     Stores a column vector into the given column position of the matrix.
        public static T[][] SetColumn<T>(this T[][] m, int index, T[] column);
        //
        // Summary:
        //     Stores a column vector into the given column position of the matrix.
        public static T[,] SetColumn<T>(this T[,] m, int index, T[] column);
        //
        // Summary:
        //     Compares two enumerables for set equality. Two enumerables are set equal if they
        //     contain the same elements, but not necessarily in the same order.
        //
        // Parameters:
        //   list1:
        //     The first set.
        //
        //   list2:
        //     The first set.
        //
        // Type parameters:
        //   T:
        //     The element type.
        //
        // Returns:
        //     True if the two sets contains the same elements, false otherwise.
        public static bool SetEquals<T>(this IEnumerable<T> list1, IEnumerable<T> list2);
        //
        // Summary:
        //     Stores a row vector into the given row position of the matrix.
        public static T[][] SetRow<T>(this T[][] m, int index, T[] row);
        //
        // Summary:
        //     Stores a row vector into the given row position of the matrix.
        public static T[,] SetRow<T>(this T[,] m, int index, T[] row);
        //
        // Summary:
        //     Elementwise absolute value.
        public static double[] Sign(this double[] value);
        //
        // Summary:
        //     Returns the solution matrix if the matrix is square or the least squares solution
        //     otherwise.
        //
        // Parameters:
        //   matrix:
        //     The matrix for the linear problem.
        //
        //   rightSide:
        //     The right side b.
        //
        //   leastSquares:
        //     True to produce a solution even if the matrix is singular; false otherwise. Default
        //     is false.
        //
        // Remarks:
        //     Please note that this does not check if the matrix is non-singular before attempting
        //     to solve. If a least squares solution is desired in case the matrix is singular,
        //     pass true to the leastSquares parameter when calling this function.
        public static double[] Solve(this double[,] matrix, double[] rightSide, bool leastSquares = false);
        //
        // Summary:
        //     Returns the solution matrix if the matrix is square or the least squares solution
        //     otherwise.
        //
        // Parameters:
        //   matrix:
        //     The matrix for the linear problem.
        //
        //   rightSide:
        //     The right side b.
        //
        //   leastSquares:
        //     True to produce a solution even if the matrix is singular; false otherwise. Default
        //     is false.
        //
        // Remarks:
        //     Please note that this does not check if the matrix is non-singular before attempting
        //     to solve. If a least squares solution is desired in case the matrix is singular,
        //     pass true to the leastSquares parameter when calling this function.
        public static double[][] Solve(this double[][] matrix, double[][] rightSide, bool leastSquares = false);
        //
        // Summary:
        //     Returns the solution matrix if the matrix is square or the least squares solution
        //     otherwise.
        //
        // Parameters:
        //   matrix:
        //     The matrix for the linear problem.
        //
        //   rightSide:
        //     The right side b.
        //
        //   leastSquares:
        //     True to produce a solution even if the matrix is singular; false otherwise. Default
        //     is false.
        //
        // Remarks:
        //     Please note that this does not check if the matrix is non-singular before attempting
        //     to solve. If a least squares solution is desired in case the matrix is singular,
        //     pass true to the leastSquares parameter when calling this function.
        public static double[] Solve(this double[][] matrix, double[] rightSide, bool leastSquares = false);
        //
        // Summary:
        //     Returns the solution matrix if the matrix is square or the least squares solution
        //     otherwise.
        //
        // Parameters:
        //   matrix:
        //     The matrix for the linear problem.
        //
        //   rightSide:
        //     The right side b.
        //
        //   leastSquares:
        //     True to produce a solution even if the matrix is singular; false otherwise. Default
        //     is false.
        //
        // Remarks:
        //     Please note that this does not check if the matrix is non-singular before attempting
        //     to solve. If a least squares solution is desired in case the matrix is singular,
        //     pass true to the leastSquares parameter when calling this function.
        public static double[,] Solve(this double[,] matrix, double[,] rightSide, bool leastSquares = false);
        //
        // Summary:
        //     Sorts the columns of a matrix by sorting keys.
        //
        // Parameters:
        //   keys:
        //     The key value for each column.
        //
        //   values:
        //     The matrix to be sorted.
        //
        //   comparer:
        //     The comparer to use.
        public static TValue[][] Sort<TKey, TValue>(TKey[] keys, TValue[][] values, IComparer<TKey> comparer);
        //
        // Summary:
        //     Sorts the columns of a matrix by sorting keys.
        //
        // Parameters:
        //   keys:
        //     The key value for each column.
        //
        //   values:
        //     The matrix to be sorted.
        //
        //   comparer:
        //     The comparer to use.
        public static TValue[,] Sort<TKey, TValue>(TKey[] keys, TValue[,] values, IComparer<TKey> comparer);
        //
        // Summary:
        //     Splits a given vector into a smaller vectors of the given size. This operation
        //     can be reverted using Accord.Math.Matrix.Merge``1(``0[][],System.Int32).
        //
        // Parameters:
        //   vector:
        //     The vector to be splitted.
        //
        //   size:
        //     The size of the resulting vectors.
        //
        // Returns:
        //     An array of vectors containing the subdivisions of the given vector.
        public static T[][] Split<T>(this T[] vector, int size);
        //
        // Summary:
        //     Elementwise Square root.
        public static double[,] Sqrt(this double[,] value);
        //
        // Summary:
        //     Elementwise Square root.
        public static double[] Sqrt(this double[] value);
        //
        // Summary:
        //     Combines matrices vertically.
        public static T[][] Stack<T>(params T[][][] matrices);
        //
        // Summary:
        //     Combines matrices vertically.
        public static T[,] Stack<T>(params T[][,] matrices);
        //
        // Summary:
        //     Combines vectors vertically.
        public static T[,] Stack<T>(params T[] elements);
        //
        // Summary:
        //     Combines vectors vertically.
        public static T[,] Stack<T>(params T[][] vectors);
        //
        // Summary:
        //     Combines matrices vertically.
        public static T[,] Stack<T>(this T[,] matrix, T[] vector);
        //
        // Summary:
        //     Combines vectors vertically.
        public static T[,] Stack<T>(this T[] vector, T element);
        //
        // Summary:
        //     Combines vectors vertically.
        public static T[][] Stack<T>(this T[][] a, T[][] b);
        //
        // Summary:
        //     Combines vectors vertically.
        public static T[,] Stack<T>(this T[] a, T[] b);
        //
        // Summary:
        //     Returns subgroups extracted from the given vector.
        //
        // Parameters:
        //   values:
        //     The vector to extract the groups from.
        //
        //   groups:
        //     The vector of indices for the groups.
        public static T[][] Subgroups<T>(this T[] values, int[] groups);
        //
        // Summary:
        //     Returns subgroups extracted from the given vector, assuming that the groups should
        //     have been labels from 0 until the given number of classes.
        //
        // Parameters:
        //   values:
        //     The vector to extract the groups from.
        //
        //   groups:
        //     The vector of indices for the groups.
        //
        //   classes:
        //     The number of classes in the groups. Specifying this parameter will make the
        //     method assume the groups should be containing integer labels ranging from 0 until
        //     the number of classes.
        public static T[][] Subgroups<T>(this T[] values, int[] groups, int classes);
        //
        // Summary:
        //     Returns a subvector extracted from the current vector.
        //
        // Parameters:
        //   source:
        //     The vector to return the subvector from.
        //
        //   indexes:
        //     Array of indices.
        public static T[] Submatrix<T>(this T[] source, IList<int> indexes);
        //
        // Summary:
        //     Returns a subvector extracted from the current vector.
        //
        // Remarks:
        //     Routine adapted from Lutz Roeder's Mapack for .NET, September 2000.
        public static T[] Submatrix<T>(this T[] source, int first);
        //
        // Summary:
        //     Returns a subvector extracted from the current vector.
        //
        // Parameters:
        //   source:
        //     The vector to return the subvector from.
        //
        //   indexes:
        //     Array of indices.
        public static T[] Submatrix<T>(this T[] source, int[] indexes);
        //
        // Summary:
        //     Returns a subvector extracted from the current vector.
        //
        // Parameters:
        //   source:
        //     The vector to return the subvector from.
        //
        //   indexes:
        //     Array of indices.
        public static List<T> Submatrix<T>(this List<T> source, int[] indexes);
        //
        // Summary:
        //     Returns a sub matrix extracted from the current matrix.
        //
        // Parameters:
        //   source:
        //     The matrix to return the submatrix from.
        //
        //   rowIndexes:
        //     Array of row indices
        public static T[,] Submatrix<T>(this T[,] source, int[] rowIndexes);
        //
        // Summary:
        //     Returns a sub matrix extracted from the current matrix.
        //
        // Parameters:
        //   source:
        //     The matrix to return the submatrix from.
        //
        //   indexes:
        //     Array of indices.
        //
        //   transpose:
        //     True to return a transposed matrix; false otherwise.
        public static T[][] Submatrix<T>(this T[][] source, int[] indexes, bool transpose = false);
        //
        // Summary:
        //     Returns a subvector extracted from the current vector.
        //
        // Parameters:
        //   source:
        //     The vector to return the subvector from.
        //
        //   startRow:
        //     Starting index.
        //
        //   endRow:
        //     End index.
        //
        // Remarks:
        //     Routine adapted from Lutz Roeder's Mapack for .NET, September 2000.
        public static T[] Submatrix<T>(this T[] source, int startRow, int endRow);
        //
        // Summary:
        //     Returns a sub matrix extracted from the current matrix.
        //
        // Parameters:
        //   source:
        //     The matrix to return the submatrix from.
        //
        //   rowIndexes:
        //     Array of row indices. Pass null to select all indices.
        //
        //   columnIndexes:
        //     Array of column indices. Pass null to select all indices.
        public static T[,] Submatrix<T>(this T[,] source, int[] rowIndexes, int[] columnIndexes);
        //
        // Summary:
        //     Returns a sub matrix extracted from the current matrix.
        //
        // Parameters:
        //   source:
        //     The matrix to return the submatrix from.
        //
        //   rowIndexes:
        //     Array of row indices
        //
        //   startColumn:
        //     Start column index
        //
        //   endColumn:
        //     End column index
        //
        // Remarks:
        //     Routine adapted from Lutz Roeder's Mapack for .NET, September 2000.
        public static T[,] Submatrix<T>(this T[,] source, int[] rowIndexes, int startColumn, int endColumn);
        //
        // Summary:
        //     Returns a sub matrix extracted from the current matrix.
        //
        // Parameters:
        //   source:
        //     The matrix to return the submatrix from.
        //
        //   rowIndexes:
        //     Array of row indices. Pass null to select all indices.
        //
        //   columnIndexes:
        //     Array of column indices. Pass null to select all indices.
        //
        //   reuseMemory:
        //     Set to true to avoid memory allocations when possible. This might result on the
        //     shallow copies of some elements. Default is false (default is to always provide
        //     a true, deep copy of every element in the matrices, using more memory).
        public static T[][] Submatrix<T>(this T[][] source, int[] rowIndexes, int[] columnIndexes, bool reuseMemory = false);
        //
        // Summary:
        //     Returns a sub matrix extracted from the current matrix.
        //
        // Parameters:
        //   source:
        //     The matrix to return the submatrix from.
        //
        //   startRow:
        //     Starting row index
        //
        //   endRow:
        //     End row index
        //
        //   columnIndexes:
        //     Array of column indices
        //
        // Remarks:
        //     Routine adapted from Lutz Roeder's Mapack for .NET, September 2000.
        public static T[][] Submatrix<T>(this T[][] source, int startRow, int endRow, int[] columnIndexes);
        //
        // Summary:
        //     Returns a sub matrix extracted from the current matrix.
        //
        // Parameters:
        //   source:
        //     The matrix to return the submatrix from.
        //
        //   startRow:
        //     Starting row index
        //
        //   endRow:
        //     End row index
        //
        //   columnIndexes:
        //     Array of column indices
        //
        // Remarks:
        //     Routine adapted from Lutz Roeder's Mapack for .NET, September 2000.
        public static T[,] Submatrix<T>(this T[,] source, int startRow, int endRow, int[] columnIndexes);
        //
        // Summary:
        //     Returns a sub matrix extracted from the current matrix.
        //
        // Parameters:
        //   source:
        //     The matrix to return the submatrix from.
        //
        //   destination:
        //     The matrix where results should be stored.
        //
        //   rowIndexes:
        //     Array of row indices. Pass null to select all indices.
        //
        //   columnIndexes:
        //     Array of column indices. Pass null to select all indices.
        public static void Submatrix<T>(this T[,] source, T[,] destination, int[] rowIndexes, int[] columnIndexes);
        //
        // Summary:
        //     Returns a sub matrix extracted from the current matrix.
        //
        // Parameters:
        //   source:
        //     The matrix to return the submatrix from.
        //
        //   rowIndexes:
        //     Array of row indices
        //
        //   startColumn:
        //     Start column index
        //
        //   endColumn:
        //     End column index
        //
        //   reuseMemory:
        //     Set to true to avoid memory allocations when possible. This might result on the
        //     shallow copies of some elements. Default is false (default is to always provide
        //     a true, deep copy of every element in the matrices, using more memory).
        //
        // Remarks:
        //     Routine adapted from Lutz Roeder's Mapack for .NET, September 2000.
        public static T[][] Submatrix<T>(this T[][] source, int[] rowIndexes, int startColumn, int endColumn, bool reuseMemory = false);
        //
        // Summary:
        //     Returns a sub matrix extracted from the current matrix.
        //
        // Parameters:
        //   source:
        //     The matrix to return the submatrix from.
        //
        //   startRow:
        //     Start row index
        //
        //   endRow:
        //     End row index
        //
        //   startColumn:
        //     Start column index
        //
        //   endColumn:
        //     End column index
        public static T[][] Submatrix<T>(this T[][] source, int startRow, int endRow, int startColumn, int endColumn);
        //
        // Summary:
        //     Returns a sub matrix extracted from the current matrix.
        //
        // Parameters:
        //   source:
        //     The matrix to return the submatrix from.
        //
        //   startRow:
        //     Start row index
        //
        //   endRow:
        //     End row index
        //
        //   startColumn:
        //     Start column index
        //
        //   endColumn:
        //     End column index
        public static T[,] Submatrix<T>(this T[,] source, int startRow, int endRow, int startColumn, int endColumn);
        //
        // Summary:
        //     Returns a sub matrix extracted from the current matrix.
        //
        // Parameters:
        //   source:
        //     The matrix to return the submatrix from.
        //
        //   destination:
        //     The matrix where results should be stored.
        //
        //   startRow:
        //     Start row index
        //
        //   endRow:
        //     End row index
        //
        //   startColumn:
        //     Start column index
        //
        //   endColumn:
        //     End column index
        public static void Submatrix<T>(this T[,] source, T[,] destination, int startRow, int endRow, int startColumn, int endColumn);
        //
        // Summary:
        //     Elementwise subtracts an element of a matrix from a scalar.
        //
        // Parameters:
        //   x:
        //     A scalar.
        //
        //   matrix:
        //     A matrix.
        //
        // Returns:
        //     The elementwise subtraction of scalar a and matrix b.
        public static double[,] Subtract(this int x, double[,] matrix);
        //
        // Summary:
        //     Subtracts a scalar from a vector.
        //
        // Parameters:
        //   vector:
        //     A vector.
        //
        //   x:
        //     A scalar.
        //
        // Returns:
        //     The subtraction of the given vector elements from the given scalar.
        public static double[] Subtract(this int x, double[] vector);
        //
        // Summary:
        //     Subtracts a scalar from each element of a matrix.
        public static double[,] Subtract(this double[,] matrix, double x);
        //
        // Summary:
        //     Elementwise subtracts an element of a matrix from a scalar.
        //
        // Parameters:
        //   x:
        //     A scalar.
        //
        //   matrix:
        //     A matrix.
        //
        // Returns:
        //     The elementwise subtraction of scalar a and matrix b.
        public static double[,] Subtract(this double x, double[,] matrix);
        //
        // Summary:
        //     Subtracts a scalar from a vector.
        //
        // Parameters:
        //   vector:
        //     A vector.
        //
        //   x:
        //     A scalar.
        //
        // Returns:
        //     The subtraction of the given vector elements from the given scalar.
        public static double[] Subtract(this double x, double[] vector);
        //
        // Summary:
        //     Subtracts two matrices.
        //
        // Parameters:
        //   a:
        //     A matrix.
        //
        //   b:
        //     A matrix.
        //
        // Returns:
        //     The subtraction of the given matrices.
        public static double[][] Subtract(this double[][] a, double[][] b);
        //
        // Summary:
        //     Subtracts two matrices.
        //
        // Parameters:
        //   a:
        //     A matrix.
        //
        //   b:
        //     A matrix.
        //
        //   inPlace:
        //     True to perform the operation in-place, overwriting the original matrix; false
        //     to return a new matrix.
        //
        // Returns:
        //     The subtraction of the given matrices.
        public static double[,] Subtract(this double[,] a, double[,] b, bool inPlace = false);
        //
        // Summary:
        //     Adds a vector to a column or row of a matrix.
        //
        // Parameters:
        //   a:
        //     A matrix.
        //
        //   b:
        //     A vector.
        //
        //   dimension:
        //     The dimension to add the vector to.
        public static double[][] Subtract(this double[][] a, double[] b, int dimension = 0);
        //
        // Summary:
        //     Subtracts two vectors.
        //
        // Parameters:
        //   a:
        //     A vector.
        //
        //   b:
        //     A vector.
        //
        //   inPlace:
        //     True to perform the operation in-place, overwriting the original array; false
        //     to return a new array.
        //
        // Returns:
        //     The subtraction of vector b from vector a.
        public static int[] Subtract(this int[] a, int[] b, bool inPlace = false);
        //
        // Summary:
        //     Subtracts a scalar from a vector.
        //
        // Parameters:
        //   vector:
        //     A vector.
        //
        //   x:
        //     A scalar.
        //
        //   inPlace:
        //     True to perform the operation in-place, overwriting the original array; false
        //     to return a new array.
        //
        // Returns:
        //     The subtraction of given scalar from all elements in the given vector.
        public static double[] Subtract(this double[] vector, double x, bool inPlace = false);
        //
        // Summary:
        //     Subtracts a scalar from a vector.
        //
        // Parameters:
        //   vector:
        //     A vector.
        //
        //   x:
        //     A scalar.
        //
        //   inPlace:
        //     True to perform the operation in-place, overwriting the original array; false
        //     to return a new array.
        //
        // Returns:
        //     The subtraction of given scalar from all elements in the given vector.
        public static int[] Subtract(this int[] vector, int x, bool inPlace = false);
        //
        // Summary:
        //     Subtracts two vectors.
        //
        // Parameters:
        //   a:
        //     A vector.
        //
        //   b:
        //     A vector.
        //
        //   inPlace:
        //     True to perform the operation in-place, overwriting the original array; false
        //     to return a new array.
        //
        // Returns:
        //     The subtraction of vector b from vector a.
        public static double[] Subtract(this double[] a, double[] b, bool inPlace = false);
        //
        // Summary:
        //     Adds a vector to a column or row of a matrix.
        //
        // Parameters:
        //   a:
        //     A matrix.
        //
        //   b:
        //     A vector.
        //
        //   dimension:
        //     The dimension to add the vector to.
        public static double[,] Subtract(this double[,] a, double[] b, int dimension = 0);
        //
        // Summary:
        //     Subtracts a scalar from the diagonal of a matrix.
        //
        // Parameters:
        //   matrix:
        //     A matrix.
        //
        //   scalar:
        //     A scalar.
        //
        //   inPlace:
        //     True to perform the operation in-place, overwriting the original matrix; false
        //     to return a new matrix.
        public static double[,] SubtractFromDiagonal(this double[,] matrix, double scalar, bool inPlace = false);
        //
        // Summary:
        //     Subtracts a scalar from the diagonal of a matrix.
        //
        // Parameters:
        //   matrix:
        //     A matrix.
        //
        //   scalar:
        //     A scalar.
        //
        //   inPlace:
        //     True to perform the operation in-place, overwriting the original matrix; false
        //     to return a new matrix.
        public static double[][] SubtractFromDiagonal(this double[][] matrix, double scalar, bool inPlace = false);
        //
        // Summary:
        //     Gets the sum of all elements in a vector.
        public static int Sum(this int[] vector);
        //
        // Summary:
        //     Calculates the matrix Sum vector.
        //
        // Parameters:
        //   matrix:
        //     A matrix whose sums will be calculated.
        //
        // Returns:
        //     Returns a vector containing the sums of each variable in the given matrix.
        public static int[] Sum(this int[,] matrix);
        //
        // Summary:
        //     Gets the sum of all elements in a vector.
        public static double Sum(this double[] vector);
        //
        // Summary:
        //     Gets the sum of all elements in a vector.
        public static float Sum(this float[] vector);
        //
        // Summary:
        //     Calculates the matrix Sum vector.
        //
        // Parameters:
        //   matrix:
        //     A matrix whose sums will be calculated.
        //
        // Returns:
        //     Returns a vector containing the sums of each variable in the given matrix.
        public static double[] Sum(this double[][] matrix);
        //
        // Summary:
        //     Calculates the matrix Sum vector.
        //
        // Parameters:
        //   matrix:
        //     A matrix whose sums will be calculated.
        //
        // Returns:
        //     Returns a vector containing the sums of each variable in the given matrix.
        public static double[] Sum(this double[,] matrix);
        //
        // Summary:
        //     Calculates the matrix Sum vector.
        //
        // Parameters:
        //   matrix:
        //     A matrix whose sums will be calculated.
        //
        // Returns:
        //     Returns a vector containing the sums of each variable in the given matrix.
        public static float[] Sum(this float[,] matrix);
        //
        // Summary:
        //     Calculates the matrix Sum vector.
        //
        // Parameters:
        //   matrix:
        //     A matrix whose sums will be calculated.
        //
        //   dimension:
        //     The dimension in which the sum will be calculated.
        //
        // Returns:
        //     Returns a vector containing the sums of each variable in the given matrix.
        public static double[] Sum(this double[][] matrix, int dimension);
        //
        // Summary:
        //     Calculates the matrix Sum vector.
        //
        // Parameters:
        //   matrix:
        //     A matrix whose sums will be calculated.
        //
        //   dimension:
        //     The dimension in which the sum will be calculated. Default is 0.
        //
        // Returns:
        //     Returns a vector containing the sums of each variable in the given matrix.
        public static int[] Sum(this int[,] matrix, int dimension);
        //
        // Summary:
        //     Calculates the matrix Sum vector.
        //
        // Parameters:
        //   matrix:
        //     A matrix whose sums will be calculated.
        //
        //   dimension:
        //     The dimension in which the sum will be calculated.
        //
        // Returns:
        //     Returns a vector containing the sums of each variable in the given matrix.
        public static float[] Sum(this float[,] matrix, int dimension);
        //
        // Summary:
        //     Calculates the matrix Sum vector.
        //
        // Parameters:
        //   matrix:
        //     A matrix whose sums will be calculated.
        //
        //   dimension:
        //     The dimension in which the sum will be calculated.
        //
        // Returns:
        //     Returns a vector containing the sums of each variable in the given matrix.
        public static double[] Sum(this double[,] matrix, int dimension);
        //
        // Summary:
        //     Performs an in-place re-ordering of elements in a given array using the given
        //     vector of indices.
        //
        // Parameters:
        //   values:
        //     The values to be ordered.
        //
        //   indices:
        //     The new index positions.
        public static void Swap<T>(this T[] values, int[] indices);
        //
        // Summary:
        //     Converts the values of a vector using the given converter expression.
        //
        // Parameters:
        //   array:
        //     The vector or array to be converted.
        //
        // Type parameters:
        //   TOutput:
        //     The type of the output.
        public static TOutput To<TOutput>(this Array array) where TOutput : class, ICloneable, IList, ICollection, IEnumerable, IStructuralComparable, IStructuralEquatable;
        //
        // Summary:
        //     Converts an object into another type, irrespective of whether the conversion
        //     can be done at compile time or not. This can be used to convert generic types
        //     to numeric types during runtime.
        //
        // Parameters:
        //   value:
        //     The value to be converted.
        //
        // Type parameters:
        //   T:
        //     The destination type.
        //
        // Returns:
        //     The result of the conversion.
        public static T To<T>(this object value);
        //
        // Summary:
        //     Converts a DataColumn to a double[] array.
        public static double[] ToArray(this DataColumn column);
        //
        // Summary:
        //     Converts a DataTable to a double[][] array.
        public static double[][] ToArray(this DataTable table);
        //
        // Summary:
        //     Converts a DataTable to a double[][] array.
        public static double[][] ToArray(this DataTable table, params string[] columnNames);
        //
        // Summary:
        //     Converts a DataColumn to a double[] array.
        public static double[] ToArray(this DataColumn column, IFormatProvider provider);
        //
        // Summary:
        //     Converts a DataColumn to a double[] array.
        public static double[] ToArray(this DataRow row, params string[] colNames);
        //
        // Summary:
        //     Converts a DataTable to a double[][] array.
        public static double[][] ToArray(this DataTable table, out string[] columnNames);
        //
        // Summary:
        //     Converts a DataTable to a double[][] array.
        public static double[][] ToArray(this DataTable table, IFormatProvider provider);
        //
        // Summary:
        //     Converts a DataColumn to a double[] array.
        public static double[] ToArray(this DataRow row, IFormatProvider provider, params string[] colNames);
        //
        // Summary:
        //     Converts a DataTable to a double[][] array.
        public static double[][] ToArray(this DataTable table, IFormatProvider provider, out string[] columnNames);
        //
        // Summary:
        //     Converts a DataColumn to a double[] array.
        public static T[] ToArray<T>(this DataColumn column);
        //
        // Summary:
        //     Converts a DataTable to a double[][] array.
        public static T[][] ToArray<T>(this DataTable table);
        //
        // Summary:
        //     Converts a multidimensional array into a jagged array.
        public static T[][] ToArray<T>(this T[,] matrix);
        //
        // Summary:
        //     Converts a DataTable to a double[][] array.
        public static T[][] ToArray<T>(this DataTable table, out string[] columnNames);
        //
        // Summary:
        //     Converts a DataTable to a double[][] array.
        public static T[][] ToArray<T>(this DataTable table, params string[] columnNames);
        //
        // Summary:
        //     Converts a DataTable to a double[][] array.
        public static T[][] ToArray<T>(this DataTable table, IFormatProvider provider);
        //
        // Summary:
        //     Converts a multidimensional array into a jagged array.
        public static T[][] ToArray<T>(this T[,] matrix, bool transpose);
        //
        // Summary:
        //     Converts a DataColumn to a generic array.
        public static T[] ToArray<T>(this DataRow row, params string[] colNames);
        //
        // Summary:
        //     Converts a DataColumn to a double[] array.
        public static T[] ToArray<T>(this DataColumn column, IFormatProvider provider);
        //
        // Summary:
        //     Converts a DataTable to a generic array.
        public static T[] ToArray<T>(this DataTable table, string columnName);
        //
        // Summary:
        //     Converts an array into a multidimensional array.
        public static T[][] ToArray<T>(this T[] array, bool asColumnVector = true);
        //
        // Summary:
        //     Converts a DataTable to a generic array.
        public static T[] ToArray<T>(this DataTable table, IFormatProvider provider, string columnName);
        //
        // Summary:
        //     Converts a DataColumn to a generic array.
        public static T[] ToArray<T>(this DataRow row, IFormatProvider provider, params string[] colNames);
        //
        // Summary:
        //     Converts a DataTable to a double[][] array.
        public static T[][] ToArray<T>(this DataTable table, IFormatProvider provider, out string[] columnNames);
        //
        // Summary:
        //     Converts an integer matrix to double values.
        //
        // Parameters:
        //   matrix:
        //     The matrix to be converted.
        public static double[][] ToDouble(this int[][] matrix);
        //
        // Summary:
        //     Converts an integer matrix to double values.
        //
        // Parameters:
        //   matrix:
        //     The matrix to be converted.
        public static double[][] ToDouble(this byte[][] matrix);
        //
        // Summary:
        //     Converts a integer vector into a double vector.
        //
        // Parameters:
        //   vector:
        //     The vector to be converted.
        public static double[] ToDouble(this int[] vector);
        //
        // Summary:
        //     Converts an integer matrix to double values.
        //
        // Parameters:
        //   matrix:
        //     The matrix to be converted.
        public static double[][] ToDouble(this sbyte[][] matrix);
        //
        // Summary:
        //     Converts a double-precision floating point multidimensional array into a single-precision
        //     floating point multidimensional array.
        public static double[] ToDouble(this float[] vector);
        //
        // Summary:
        //     Converts a double-precision floating point multidimensional array into a single-precision
        //     floating point multidimensional array.
        public static double[] ToDouble(this short[] vector);
        //
        // Summary:
        //     Converts a byte multidimensional array into a double- precision floating point
        //     multidimensional array.
        public static double[,] ToDouble(this byte[,] matrix);
        //
        // Summary:
        //     Converts a double-precision floating point multidimensional array into a single-precision
        //     floating point multidimensional array.
        public static double[,] ToDouble(this int[,] matrix);
        //
        // Summary:
        //     Converts a double-precision floating point multidimensional array into a double-precision
        //     floating point multidimensional array.
        public static double[,] ToDouble(this float[,] matrix);
        //
        // Summary:
        //     Truncates a double matrix to integer values.
        //
        // Parameters:
        //   matrix:
        //     The matrix to be truncated.
        public static int[][] ToInt32(this double[][] matrix);
        //
        // Summary:
        //     Converts a matrix to integer values.
        //
        // Parameters:
        //   matrix:
        //     The matrix to be converted.
        public static int[][] ToInt32(this byte[][] matrix);
        //
        // Summary:
        //     Truncates a double vector to integer values.
        //
        // Parameters:
        //   vector:
        //     The vector to be truncated.
        public static int[] ToInt32(this double[] vector);
        //
        // Summary:
        //     Converts a vector to integer values.
        //
        // Parameters:
        //   vector:
        //     The vector to be converted.
        public static int[] ToInt32(this byte[] vector);
        //
        // Summary:
        //     Converts a vector to integer values.
        //
        // Parameters:
        //   vector:
        //     The vector to be converted.
        public static int[] ToInt32(this sbyte[] vector);
        //
        // Summary:
        //     Converts a matrix to integer values.
        //
        // Parameters:
        //   matrix:
        //     The matrix to be converted.
        public static int[][] ToInt32(this sbyte[][] matrix);
        //
        // Summary:
        //     Truncates a double matrix to integer values.
        //
        // Parameters:
        //   matrix:
        //     The matrix to be truncated.
        public static int[,] ToInt32(this double[,] matrix);
        //
        // Summary:
        //     Converts a DataColumn to a int[] array.
        [Obsolete("Use ToArray<T> instead.")]
        public static int[] ToInt32Array(this DataColumn column);
        //
        // Summary:
        //     Converts a DataTable to a int[][] array.
        [Obsolete("Use ToArray<T> instead.")]
        public static int[][] ToIntArray(this DataTable table, params string[] columnNames);
        //
        // Summary:
        //     Converts a DataTable to a double[,] array.
        public static double[,] ToMatrix(this DataTable table);
        //
        // Summary:
        //     Converts a DataTable to a double[,] array.
        public static double[,] ToMatrix(this DataTable table, params string[] columnNames);
        //
        // Summary:
        //     Converts a DataTable to a double[,] array.
        public static double[,] ToMatrix(this DataTable table, IFormatProvider provider);
        //
        // Summary:
        //     Converts a DataTable to a double[,] array.
        public static double[,] ToMatrix(this DataTable table, out string[] columnNames);
        //
        // Summary:
        //     Converts an array into a multidimensional array.
        public static T[,] ToMatrix<T>(this T[] array);
        //
        // Summary:
        //     Converts a DataTable to a double[,] array.
        public static T[,] ToMatrix<T>(this DataTable table);
        //
        // Summary:
        //     Converts a jagged-array into a multidimensional array.
        public static T[,] ToMatrix<T>(this T[][] array);
        //
        // Summary:
        //     Converts an array into a multidimensional array.
        public static T[,] ToMatrix<T>(this T[] array, bool asColumnVector = false);
        //
        // Summary:
        //     Converts a DataTable to a double[,] array.
        public static T[,] ToMatrix<T>(this DataTable table, params string[] columnNames);
        //
        // Summary:
        //     Converts a DataTable to a double[,] array.
        public static T[,] ToMatrix<T>(this DataTable table, IFormatProvider provider);
        //
        // Summary:
        //     Converts a DataTable to a double[,] array.
        public static T[,] ToMatrix<T>(this DataTable table, out string[] columnNames);
        //
        // Summary:
        //     Converts a jagged-array into a multidimensional array.
        public static T[,] ToMatrix<T>(this T[][] array, bool transpose);
        //
        // Summary:
        //     Converts a DataTable to a double[,] array.
        public static T[,] ToMatrix<T>(this DataTable table, IFormatProvider provider, params string[] columnNames);
        //
        // Summary:
        //     Converts a DataTable to a double[,] array.
        public static T[,] ToMatrix<T>(this DataTable table, out string[] columnNames, IFormatProvider provider);
        //
        // Summary:
        //     Retrieves the top count values of an array.
        public static int[] Top<T>(this T[] values, int count, bool inPlace = false) where T : IComparable;
        //
        // Summary:
        //     Converts a double vector into a single vector.
        //
        // Parameters:
        //   vector:
        //     The vector to be converted.
        public static float[] ToSingle(this double[] vector);
        //
        // Summary:
        //     Converts an integer matrix to double values.
        //
        // Parameters:
        //   matrix:
        //     The matrix to be converted.
        public static float[][] ToSingle(this double[][] matrix);
        //
        // Summary:
        //     Converts a single-precision floating point multidimensional array into a double-precision
        //     floating point multidimensional array.
        public static float[,] ToSingle(this double[,] matrix);
        //
        // Summary:
        //     Returns a System.String that represents a matrix.
        //
        // Parameters:
        //   matrix:
        //     The matrix.
        //
        // Returns:
        //     A System.String that represents this instance.
        public static string ToString<T>(this T[][] matrix);
        //
        // Summary:
        //     Returns a System.String that represents an array.
        //
        // Parameters:
        //   array:
        //     The array.
        //
        // Returns:
        //     A System.String that represents this instance.
        public static string ToString<T>(this T[] array);
        //
        // Summary:
        //     Returns a System.String represents a matrix.
        //
        // Parameters:
        //   matrix:
        //     The matrix.
        //
        // Returns:
        //     A System.String that represents this instance.
        public static string ToString<T>(this T[,] matrix);
        //
        // Summary:
        //     Returns a System.String that represents an array.
        //
        // Parameters:
        //   array:
        //     The array.
        //
        //   format:
        //     The format to use when creating the resulting string.
        //
        // Returns:
        //     A System.String that represents this instance.
        public static string ToString<T>(this T[] array, string format);
        //
        // Summary:
        //     Returns a System.String that represents a matrix.
        //
        // Parameters:
        //   matrix:
        //     The matrix.
        //
        //   provider:
        //     The Accord.Math.IMatrixFormatProvider to be used when creating the resulting
        //     string. Default is to use Accord.Math.DefaultMatrixFormatProvider.CurrentCulture.
        //
        // Returns:
        //     A System.String that represents this instance.
        public static string ToString<T>(this T[][] matrix, IMatrixFormatProvider provider);
        //
        // Summary:
        //     Returns a System.String that represents an array.
        //
        // Parameters:
        //   array:
        //     The array.
        //
        //   provider:
        //     The Accord.Math.IMatrixFormatProvider to be used when creating the resulting
        //     string. Default is to use Accord.Math.DefaultMatrixFormatProvider.CurrentCulture.
        //
        // Returns:
        //     A System.String that represents this instance.
        public static string ToString<T>(this T[] array, IMatrixFormatProvider provider);
        //
        // Summary:
        //     Returns a System.String that represents a matrix.
        //
        // Parameters:
        //   matrix:
        //     The matrix.
        //
        //   format:
        //     The format to use when creating the resulting string.
        //
        // Returns:
        //     A System.String that represents this instance.
        public static string ToString<T>(this T[][] matrix, string format);
        //
        // Summary:
        //     Returns a System.String that represents a matrix.
        //
        // Parameters:
        //   matrix:
        //     The matrix.
        //
        //   format:
        //     The format to use when creating the resulting string.
        //
        // Returns:
        //     A System.String that represents this instance.
        public static string ToString<T>(this T[,] matrix, string format);
        //
        // Summary:
        //     Returns a System.String that represents a matrix.
        //
        // Parameters:
        //   matrix:
        //     The matrix.
        //
        //   provider:
        //     The Accord.Math.IMatrixFormatProvider to be used when creating the resulting
        //     string. Default is to use Accord.Math.DefaultMatrixFormatProvider.CurrentCulture.
        //
        // Returns:
        //     A System.String that represents this instance.
        public static string ToString<T>(this T[,] matrix, IMatrixFormatProvider provider);
        //
        // Summary:
        //     Returns a System.String that represents a matrix.
        //
        // Parameters:
        //   matrix:
        //     The matrix.
        //
        //   format:
        //     The format to use when creating the resulting string.
        //
        //   provider:
        //     The Accord.Math.IMatrixFormatProvider to be used when creating the resulting
        //     string. Default is to use Accord.Math.DefaultMatrixFormatProvider.CurrentCulture.
        //
        // Returns:
        //     A System.String that represents this instance.
        public static string ToString<T>(this T[][] matrix, string format, IMatrixFormatProvider provider);
        //
        // Summary:
        //     Returns a System.String that represents an array.
        //
        // Parameters:
        //   matrix:
        //     The matrix.
        //
        //   format:
        //     The format to use when creating the resulting string.
        //
        //   provider:
        //     The Accord.Math.IMatrixFormatProvider to be used when creating the resulting
        //     string. Default is to use Accord.Math.DefaultMatrixFormatProvider.CurrentCulture.
        //
        // Returns:
        //     A System.String that represents this instance.
        public static string ToString<T>(this T[] matrix, string format, IMatrixFormatProvider provider);
        //
        // Summary:
        //     Returns a System.String that represents a matrix.
        //
        // Parameters:
        //   matrix:
        //     The matrix.
        //
        //   format:
        //     The format to use when creating the resulting string.
        //
        //   provider:
        //     The Accord.Math.IMatrixFormatProvider to be used when creating the resulting
        //     string. Default is to use Accord.Math.DefaultMatrixFormatProvider.CurrentCulture.
        //
        // Returns:
        //     A System.String that represents this instance.
        public static string ToString<T>(this T[,] matrix, string format, IMatrixFormatProvider provider);
        //
        // Summary:
        //     Returns a System.String that represents a matrix.
        //
        // Parameters:
        //   matrix:
        //     The matrix.
        //
        //   multiline:
        //     If set to true, the matrix will be written using multiple lines. If set to false,
        //     the matrix will be written in a single line.
        //
        //   provider:
        //     The Accord.Math.IMatrixFormatProvider to be used when creating the resulting
        //     string. Default is to use Accord.Math.DefaultMatrixFormatProvider.CurrentCulture.
        //
        // Returns:
        //     A System.String that represents this instance.
        public static string ToString<T>(this T[,] matrix, bool multiline, IMatrixFormatProvider provider);
        //
        // Summary:
        //     Converts a DataTable to a double[,] array.
        public static DataTable ToTable(this double[][] matrix);
        //
        // Summary:
        //     Converts an array of values into a System.Data.DataTable, attempting to guess
        //     column types by inspecting the data.
        //
        // Parameters:
        //   values:
        //     The values to be converted.
        //
        // Returns:
        //     A System.Data.DataTable containing the given values.
        public static DataTable ToTable(this object[,] values);
        //
        // Summary:
        //     Converts a DataTable to a double[,] array.
        public static DataTable ToTable(this double[,] matrix);
        //
        // Summary:
        //     Converts a DataTable to a double[,] array.
        public static DataTable ToTable(this double[][] matrix, params string[] columnNames);
        //
        // Summary:
        //     Converts a DataTable to a double[,] array.
        public static DataTable ToTable(this double[,] matrix, params string[] columnNames);
        //
        // Summary:
        //     Gets the trace of a matrix.
        //
        // Remarks:
        //     The trace of an n-by-n square matrix A is defined to be the sum of the elements
        //     on the main diagonal (the diagonal from the upper left to the lower right) of
        //     A.
        public static int Trace(this int[,] matrix);
        //
        // Summary:
        //     Gets the trace of a matrix.
        //
        // Remarks:
        //     The trace of an n-by-n square matrix A is defined to be the sum of the elements
        //     on the main diagonal (the diagonal from the upper left to the lower right) of
        //     A.
        public static float Trace(this float[,] matrix);
        //
        // Summary:
        //     Gets the trace of a matrix.
        //
        // Remarks:
        //     The trace of an n-by-n square matrix A is defined to be the sum of the elements
        //     on the main diagonal (the diagonal from the upper left to the lower right) of
        //     A.
        public static float Trace(this float[][] matrix);
        //
        // Summary:
        //     Gets the trace of a matrix.
        //
        // Remarks:
        //     The trace of an n-by-n square matrix A is defined to be the sum of the elements
        //     on the main diagonal (the diagonal from the upper left to the lower right) of
        //     A.
        public static double Trace(this double[,] matrix);
        //
        // Summary:
        //     Gets the trace of a matrix product.
        public static double Trace(double[,] matrixA, double[,] matrixB);
        //
        // Summary:
        //     Gets the generalized transpose of a tensor.
        //
        // Parameters:
        //   array:
        //     A tensor.
        //
        //   order:
        //     The new order for the tensor's dimensions.
        //
        // Returns:
        //     The transpose of the given tensor.
        public static Array Transpose(this Array array, int[] order);
        //
        // Summary:
        //     Gets the transpose of a row vector.
        //
        // Parameters:
        //   rowVector:
        //     A row vector.
        //
        // Returns:
        //     The transpose of the given vector.
        public static T[,] Transpose<T>(this T[] rowVector);
        //
        // Summary:
        //     Gets the transpose of a matrix.
        //
        // Parameters:
        //   matrix:
        //     A matrix.
        //
        // Returns:
        //     The transpose of the given matrix.
        public static T[][] Transpose<T>(this T[][] matrix);
        //
        // Summary:
        //     Gets the transpose of a matrix.
        //
        // Parameters:
        //   matrix:
        //     A matrix.
        //
        // Returns:
        //     The transpose of the given matrix.
        public static T[,] Transpose<T>(this T[,] matrix);
        //
        // Summary:
        //     Gets the transpose of a matrix.
        //
        // Parameters:
        //   matrix:
        //     A matrix.
        //
        //   inPlace:
        //     True to store the transpose over the same input matrix, false otherwise. Default
        //     is false.
        //
        // Returns:
        //     The transpose of the given matrix.
        public static T[][] Transpose<T>(this T[][] matrix, bool inPlace);
        //
        // Summary:
        //     Gets the generalized transpose of a tensor.
        //
        // Parameters:
        //   array:
        //     A tensor.
        //
        //   order:
        //     The new order for the tensor's dimensions.
        //
        // Returns:
        //     The transpose of the given tensor.
        public static T Transpose<T>(this T array, int[] order) where T : class, ICloneable, IList;
        //
        // Summary:
        //     Gets the transpose of a matrix.
        //
        // Parameters:
        //   matrix:
        //     A matrix.
        //
        //   inPlace:
        //     True to store the transpose over the same input matrix, false otherwise. Default
        //     is false.
        //
        // Returns:
        //     The transpose of the given matrix.
        public static T[,] Transpose<T>(this T[,] matrix, bool inPlace);
        //
        // Summary:
        //     Computes the product A'*B of matrix A transposed and matrix B.
        //
        // Parameters:
        //   a:
        //     The transposed left matrix A.
        //
        //   b:
        //     The right matrix B.
        //
        // Returns:
        //     The product A'*B of the given matrices A and B.
        public static double[][] TransposeAndMultiply(this double[][] a, double[][] b);
        //
        // Summary:
        //     Computes the product A'*B of matrix A transposed and vector b.
        //
        // Parameters:
        //   a:
        //     The transposed left matrix A.
        //
        //   b:
        //     The right column vector b.
        //
        // Returns:
        //     The product A'*b of the given matrices A and vector b.
        public static double[] TransposeAndMultiply(this double[,] a, double[] b);
        //
        // Summary:
        //     Computes the product A'*B of matrix A transposed and matrix B.
        //
        // Parameters:
        //   a:
        //     The transposed left matrix A.
        //
        //   b:
        //     The right matrix B.
        //
        // Returns:
        //     The product A'*B of the given matrices A and B.
        public static double[,] TransposeAndMultiply(this double[,] a, double[,] b);
        //
        // Summary:
        //     Computes the product A'*B of matrix A transposed and matrix B.
        //
        // Parameters:
        //   a:
        //     The transposed left matrix A.
        //
        //   b:
        //     The right matrix B.
        //
        //   result:
        //     The matrix R to store the product R = A'*B of the given matrices A and B.
        public static void TransposeAndMultiply(this double[][] a, double[][] b, double[][] result);
        //
        // Summary:
        //     Computes the product A'*b of matrix A transposed and column vector b.
        //
        // Parameters:
        //   a:
        //     The transposed left matrix A.
        //
        //   b:
        //     The right column vector b.
        //
        //   result:
        //     The vector r to store the product r = A'*b of the given matrix A and vector b.
        public static void TransposeAndMultiply(this double[,] a, double[] b, double[] result);
        //
        // Summary:
        //     Computes the product A'*B of matrix A transposed and matrix B.
        //
        // Parameters:
        //   a:
        //     The transposed left matrix A.
        //
        //   b:
        //     The right matrix B.
        //
        //   result:
        //     The matrix R to store the product R = A'*B of the given matrices A and B.
        public static void TransposeAndMultiply(this double[,] a, double[,] b, double[,] result);
        //
        // Summary:
        //     Computes the product A'*B of matrix A and diagonal matrix B.
        //
        // Parameters:
        //   a:
        //     The left matrix A.
        //
        //   b:
        //     The diagonal vector of right matrix B.
        //
        // Returns:
        //     The product A*B of the given matrices A and B.
        public static double[,] TransposeAndMultiplyByDiagonal(this double[,] a, double[] b);
        //
        // Summary:
        //     Computes the product A'*B of matrix A and diagonal matrix B.
        //
        // Parameters:
        //   a:
        //     The left matrix A.
        //
        //   b:
        //     The diagonal vector of right matrix B.
        //
        //   result:
        //     The matrix R to store the product R = A*B of the given matrices A and B.
        public static void TransposeAndMultiplyByDiagonal(this double[,] a, double[] b, double[,] result);
        //
        // Summary:
        //     Converts the string representation of a matrix to its double-precision floating-point
        //     number matrix equivalent. A return value indicates whether the conversion succeeded
        //     or failed.
        //
        // Parameters:
        //   s:
        //     The string representation of the matrix.
        //
        //   provider:
        //     The format provider to use in the conversion. Default is to use Accord.Math.DefaultMatrixFormatProvider.CurrentCulture.
        //
        //   matrix:
        //     A double-precision floating-point number matrix parsed from the given string
        //     using the given format provider.
        public static bool TryParse(string s, IMatrixFormatProvider provider, out double[][] matrix);
        //
        // Summary:
        //     Converts the string representation of a matrix to its double-precision floating-point
        //     number matrix equivalent. A return value indicates whether the conversion succeeded
        //     or failed.
        //
        // Parameters:
        //   s:
        //     The string representation of the matrix.
        //
        //   provider:
        //     The format provider to use in the conversion. Default is to use Accord.Math.DefaultMatrixFormatProvider.CurrentCulture.
        //
        //   matrix:
        //     A double-precision floating-point number matrix parsed from the given string
        //     using the given format provider.
        public static bool TryParse(string s, IMatrixFormatProvider provider, out double[,] matrix);
        //
        // Summary:
        //     Creates a vector with the given dimension and starting values.
        public static double[] Vector(double a, double b, int points);
        //
        // Summary:
        //     Creates a vector with the given dimension and starting values.
        public static int[] Vector(int a, int b, int increment = 1);
        //
        // Summary:
        //     Creates a vector with the given dimension and starting values.
        public static double[] Vector(double a, double b, double increment = 1);
        //
        // Summary:
        //     Creates a vector with the given dimension and starting values.
        public static T[] Vector<T>(int n, T value);
        //
        // Summary:
        //     Creates a vector with the given dimension and starting values.
        public static T[] Vector<T>(int n, T[] values);
        //
        // Summary:
        //     Vector product.
        public static float[] VectorProduct(float[] a, float[] b);
        //
        // Summary:
        //     Vector product.
        //
        // Remarks:
        //     The cross product, vector product or Gibbs vector product is a binary operation
        //     on two vectors in three-dimensional space. It has a vector result, a vector which
        //     is always perpendicular to both of the vectors being multiplied and the plane
        //     containing them. It has many applications in mathematics, engineering and physics.
        public static double[] VectorProduct(double[] a, double[] b);
    }
}