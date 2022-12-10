namespace GenericCollectionsExtension.Tests.Queue;

public class DequeTests
{
    [Fact]
    public void PushAndPeekFirst()
    {
        var deque = new Deque<int>
        {
            1, 2, 5
        };

        //First Element: 5.

        Assert.Equal(5, deque.Peek());
    }

    [Fact]
    public void PushAndPeekLast()
    {
        var deque = new Deque<int>();

        deque.PushLast(1);
        deque.PushLast(2);
        deque.PushLast(5);

        //Last Element: 5.

        Assert.Equal(5, deque.PeekLast());
    }

    [Fact]
    public void CapacityLessThanZero()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var deque = new Deque<int>(-1);
        });
    }

    [Fact]
    public void CapacityGreaterThanZero()
    {
        Action test = () =>
        {
            var deque = new Deque<int>(1);
        };

        Assert.IsType<Action>(test);
    }

    [Fact]
    public void PopLast()
    {
        //Push First
        var deque = new Deque<string>()
        {
            "Hola",
            "D",
            "M"
        };

        var last = deque.PopLast();

        Assert.Equal("Hola", last);
        Assert.Equal(2, deque.Count);
    }
}
