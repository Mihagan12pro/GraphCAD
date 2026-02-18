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

        public static Matrix<T> Transposed(Matrix<T> matrix)
        {
            int row = matrix.ColumnsCount;
            int column = matrix.RowsCount;

            Matrix<T> transposed = new Matrix<T>(row, column);

            for(int i = 0; i < matrix.RowsCount; i++)
            {
                for(int j = 0; j < matrix.ColumnsCount; j++)
                {
                    T item = matrix.GetItem(i, j);

                    transposed.Add(j, i, item);
                }
            }

            return transposed;
        }

        public static Matrix<T> Copy(Matrix<T> source)
        {
            int rows = source.RowsCount;
            int columns = source.ColumnsCount;

            Matrix<T> target = new Matrix<T>(rows, columns);

            for(int i = 0; i < target.RowsCount; i++)
            {
                for(int j = 0; j < target.ColumnsCount; j++)
                {
                    target.Add(i, j, source.GetItem(i, j));
                }
            }

            return target;
        }

        /// <summary>
        /// Compares 2 matrices. 
        /// Works only for matrices that contain structs or immutable types
        /// </summary>
        /// <param name="matrixFirst"></param>
        /// <param name="matrixSecond"></param>
        /// <returns></returns>
        public static bool CheckEquality(Matrix<T> matrixFirst, Matrix<T> matrixSecond)
        {
            if (matrixFirst.ColumnsCount != matrixSecond.ColumnsCount
                || matrixFirst.RowsCount != matrixSecond.RowsCount)
                return false;

            for(int i = 0; i < matrixFirst.RowsCount; i++)
            {
                for(int j = 0; j < matrixFirst.ColumnsCount; j++)
                {
                    var firstItem = matrixFirst.GetItem(i, j);
                    var secondItem = matrixSecond.GetItem(i, j);

                    if (!firstItem.Equals(secondItem))
                        return false;
                }
            }


            return true;
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
