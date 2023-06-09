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

    [Theory]
    [InlineData("World", true)]
    [InlineData("Hello", true)]
    [InlineData("Pytham", false)]
    [InlineData("Dave", false)]
    public void ExistsValue(string Value, bool expected)
    {
        var list = new DoublyLinkedList<string>();

        list.AddLast("Hello");
        list.Add("World");
        list.Add("WoW");

        Assert.True(list.Contains(Value) == expected);
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

    [Theory]
    [InlineData(0, 2)]
    [InlineData(3, 10)]
    [InlineData(2, 3)]
    public void SetValue(int index, int value)
    {
        var list = new DoublyLinkedList<int>();
        list.AddLast(1);
        list.AddLast(0);
        list.AddLast(-1);
        list.AddLast(5);


        list[index] = value;

        Assert.Equal(value, list[index]);
        Assert.True(list.Find(value) == index);
    }

    [Fact]
    public void IncrementANumberInList_ShouldSucceed()
    {
        var list = new DoublyLinkedList<int>(0);
        int maxIter = 10;
        for (int i = 0; i < maxIter; i++)
            list[0]= list[0] + 1; 

        Assert.Equal(maxIter, list[0]);
    }

    [Fact]
    public void AddDataToListWithThreads_ShouldSucceed()
    {
        //Arrange
        DoublyLinkedList<int> list = new();
        var synchronizedList = list.Synchronized();
        int len = 10;
        ParallelOptions options = new()
        {
            MaxDegreeOfParallelism = len
        };

        //Act
        Parallel.For(0, len, options, synchronizedList.Add);

        //Asserts
        Assert.Equal(len, list.Count);
        Assert.Equal(len, list.Distinct().Count());
    }

    [Fact]
    public void IncrementANumberInListWithThreads_ShouldSucceed()
    {
        //Arrange
        DoublyLinkedList<int> list = new(0);
        var synchronizedList = DoublyLinkedList<int>.Synchronized(list);
        int len = 2, maxIter = 1;
        ParallelOptions options = new()
        {
            MaxDegreeOfParallelism = len
        };

        //Act
        Parallel.For(0, len, options, i =>
        {
            for (int j = 0; j != maxIter; ++j)
            {
                synchronizedList[0]++;
            }
        });

        //Asserts
        Assert.Equal(maxIter * len, list[0]);
    }
}
