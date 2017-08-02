using System;
using System.Collections.Generic;

public class ArticulationPoints
{
    private static List<int>[] _graph;
    private static bool[] _visited;
    private static int?[] _parent;
    private static int[] _depths;
    private static int[] _lowpoint;
    private static List<int> _articulationPoints;

    public static List<int> FindArticulationPoints(List<int>[] targetGraph)
    {
        _graph = targetGraph;
        _visited = new bool[_graph.Length];
        _parent = new int?[_graph.Length];
        _depths = new int[_graph.Length];
        _lowpoint = new int[_graph.Length];
        _articulationPoints = new List<int>();

        FindArticulationPoints(0, 0);

        return _articulationPoints;
    }

    private static void FindArticulationPoints(int node, int depth)
    {
        _visited[node] = true;
        _depths[node] = depth;
        _lowpoint[node] = depth;

        var childCount = 0;
        var isArticulation = false;

        foreach (var childNode in _graph[node])
        {
            if (!_visited[childNode])
            {
                _parent[childNode] = node;

                FindArticulationPoints(childNode, depth + 1);

                childCount++;

                if (_lowpoint[childNode] >= _depths[node])
                {
                    isArticulation = true;
                }

                _lowpoint[node] = Math.Min(_lowpoint[node], _lowpoint[childNode]);
            }
            else if (childNode != _parent[node])
            {
                _lowpoint[node] = Math.Min(_lowpoint[node], _depths[childNode]);
            }
        }

        if ((_parent[node] != null && isArticulation) ||
            (_parent[node] == null && childCount > 1))
        {
            _articulationPoints.Add(node);
        }
    }
}
