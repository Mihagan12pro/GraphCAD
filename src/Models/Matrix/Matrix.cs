using System.Data.Common;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Models.Matrix
{
    public class Matrix<T>
    {
        public readonly int RowsCount;
        public readonly int ColumnsCount;

        private readonly T[,] _matrix;

        public IEnumerable<T> GetRow(int number)
        {
            if (number > RowsCount || number < 0)
                throw new ArgumentOutOfRangeException(nameof(number));
            
            int i = number;

            for (int j = 0; j < ColumnsCount; j++)
            {
                yield return _matrix[i, j];
            }
        }

        public IEnumerable<T> GetColumn(int number)
        {
            if (number > ColumnsCount || number < 0)
                throw new ArgumentOutOfRangeException(nameof(number));

            int j = number;

            for(int i = 0; i < ColumnsCount; i++)
            {
                yield return _matrix[i, j];
            }
        }

        public T GetItem(int row, int column)
        {
            return _matrix[row, column];
        }

        public void Add(int row, int column, T item)
        {
            if (row > RowsCount || row < 0)
                throw new ArgumentOutOfRangeException(nameof(row));

            if (column > ColumnsCount || column < 0)
                throw new ArgumentOutOfRangeException(nameof(column));

            _matrix[row, column] = item; 
        }

        public IEnumerable<T> MainDiagonal
        {
            get
            {
                for (int number = 0; number < ColumnsCount; number++)
                {
                    yield return _matrix[number, number];
                }
            }
        }

        public IEnumerable<T> AntiDiagonal
        {
            get
            {
                for (int number = ColumnsCount; number > 0; number--)
                {
                    yield return _matrix[number, number];
                }
            }
        }

        public Matrix(int rowsCount, int columnsCount)
        {
            if (rowsCount <= 0 || columnsCount <= 0)
                throw new ArgumentOutOfRangeException();

            RowsCount = rowsCount;
            ColumnsCount = columnsCount;

            _matrix = new T[RowsCount, ColumnsCount];
        }
    }
}
