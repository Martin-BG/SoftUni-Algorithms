using System.Collections.Generic;

public class StronglyConnectedComponents
{
    private static int _size;
    private static bool[] _visited;
    private static List<int>[] _graph;
    private static List<int>[] _reverseGraph;
    private static Stack<int> _dfsNodesStack;
    private static List<List<int>> _stronglyConnectedComponents;

    public static List<List<int>> FindStronglyConnectedComponents(List<int>[] targetGraph)
    {
        _stronglyConnectedComponents = new List<List<int>>();
        _graph = targetGraph;
        _size = _graph.Length;
        _visited = new bool[_size];
        _dfsNodesStack = new Stack<int>();

        BuildReverseGraph();

        for (var i = 0; i < _size; i++)
        {
            Dfs(i);
        }

        for (var i = 0; i < _size; i++)
        {
            _visited[i] = false;
        }

        while (_dfsNodesStack.Count > 0)
        {
            var node = _dfsNodesStack.Pop();

            if (_visited[node])
            {
                continue;
            }

            _stronglyConnectedComponents.Add(new List<int>());
            ReverseDfs(node);
        }

        return _stronglyConnectedComponents;
    }

    private static void ReverseDfs(int node)
    {
        if (_visited[node])
        {
            return;
        }

        _visited[node] = true;

        _stronglyConnectedComponents[_stronglyConnectedComponents.Count - 1].Add(node);

        foreach (var childNode in _reverseGraph[node])
        {
            ReverseDfs(childNode);
        }
    }

    private static void BuildReverseGraph()
    {
        _reverseGraph = new List<int>[_size];

        for (var node = 0; node < _size; node++)
        {
            _reverseGraph[node] = new List<int>();
        }

        for (var node = 0; node < _size; node++)
        {
            foreach (var childNode in _graph[node])
            {
                _reverseGraph[childNode].Add(node);
            }
        }
    }

    private static void Dfs(int node)
    {
        if (_visited[node])
        {
            return;
        }

        _visited[node] = true;

        foreach (var childNode in _graph[node])
        {
            Dfs(childNode);
        }

        _dfsNodesStack.Push(node);
    }
}
