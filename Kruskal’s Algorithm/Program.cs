using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Edge : IComparable<Edge>
{
    public int Source, Destination, Weight;

    public int CompareTo(Edge compareEdge)
    {
        return this.Weight.CompareTo(compareEdge.Weight);
    }
}

class KruskalAlgorithm
{
    int vertices;
    List<Edge> edges = new List<Edge>();

    public KruskalAlgorithm(int vertices)
    {
        this.vertices = vertices;
    }

    public void AddEdge(int source, int destination, int weight)
    {
        edges.Add(new Edge() { Source = source, Destination = destination, Weight = weight });
    }

    public void FindMST()
    {
        edges.Sort();

        int[] parent = new int[vertices];
        for (int i = 0; i < vertices; i++)
            parent[i] = i;

        List<Edge> mst = new List<Edge>();

        foreach (Edge edge in edges)
        {
            int root1 = Find(parent, edge.Source);
            int root2 = Find(parent, edge.Destination);

            if (root1 != root2)
            {
                mst.Add(edge);
                Union(parent, root1, root2);
            }
        }

        Console.WriteLine("Edges in MST:");
        foreach (Edge edge in mst)
            Console.WriteLine($"{edge.Source} - {edge.Destination} : {edge.Weight}");
    }

    int Find(int[] parent, int vertex)
    {
        if (parent[vertex] != vertex)
            parent[vertex] = Find(parent, parent[vertex]);
        return parent[vertex];
    }

    void Union(int[] parent, int root1, int root2)
    {
        parent[root2] = root1;
    }
}

class Program
{
    static void Main(string[] args)
    {
        KruskalAlgorithm graph = new KruskalAlgorithm(4);
        graph.AddEdge(0, 1, 10);
        graph.AddEdge(0, 2, 6);
        graph.AddEdge(0, 3, 5);
        graph.AddEdge(1, 3, 15);
        graph.AddEdge(2, 3, 4);

        graph.FindMST();
        Console.ReadKey();
    }
}

