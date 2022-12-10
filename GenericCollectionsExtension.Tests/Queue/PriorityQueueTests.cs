namespace GenericCollectionsExtension.Tests.Queue;

public class PriorityQueueTests
{
    [Fact]
    public void CapacityLessThanZero()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => 
        { 
            var queue = new PriorityQueue<int>(-1); 
        });
    }

    [Fact]
    public void CapacityGreaterThanZero()
    {
        Action test = () =>
        {
            var queue = new PriorityQueue<int>(1);
        };

        Assert.IsType<Action>(test);
    }

    [Fact]
    public void CheckPriority()
    {
        var queue = new PriorityQueue<string>();

        queue.Enqueue("Pytham", 20);
        queue.Enqueue("MrDave", 10);
        queue.Enqueue("Holly" , 50); //High priority

        Assert.Equal("Holly", queue.Dequeue());
    }

    [Fact]
    public void PriorityNegative()
    {
        var queue = new PriorityQueue<int>();

        var test = () =>
        {
            queue.Enqueue(20, -1);
        };

        Assert.Throws<NegativeNumberException>(test);
    }

    [Fact]
    public void Dequeue()
    {
        var queue = new PriorityQueue<float>();

        queue.Enqueue(10f, 0);
        queue.Enqueue(-20f, 5);

        Assert.True(queue.Dequeue() == -20f);
        Assert.True(queue.Count == 1);
    }

    [Fact]
    public void Peek()
    {
        var queue = new PriorityQueue<double>();

        queue.Enqueue(10.493, 0);
        queue.Enqueue(-20.3910, 0);

        Assert.True(queue.Peek() == 10.493);
        Assert.True(queue.Count == 2);
    }

    [Fact]
    public void ExistsItems()
    {
        var queue = new PriorityQueue<int>();

        queue.Enqueue(5, 0);
        queue.Enqueue(10, 0);
        queue.Enqueue(20, 10);
        queue.Enqueue(50, 50);

        Assert.Contains(5, queue);
        Assert.Contains(50, queue);
    }
}
