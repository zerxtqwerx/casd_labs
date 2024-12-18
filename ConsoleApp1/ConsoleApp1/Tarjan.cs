using System;
using System.Collections.Generic;

public class Tarjan
{
    private int index; // Индекс для отслеживания порядка обхода
    private int[] indexes, lowlinks; // Массивы индексов и низких связей
    private Stack<int> stack; // Стек для хранения узлов
    private HashSet<int> onStack; // Множество для проверки, находится ли узел в стеке
    private List<List<int>> strongComponents; // Список для компонентов

    public Tarjan(int verticesCount)
    {
        indexes = new int[verticesCount];
        lowlinks = new int[verticesCount];
        onStack = new HashSet<int>();
        stack = new Stack<int>();
        strongComponents = new List<List<int>>();
        index = 0;

        for (int i = 0; i < verticesCount; i++)
        {
            indexes[i] = -1; // Инициализация индексов
        }
    }

    public List<List<int>> FindStronglyConnectedComponents(List<List<int>> graph)
    {
        for (int v = 0; v < graph.Count; v++)
        {
            if (indexes[v] == -1)
            {
                StrongConnect(v, graph);
            }
        }
        return strongComponents;
    }

    private void StrongConnect(int v, List<List<int>> graph)
    {
        indexes[v] = lowlinks[v] = index++;
        stack.Push(v);
        onStack.Add(v);

        foreach (var w in graph[v])
        {
            if (indexes[w] == -1) // Если узел w не был посещен
            {
                StrongConnect(w, graph);
                lowlinks[v] = Math.Min(lowlinks[v], lowlinks[w]); // Обновление lowlink
            }
            else if (onStack.Contains(w)) // Если узел w находится в стеке (сильная компонента)
            {
                lowlinks[v] = Math.Min(lowlinks[v], indexes[w]);
            }
        }

        // Если узел v - корень сильной компоненты
        if (lowlinks[v] == indexes[v])
        {
            var component = new List<int>();

            int w;
            do
            {
                w = stack.Pop();
                onStack.Remove(w);
                component.Add(w);
            } while (w != v);

            strongComponents.Add(component);
        }
    }
}
