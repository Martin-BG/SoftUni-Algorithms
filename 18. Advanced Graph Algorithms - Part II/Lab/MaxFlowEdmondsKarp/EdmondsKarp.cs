using System.Collections.Generic;

public class EdmondsKarp
{
    private static int[][] _graph;
    private static int[] _parents;

    public static int FindMaxFlow(int[][] targetGraph)
    {
        _graph = targetGraph;
        _parents = new int[_graph.Length];

        for (var i = 0; i < _graph.Length; i++)
        {
            _parents[i] = -1;
        }

        var maxFlow = 0;
        var start = 0;
        var end = _graph.Length - 1;

        while (BFS(start, end))
        {
            var pathFlow = int.MaxValue;
            var currentNode = end;

            while (currentNode != start)
            {
                var prevNode = _parents[currentNode];

                if (pathFlow > _graph[prevNode][currentNode])
                {
                    pathFlow = _graph[prevNode][currentNode];
                }

                currentNode = prevNode;
            }

            maxFlow += pathFlow;
            currentNode = end;

            while (currentNode != start)
            {
                var prevNode = _parents[currentNode];
                _graph[prevNode][currentNode] -= pathFlow;
                _graph[currentNode][prevNode] += pathFlow;
                currentNode = prevNode;
            }

        }

        return maxFlow;
    }

    static bool BFS(int src, int dest)
    {
        var visited = new bool[_graph.Length];
        var queue = new Queue<int>();
        queue.Enqueue(src);
        visited[src] = true;

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            for (var i = 0; i < _graph.Length; i++)
            {
                if (_graph[node][i] == 0 || visited[i])
                {
                    continue;
                }

                queue.Enqueue(i);
                _parents[i] = node;
                visited[i] = true;
            }
        }

        return visited[dest];
    }
}
