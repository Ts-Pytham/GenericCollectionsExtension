namespace GenericCollectionsExtension.Tests.Tree;

public class BinarySearchTreeTests
{
    [Fact]
    public void InsertDataInTree()
    {
        BinarySearchTree<int> tree = new() // InOrder default
        {
            9, 1, 0, 19, 4
        };

        Assert.Equal(5, tree.Count);
    }

    [Fact] 
    public void InOrderTraversal()
    {
        BinarySearchTree<int> tree = new() // InOrder default
        {
            9, 1, 0, 19, 4
        };

        SortedList<int> list = new()
        {
            9, 1, 0, 19, 4
        };

        Assert.Equal(tree, list);

    }

    [Fact]
    public void PreOrderTraversal()
    {
        BinarySearchTree<int> tree = new(TraversalType.PreOrder)
        {
            10, 1, 0, 19
        };

        List<int> list = new() 
        { 
            10, 1, 0, 19
        };

        Assert.Equal(tree, list);

    }

    [Fact]
    public void PostOrderTraversal()
    {
        BinarySearchTree<int> tree = new(TraversalType.PostOrder)
        {
            40, 30, 35, 25, 28, 15, 50, 45, 60, 70, 55
        };

        List<int> list = new()
        {
            15, 28, 25, 35, 30, 45, 55, 70, 60, 50, 40
        };

        Assert.Equal(tree, list);

    }

    [Fact]
    public void SearchItem()
    {
        BinarySearchTree<string> tree = new()
        {
            "Hola",
            "Mundo",
            "Nint"
        };

        Assert.Contains("Nint", tree);
    }

    [Fact]
    public void RepeatedItems()
    {
        BinarySearchTree<int> tree = new()
        {
            10, 39, 50, 2, 3, 10, 20
        };

        Assert.True(tree.RepeatedNodes.ContainsKey(10));
        Assert.False(tree.RepeatedNodes.ContainsKey(50)); // The value 50 is not repeated
    }

    [Fact]
    public void DeleteLeafFirstCase()
    {
        BinarySearchTree<int> tree = new()
        {
            5, 1, -1, 4, 10
        };

        // Representación
        /*       5
         *    1    10  
         * -1  4
         * 
         * -1 and 4 are leafs
         */

        Assert.True(tree.Remove(-1));
        Assert.Equal(4, tree.Count);
    }

    [Fact]
    public void DeleteNodeSecondCase()
    {
        // At least has one child node

        BinarySearchTree<int> tree = new()
        {
            5, 1, -1, 10
        };

        // Representación
        /*       5
         *    1    10  
         * -1  
         * 
         * 1 have a left child
         */

        SortedList<int> sortedList = new()
        {
            5, -1, 10
        };
        Assert.True(tree.Remove(1));
        Assert.DoesNotContain(1, tree);
        Assert.Equal(3, tree.Count);
        Assert.Equal(sortedList, tree);
    }

    [Fact]
    public void DeleteNodeThridCase()
    {
        BinarySearchTree<int> tree = new()
        {
            5, 1, -1, 2, 10
        };

        // Representación
        /*              5
         *           1       10  
         *      -1      2  
         * 
         * 1 have two childs
         */

        Assert.True(tree.Remove(1));
        Assert.DoesNotContain(1, tree);
        Assert.Equal(4, tree.Count);
        Assert.Equal(new SortedList<int>() { 5, -1, 2, 10 }, tree);
    }

    [Fact]
    public void DeleteNodeThridCase2()
    {
        BinarySearchTree<int> tree = new()
        {
            5, 1, -1, 2, 10, 12, 14
        };

        // Representación
        /*                5
         *           1       10  
         *      -1      2       12
         *                          14
         * 
         * 1 have two childs
         */

        Assert.True(tree.Remove(10));
        Assert.DoesNotContain(10, tree);
        Assert.Equal(6, tree.Count);
        Assert.Equal(new SortedList<int>() { 5, -1, 2, 1, 12, 14}, tree);
    }
}
