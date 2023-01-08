namespace GenericCollectionsExtension.Tests.Stack;

public class PriorityStackTests
{
    [Fact]
    public void CapacityLessThanZero()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var stack = new PriorityStack<int>(-1);
        });
    }

    [Fact]
    public void CapacityGreaterThanZero()
    {
        Action test = () =>
        {
            var stack = new PriorityStack<int>(1);
        };

        Assert.IsType<Action>(test);
    }

    [Theory]
    [InlineData(new[] { "ho", "la", "ma" }, new[] { 1, 10, 2 }, "la")]
    [InlineData(new[] { "Pytham", "MrDave", "Holly" }, new[] { 20, 10, 50 }, "Holly")]
    [InlineData(new[] { "Do", "Re", "Mi" }, new[] { 0, 0, 0 }, "Mi")]
    public void CheckPriority(string[] items, int[] priority, string value)
    {
        int len = items.Length;
        var stack = new PriorityStack<string>();

        for (int i = 0; i != len; ++i)
        {
            stack.Push(items[i], priority[i]);
        }

        Assert.Equal(value, stack.Peek());
    }

    [Fact]
    public void PriorityNegative()
    {
        var stack = new PriorityStack<string>();

        var test = () =>
        {
            stack.Push("Hello", -1);
        };

        Assert.Throws<NegativeNumberException>(test);
    }

    [Theory]
    [InlineData(new[] { 10f, 0f, 3f }, new[] { 0, 0, 0}, 3f)]
    [InlineData(new[] { 20f, 3.5f, 2.99f }, new[] { 50, 10, 0 }, 20f)]
    [InlineData(new[] { 1.11f, 2.53f, 3.1415f }, new[] { 10, 20, 5 }, 2.53f)]
    [InlineData(new[] { 1.1f, 3f, -0.5f }, new[] { 47, 0, 65 }, -0.5f)]
    public void Pop(float[] items, int[] priority, float pop)
    {
        int len = items.Length;
        var stack = new PriorityStack<float>();

        for (int i = 0; i != len; ++i)
        {
            stack.Push(items[i], priority[i]);
        }

        Assert.True(stack.Pop() == pop);
        Assert.True(stack.Count == len - 1);
    }

    [Theory]
    [InlineData(new[] { 10f, 0f, 3f }, new[] { 0, 0, 0 }, 3f)]
    [InlineData(new[] { 20f, 3.5f, 2.99f }, new[] { 50, 10, 0 }, 20f)]
    [InlineData(new[] { 1.11f, 2.53f, 3.1415f }, new[] { 10, 20, 5 }, 2.53f)]
    [InlineData(new[] { 1.1f, 3f, -0.5f }, new[] { 47, 0, 65 }, -0.5f)]
    public void Peek(float[] items, int[] priority, float peek)
    {
        int len = items.Length;
        var stack = new PriorityStack<float>();

        for (int i = 0; i != len; ++i)
        {
            stack.Push(items[i], priority[i]);
        }

        Assert.True(stack.Peek() == peek);
        Assert.True(stack.Count == len);
    }

    [Theory]
    [InlineData(new[] { 10f, 0f, 3f }, new[] { 0, 0, 0 }, 3f)]
    [InlineData(new[] { 20f, 3.5f, 2.99f }, new[] { 50, 10, 0 }, 20f)]
    [InlineData(new[] { 1.11f, 2.53f, 3.1415f }, new[] { 10, 20, 5 }, 2.53f)]
    [InlineData(new[] { 1.1f, 3f, -0.5f }, new[] { 47, 0, 65 }, -0.5f)]
    public void TryPeek(float[] items, int[] priority, float peek)
    {
        int len = items.Length;
        var stack = new PriorityStack<float>();

        for (int i = 0; i != len; ++i)
        {
            stack.Push(items[i], priority[i]);
        }
        Assert.True(stack.TryPeek(out float result));
        Assert.True(peek == result);
    }
}
