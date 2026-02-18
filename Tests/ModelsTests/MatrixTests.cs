using Models.Matrix;
using System.Diagnostics;

namespace ModelsTests
{
    public class MatrixTests
    {
        [Fact]
        public void TestBasicFuncionality()
        {
            Matrix<int> matrix = new Matrix<int>(2, 3);

            Debug.WriteLine("Матрица: ");

            for (int i = 0; i < matrix.RowsCount; i++)
            {
                for (int j = 0; j < matrix.ColumnsCount; j++)
                {
                    int item = new Random().Next(0, 10); 
                    
                    matrix.Add(i, j, item);

                    Debug.Write($"{item} ");
                }

                Debug.WriteLine("");
            }

            Matrix<int> booleanMatrix = new Matrix<int>(2, 3);

            Debug.WriteLine($"{booleanMatrix.GetType() == matrix.GetType()}");
            Debug.WriteLine($"{matrix.GetType()}");
        }

        [Fact]
        public void TestTransposed()
        {
            Matrix<int> matrix = new Matrix<int>(2, 3);

            Debug.WriteLine("Матрица: ");

            for (int i = 0; i < matrix.RowsCount; i++)
            {
                for (int j = 0; j < matrix.ColumnsCount; j++)
                {
                    int item = new Random().Next(0, 10);

                    matrix.Add(i, j, item);

                    Debug.Write($"{item} ");
                }

                Debug.WriteLine("");
            }

            Matrix<int> transposed = Matrix<int>.Transposed(matrix);

            Debug.WriteLine("Транспонированная матрица: ");

            for (int i = 0; i < transposed.RowsCount; i++)
            {
                for (int j = 0; j < transposed.ColumnsCount; j++)
                {
                    Debug.Write($"{transposed.GetItem(i, j)} ");
                }

                Debug.WriteLine("");
            }
        }

        [Fact]
        public void TestCopy()
        {
            Matrix<int> matrix = new Matrix<int>(2, 2);

            Debug.WriteLine("Матрица: ");

            for (int i = 0; i < matrix.RowsCount; i++)
            {
                for (int j = 0; j < matrix.ColumnsCount; j++)
                {
                    int item = new Random().Next(0, 10);

                    matrix.Add(i, j, item);

                    Debug.Write($"{item} ");
                }

                Debug.WriteLine("");
            }


            Matrix<int> copy = Matrix<int>.Copy(matrix);

        }

        [Fact]
        public void CheckEqualityTest()
        {
            Matrix<int> matrix = new Matrix<int>(2, 2);

            Debug.WriteLine("Матрица: ");

            for (int i = 0; i < matrix.RowsCount; i++)
            {
                for (int j = 0; j < matrix.ColumnsCount; j++)
                {
                    int item = new Random().Next(0, 10);

                    matrix.Add(i, j, item);

                    Debug.Write($"{item} ");
                }

                Debug.WriteLine("");
            }


            Matrix<int> copy = Matrix<int>.Copy(matrix);

            Debug.WriteLine($"{Matrix<int>.CheckEquality(matrix, copy)}");

            for (int i = 0; i < matrix.RowsCount; i++)
            {
                for (int j = 0; j < matrix.ColumnsCount; j++)
                {
                    int item = new Random().Next(0, 10);

                    matrix.Add(i, j, item);

                    Debug.Write($"{item} ");
                }

                Debug.WriteLine("");
            }

            Debug.WriteLine($"{Matrix<int>.CheckEquality(matrix, copy)}");
        }
    }
}