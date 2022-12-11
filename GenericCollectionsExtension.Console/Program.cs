using GenericCollectionsExtension.SortedList;
using GenericCollectionsExtension.Queue;
using GenericCollectionsExtension.Stack;

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
priorityQueue.Enqueue(10, 5);
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

Console.WriteLine("Deque: ");

Deque<int> deque = new();
deque.PushFirst(1);
deque.PushFirst(2);
deque.PushFirst(5);

Console.WriteLine($"Count: {deque.Count}");
foreach(var item in deque)
{
    Console.WriteLine(item);
}


Console.WriteLine("Priority Stack: ");

PriorityStack<int> stack = new()
{
    4, 5, 3, 5
};

Console.WriteLine($"Count: {stack.Count}");

Console.WriteLine($"Value: {stack.Peek()}");

foreach(var item in stack)
{
    Console.WriteLine(item);
}



