namespace GenericCollectionsExtension.Tests.List.DoublyLinkedList;

public class DoublyLinkedListTests
{
    [Fact]
    public void AddFirst()
    {
        var list = new DoublyLinkedList<int>
        {
            1, 2, 3
        };

        Assert.Equal(3, list.Count);
        Assert.Equal(new[] { 3, 2, 1 }, list);
    }

    [Fact]
    public void AddLast()
    {
        var list = new DoublyLinkedList<int>();

        list.AddLast(1);
        list.AddLast(2);
        list.AddLast(3);

        Assert.Equal(3, list.Count);
        Assert.Equal(new[] { 1, 2, 3 }, list);
    }

    [Fact]
    public void AddFirstAndLast()
    {
        var list = new DoublyLinkedList<int>();

        list.AddLast(1);
        list.Add(2);
        list.AddLast(3);
        list.Add(4);

        Assert.Equal(4, list.Count);
        Assert.Equal(new[] { 4, 2, 1, 3 }, list);
    }

    [Fact]
    public void GetFirstAndLast()
    {
        var list = new DoublyLinkedList<int>();

        list.AddLast(1);
        list.Add(2);
        list.AddLast(3);
        list.Add(4);

        Assert.Equal(4, list.Count);
        Assert.Equal(4, list.GetFirst());
        Assert.Equal(3, list.GetLast());
    }

    [Fact]
    public void GetValue()
    {
        var list = new DoublyLinkedList<string>();

        list.AddLast("Hello");
        list.Add("World");
        list.Add("WoW");

        Assert.Contains("WoW", list);
    }

    [Fact]
    public void TestRemove()
    {
        // Arrange
        var list = new DoublyLinkedList<int>
        {
            1,
            2,
            3,
            4
        };

        // Act
        var result = list.Remove(2);

        // Assert
        Assert.True(result); 
        Assert.Equal(3, list.Count);
        Assert.Equal(new int[] { 4, 3, 1 }, list); 
    }

    [Theory]
    [InlineData(5, false)]
    [InlineData(0, false)]
    [InlineData(-4, false)]
    public void TestRemoveFalse(int toRemove, bool expected)
    {
        var list = new DoublyLinkedList<int>
        {
            1,
            2,
            3,
            4
        };

        // Act
        var result = list.Remove(toRemove);

        Assert.Equal(result, expected);
        Assert.Equal(4, list.Count);
    }
}
