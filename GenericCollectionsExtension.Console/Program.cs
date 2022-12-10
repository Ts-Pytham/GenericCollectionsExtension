using GenericCollectionsExtension.SortedList;
using GenericCollectionsExtension.Queue.PriorityQueue;

SortedList<int> sortedList = new(Criterion.Descending)
{
    1,
    0,
    -1,
    495,
    1,
    19,
    5
};

Console.WriteLine($"total items: {sortedList.Count}");
sortedList.ToList().ForEach(Console.WriteLine);

Console.WriteLine("PriorityQueue: ");

PriorityQueue<int> priorityQueue = new();
priorityQueue.Enqueue(10, 1);
priorityQueue.Enqueue(50, 2);
priorityQueue.Enqueue(55, 2);
priorityQueue.Enqueue(20, 3);

foreach (int item in priorityQueue)
{
    Console.WriteLine(item);
}

Console.WriteLine($"Peek: {priorityQueue.Peek()}");
int contains = 51;
Console.WriteLine($"Contains: {contains}, {priorityQueue.Contains(contains)}");





