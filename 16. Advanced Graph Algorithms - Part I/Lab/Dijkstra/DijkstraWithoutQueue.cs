using System;
using System.Collections.Generic;

public static class DijkstraWithoutQueue
{
    public static List<int> DijkstraAlgorithm(
        int[,] graph, int sourceNode, int destinationNode)
    {
        var n = graph.GetLength(0);

        var distance = new int[n];
        var used = new bool[n];
        var previous = new int?[n];

        for (var i = 0; i < n; i++)
        {
            distance[i] = int.MaxValue;
        }

        distance[sourceNode] = 0;
        previous[sourceNode] = null;

        while (true)
        {
            var minDistance = int.MaxValue;
            var minNode = 0;

            for (var node = 0; node < n; node++)
            {
                if (used[node] || distance[node] >= minDistance)
                {
                    continue;
                }

                minDistance = distance[node];
                minNode = node;
            }

            if (minDistance == int.MaxValue)
            {
                break;
            }

            used[minNode] = true;

            for (var i = 0; i < n; i++)
            {
                if (graph[minNode, i] <= 0)
                {
                    continue;
                }

                var newDist = distance[minNode] + graph[minNode, i];

                if (newDist >= distance[i])
                {
                    continue;
                }

                distance[i] = newDist;
                previous[i] = minNode;
            }
        }
        Console.WriteLine();
        if (distance[destinationNode] == int.MaxValue)
        {
            return null;
        }

        var path = new List<int>();
        int? currentNode = destinationNode;

        while (currentNode != null)
        {
            path.Insert(0, currentNode.Value);
            currentNode = previous[currentNode.Value];
        }

        return path;
    }
}

