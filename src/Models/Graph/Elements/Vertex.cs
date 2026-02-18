namespace Models.Graph.Elements
{
    public record Vertex<T>(
        T Header, 
        int Color = 0);
}
