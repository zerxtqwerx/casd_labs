using System;
using System.Collections.Generic;
using System.Linq;

class Graph1
{
    private int verticesCount;
    private List<int>[] adjacencyList;

    public Graph1(int verticesCount)
    {
        this.verticesCount = verticesCount;
        adjacencyList = new List<int>[verticesCount];
        for (int i = 0; i < verticesCount; i++)
        {
            adjacencyList[i] = new List<int>();
        }
    }

    public void AddEdge(int u, int v)
    {
        adjacencyList[u].Add(v);
        adjacencyList[v].Add(u);
    }

    public int VerticesCount => verticesCount;

    public List<int> GetAdjacents(int vertex)
    {
        return adjacencyList[vertex];
    }

    public List<int> GetDegrees()
    {
        return adjacencyList.Select(adj => adj.Count).ToList();
    }

    public bool IsIsomorphic(Graph1 other)
    {
        if (this.VerticesCount != other.VerticesCount)
            return false;

        // Теперь сравним степени вершин
        var degrees1 = this.GetDegrees();
        var degrees2 = other.GetDegrees();

        degrees1.Sort();
        degrees2.Sort();

        if (!degrees1.SequenceEqual(degrees2))
            return false;

        // Если степени совпадают, надо проверить структурно
        return AreGraphStructuresIsomorphic(this, other);
    }

    private bool AreGraphStructuresIsomorphic(Graph1 g1, Graph1 g2)
    {
        var visited1 = new bool[g1.VerticesCount];
        var visited2 = new bool[g2.VerticesCount];

        List<int> mapping = new List<int>(new int[g1.VerticesCount]);

        // Пробуем все возможные перестановки
        return CheckIsomorphism(g1, g2, 0, visited1, visited2, mapping);
    }

    private bool CheckIsomorphism(Graph1 g1, Graph1 g2, int vertex, bool[] visited1, bool[] visited2, List<int> mapping)
    {
        if (vertex == g1.VerticesCount)
        {
            return ValidateMapping(g1, g2, mapping);
        }

        for (int i = 0; i < g2.VerticesCount; i++)
        {
            if (!visited2[i]) // Если i-ая вершина g2 еще не была посещена
            {
                mapping[vertex] = i;
                visited2[i] = true;

                if (CheckIsomorphism(g1, g2, vertex + 1, visited1, visited2, mapping))
                {
                    return true;
                }

                visited2[i] = false; // Восстанавливаем состояние
            }
        }

        return false;
    }

    private bool ValidateMapping(Graph1 g1, Graph1 g2, List<int> mapping)
    {
        for (int i = 0; i < g1.VerticesCount; i++)
        {
            foreach (var j in g1.GetAdjacents(i))
            {
                if (!g2.GetAdjacents(mapping[i]).Contains(mapping[j]))
                {
                    return false;
                }
            }
        }
        return true;
    }
}