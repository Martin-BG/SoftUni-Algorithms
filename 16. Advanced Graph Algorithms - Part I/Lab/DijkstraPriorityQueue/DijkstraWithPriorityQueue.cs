using System.Collections.Generic;

public static class DijkstraWithPriorityQueue
{
    public static List<int> DijkstraAlgorithm(
        Dictionary<Node, Dictionary<Node, int>> graph,
        Node sourceNode, 
        Node destinationNode)
    {
        var previous = new int[graph.Count];
        var visited = new bool[graph.Count];
        var priorityQueue = new PriorityQueue<Node>();

        for (var i = 0; i < previous.Length; i++)
        {
            previous[i] = -1;
        }

        sourceNode.DistanceFromStart = 0;
        priorityQueue.Enqueue(sourceNode);

        while (priorityQueue.Count > 0)
        {
            var currentNode = priorityQueue.ExtractMin();

            if (currentNode.Id == destinationNode.Id)
            {
                break;
            }

            foreach (var edge in graph[currentNode])
            {
                if (!visited[edge.Key.Id])
                {
                    priorityQueue.Enqueue(edge.Key);
                    visited[edge.Key.Id] = true;
                }

                var distance = currentNode.DistanceFromStart + edge.Value;

                if (!(distance < edge.Key.DistanceFromStart))
                {
                    continue;
                }

                edge.Key.DistanceFromStart = distance;
                previous[edge.Key.Id] = currentNode.Id;
                priorityQueue.DecreaseKey(edge.Key);
            }
        }

        if (previous[destinationNode.Id] == -1)
        {
            return null;
        }

        var path = new List<int>();
        var current = destinationNode.Id;

        while (current != -1)
        {
            path.Add(current);
            current = previous[current];
        }

        path.Reverse();

        return path;
    }
}
