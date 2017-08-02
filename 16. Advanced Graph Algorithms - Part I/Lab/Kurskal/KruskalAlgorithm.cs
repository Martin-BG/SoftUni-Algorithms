using System.Collections.Generic;

public class KruskalAlgorithm
{
    public static List<Edge> Kruskal(int numberOfVertices, List<Edge> edges)
    {
        edges.Sort();

        var parent = new int[numberOfVertices];
        for (var i = 0; i < numberOfVertices; i++)
        {
            parent[i] = i;
        }

        var spanningTree = new List<Edge>();

        foreach (var edge in edges)
        {
            var rootStartNode = FindRoot(edge.StartNode, parent);
            var rootEndNode = FindRoot(edge.EndNode, parent);

            if (rootStartNode == rootEndNode)
            {
                continue;
            }

            spanningTree.Add(edge);
            parent[rootEndNode] = rootStartNode;
        }

        return spanningTree;
    }

    public static int FindRoot(int node, int[] parent)
    {
        var root = node;

        while (parent[root] != root)
        {
            root = parent[root];
        }

        while (node != root)
        {
            var oldParent = parent[node];
            parent[node] = root;
            node = oldParent;
        }

        return root;
    }
}
