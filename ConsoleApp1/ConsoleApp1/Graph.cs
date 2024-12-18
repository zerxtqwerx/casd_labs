using System;
using System.Collections.Generic;

class Graph
{
    private int verticesCount; // Количество вершин
    private int[,] capacity; // Матрица пропускной способности
    private List<int>[] adj; // Список смежности
    private int[] height; // Высота вершин
    private int[] excess; // Избыточный поток

    public Graph(int verticesCount)
    {
        this.verticesCount = verticesCount;
        capacity = new int[verticesCount, verticesCount];
        adj = new List<int>[verticesCount];
        height = new int[verticesCount];
        excess = new int[verticesCount];

        for (int i = 0; i < verticesCount; i++)
            adj[i] = new List<int>();
    }

    // Добавляем ребро в граф
    public void AddEdge(int u, int v, int c)
    {
        capacity[u, v] = c; // Установка пропускной способности
        adj[u].Add(v);
        adj[v].Add(u); // Добавляем обратное ребро
    }

    // Основная функция для расчета максимального потока
    public int PushRelabel(int source, int sink)
    {
        InitializePreflow(source);
        // Используем очередь для обработки вершин.
        Queue<int> queue = new Queue<int>();

        for (int i = 0; i < verticesCount; i++)
        {
            if (i != source && i != sink)
                queue.Enqueue(i);
        }

        while (queue.Count > 0)
        {
            int u = queue.Dequeue();
            Relabel(u);
            Push(u);
            // Обновляем очередь с учетом новых избыточных потоков
            if (excess[u] > 0 && u != source && u != sink)
                queue.Enqueue(u);
        }

        return excess[sink]; // Максимальный поток
    }

    // Инициализация предварительного потока
    private void InitializePreflow(int source)
    {
        height[source] = verticesCount; // Высота истока
        for (int v = 0; v < verticesCount; v++)
        {
            if (capacity[source, v] > 0)
            {
                excess[v] = capacity[source, v]; // Передаем поток из истока
                capacity[source, v] = 0; // Уменьшаем пропускную способность
            }
        }
    }

    // Увеличение высоты вершины
    private void Relabel(int u)
    {
        int minHeight = int.MaxValue;
        foreach (var v in adj[u])
        {
            if (capacity[u, v] > 0) // Если есть доступное ребро
                minHeight = Math.Min(minHeight, height[v]);
        }
        if (minHeight < int.MaxValue)
            height[u] = minHeight + 1; // Увеличиваем высоту
    }

    // Проталкиваем поток из вершины
    private void Push(int u)
    {
        foreach (var v in adj[u])
        {
            if (capacity[u, v] > 0 && excess[u] > 0 && height[u] > height[v])
            {
                int pushFlow = Math.Min(excess[u], capacity[u, v]); // Находим возможный поток
                excess[v] += pushFlow; // Увеличиваем избыточный поток в v
                excess[u] -= pushFlow; // Уменьшаем избыточный поток в u
                capacity[u, v] -= pushFlow; // Уменьшаем пропускную способность
                capacity[v, u] += pushFlow; // Увеличиваем пропускную способность обратного ребра
            }
        }
    }
}