using GenericCollectionsExtension.Graph;

namespace GenericCollectionsExtension.Tests.Graph;

public class GraphTests
{
    [Fact]
    public void AddVertex()
    {
        var graph = new Graph<string, int>
        {
            new Vertex<string, int>("A"),
            new Vertex<string, int>("B"),
            new Vertex<string, int>("C"),
        };

        Assert.Equal(3, graph.Count);
        Assert.True(graph.HasVertex("A"));
        Assert.True(graph.HasVertex("B"));
        Assert.True(graph.HasVertex("C"));
    }

    [Theory]
    [InlineData("A", "B", 10)]
    [InlineData("C", "D", 3.3)]
    [InlineData(2, 5, 5d)]
    public void AddEdge(object vertex1, object vertex2, decimal cost)
    {
        var graph = new Graph<object, decimal>
        {
            new Vertex<object, decimal>(vertex1),
            new Vertex<object, decimal>(vertex2),
        };

        graph.AddEdge(vertex1, vertex2, cost);
        Assert.Equal(2, graph.Count);
        Assert.Equal(cost, graph.HasEdge(vertex1, vertex2, out _).Cost);
        Assert.True(graph.HasEdge(vertex1, vertex2));
    }

    [Theory]
    [InlineData("A")]
    [InlineData('B')]
    [InlineData(4)]
    [InlineData(5.4f)]
    public void ExistsVertex(object vertex)
    {
        var graph = new Graph<object, int>()
        {
            new Vertex<object, int>(vertex)
        };

        Assert.Single(graph);
        Assert.True(graph.HasVertex(vertex));
    }

    [Theory]
    [InlineData("Hello", "Nil", 20)]
    [InlineData('A', 'B', 0)]
    [InlineData(5, 10, 200.504d)]
    public void ExistsEdge(object vertex, object vertex2, decimal cost)
    {
        var graph = new Graph<object, decimal>()
        {
            new Vertex<object, decimal>(vertex),
            new Vertex<object, decimal>(vertex2)
        };

        graph.AddEdge(vertex, vertex2, cost);

        Assert.Equal(cost, graph.HasEdge(vertex, vertex2, out _).Cost);
        Assert.True(graph.HasEdge(vertex, vertex2));
    }

    [Fact]
    public void GetSuccessors()
    {
        var graph = new Graph<string, int>()
        {
            new Vertex<string, int>("A"),
            new Vertex<string, int>("B"),
            new Vertex<string, int>("C"),
            new Vertex<string, int>("D")
        };

        graph.AddEdge("A", "B", 5);
        graph.AddEdge("A", "C", 2);
        graph.AddEdge("A", "D", 10);

        Assert.Equal(new List<string> { "B", "C", "D" }, graph.Successors("A").Select(x => x.VertexName));
    }

    [Fact]
    public void GetPredecessors()
    {
        var graph = new Graph<string, int>()
        {
            new Vertex<string, int>("A"),
            new Vertex<string, int>("B"),
            new Vertex<string, int>("C"),
            new Vertex<string, int>("D")
        };

        graph.AddEdge("A", "B", 5);
        graph.AddEdge("C", "B", 2);
        graph.AddEdge("D", "B", 10);

        Assert.Equal(new List<string> { "A", "C", "D" }, graph.Predecessors("B").Select(x => x.VertexName));
    }

    [Fact]
    public void RemoveVertex()
    {
        var graph = new Graph<string, int>()
        {
            new Vertex<string, int>("A"),
            new Vertex<string, int>("B"),
            new Vertex<string, int>("C"),
            new Vertex<string, int>("D")
        };
        
        graph.RemoveVertex("A");
        Assert.Equal(3, graph.Count);
        Assert.Equal(new List<string> { "B", "C", "D" }, graph.Select(x => x.VertexName));
    }

    [Fact]
    public void RemoveEdge()
    {
        var graph = new Graph<string, int>()
        {
            new Vertex<string, int>("A"),
            new Vertex<string, int>("B")
        };

        graph.AddEdge("A", "B", 20);
        graph.RemoveEdge("A", "B");
        Assert.Empty(graph.Vertexs[0].Edges);
        Assert.Empty(graph.Vertexs[1].Edges);
    }

    [Fact]
    public void RemoveEdges()
    {
        var graph = new Graph<string, int>()
        {
            new Vertex<string, int>("A"),
            new Vertex<string, int>("B"),
            new Vertex<string, int>("C")
        };

        graph.AddEdge("A", "B", 20);
        graph.AddEdge("B", "C", 0);
        graph.AddEdge("A", "C", 10);

        graph.RemoveEdge("A", "B");
        graph.RemoveEdge("A", "C");

        Assert.Empty(graph.Vertexs[0].Edges);
        Assert.Single(graph.Vertexs[2].Edges);
    }
}
