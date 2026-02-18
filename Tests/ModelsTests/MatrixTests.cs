using Models.Matrix;
using System.Diagnostics;

namespace ModelsTests
{
    public class MatrixTests
    {
        [Fact]
        public void Test1()
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

            int it = matrix.GetItem(0, 0);
        }
    }
}