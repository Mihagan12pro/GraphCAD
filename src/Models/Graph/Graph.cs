using Models.Matrix;

namespace Models.Graph
{
    public class Graph<T>
    {
        public readonly Matrix<T> Matrix;

        public Graph(Matrix<T> matrix)
        {
            Matrix = matrix;
        }
    }
}
