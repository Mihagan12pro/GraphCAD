namespace Models.Graph.Elements
{
    public record Edge<T>(
        Vertex<T> VertexFirst,
        Vertex<T> VertexSecond,
        double Length);
}
