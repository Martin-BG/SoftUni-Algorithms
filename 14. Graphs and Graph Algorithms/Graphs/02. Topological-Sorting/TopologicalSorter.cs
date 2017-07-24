using System;
using System.Collections.Generic;
using System.Linq;

public class TopologicalSorter
{
    private readonly Dictionary<string, List<string>> _graph;
    private Dictionary<string, int> _predecessorCount;

    public TopologicalSorter(Dictionary<string, List<string>> graph)
    {
        _graph = graph;
        GetPredecessorCount();
    }

    private void GetPredecessorCount()
    {
        _predecessorCount = new Dictionary<string, int>();

        foreach (var node in _graph)
        {
            if (!_predecessorCount.ContainsKey(node.Key))
            {
                _predecessorCount[node.Key] = 0;
            }

            foreach (var child in node.Value)
            {
                if (!_predecessorCount.ContainsKey(child))
                {
                    _predecessorCount[child] = 0;
                }

                _predecessorCount[child]++;
            }
        }
    }

    public ICollection<string> TopSort()
    {
        var sorted = new List<string>();

        while (true)
        {
            var nodeToRemove = _predecessorCount.Keys
                .FirstOrDefault(x => _predecessorCount[x] <= 0);

            if (nodeToRemove == null)
            {
                break;
            }

            if (_graph.ContainsKey(nodeToRemove))
            {
                foreach (var child in _graph[nodeToRemove])
                {
                    if (_predecessorCount.ContainsKey(child))
                    {
                        _predecessorCount[child]--;
                    }
                }
            }

            _predecessorCount.Remove(nodeToRemove);
            _graph.Remove(nodeToRemove);
            sorted.Add(nodeToRemove);
        }

        if (_graph.Count > 0)
        {
            throw new InvalidOperationException();
        }

        return sorted;
    }
}
