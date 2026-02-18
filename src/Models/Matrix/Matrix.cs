namespace Models.Matrix
{
    public struct Matrix<T>
    {
        public readonly int RowsCount;
        public readonly int ColumnsCount;

        private readonly T[][] _matrix;

        public Matrix(int rowsCount, int columnsCount)
        {
            RowsCount = rowsCount;
            ColumnsCount = columnsCount;
        }
    }
}
