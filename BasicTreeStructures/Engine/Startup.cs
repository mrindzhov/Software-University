using System;
using System.Collections.Generic;
using System.Linq;

class Startup
{
    static Dictionary<int, Tree<int>> nodeByValue = new Dictionary<int, Tree<int>>();

    static void Main(string[] args)
    {
        ReadTree();
        //Console.WriteLine($"Root node: {GetRootNode().Value}");
        //Console.WriteLine($"Middle nodes: {string.Join(" ", GetMiddleNodes())}");
        //Console.WriteLine($"Leaf nodes: {string.Join(" ", GetLeafNodes())}");
        //Console.WriteLine($"Longest path: {string.Join(" ", FindLongestPath(GetRootNode()).Reverse())}");
        //Console.WriteLine($"Deepest node: {FindDeepestNode(GetRootNode())}");
        //myTree.PrintTree();
        //var nodes = GetPathsWithGivenSum(GetRootNode());
        //foreach (var node in nodes)
        //{
        //    PrintPreOrder(node);
        //}
        var trees = FindSubtreesWithGivenSum(GetRootNode());
        foreach (var tree in trees)
        {
            PrintPreOrder(tree);
            Console.WriteLine();
        }
    }
    private static void PrintPreOrder(Tree<int> tree)
    {
        Console.Write(tree + " ");
        foreach (var child in tree.Children)
        {
            PrintPreOrder(child);
        }
    }

    private static List<Tree<int>> FindSubtreesWithGivenSum(Tree<int> node)
    {
        List<Tree<int>> roots = new List<Tree<int>>();

        int sum = int.Parse(Console.ReadLine());
        Console.WriteLine($"Subtrees of sum {sum}:");

        DFSSubtrees(node, sum, 0, roots);

        return roots;

    }

    private static int DFSSubtrees(Tree<int> node, int sum, int current, List<Tree<int>> roots)
    {
        if (node == null)
        {
            return 0;
        }
        current = node.Value;

        foreach (var child in node.Children)
        {
            current += DFSSubtrees(child, sum, current, roots);
        }

        if (current == sum)
        {
            roots.Add(node);
        }
        return current;
    }

    private static void PrintPath(Tree<int> node)
    {
        var stack = new Stack<int>();
        var current = node;
        while (current != null)
        {
            stack.Push(current.Value);
            current = current.Parent;
        }
        Console.WriteLine(string.Join(" ", stack.ToArray()));
    }

    private static List<Tree<int>> GetPathsWithGivenSum(Tree<int> node)
    {
        List<Tree<int>> result = new List<Tree<int>>();

        int sum = int.Parse(Console.ReadLine());
        Console.WriteLine($"Paths of sum {sum}:");

        DFSPath(node, sum, 0, result);

        return result;
    }

    private static IEnumerable<int> FindLongestPath(Tree<int> node)
    {
        int maxLevel = 0;
        Tree<int> deepest = null;
        DFS(node, 0, ref maxLevel, ref deepest);

        while (deepest != null)
        {
            Tree<int> old = deepest;
            deepest = deepest.Parent;
            yield return old.Value;
        }
    }

    public static Tree<int> FindDeepestNode(Tree<int> root)
    {
        int maxLevel = 0;
        Tree<int> deepest = null;
        DFS(root, 0, ref maxLevel, ref deepest);
        return deepest;
    }

    private static void DFSPath(Tree<int> node, int target, int current, List<Tree<int>> leafs)
    {
        if (node == null)
        {
            return;
        }
        current += node.Value;
        if (current == target && node.Children.Count == 0)
        {
            leafs.Add(node);
        }
        foreach (var child in node.Children)
        {
            DFSPath(child, target, current, leafs);
        }
    }

    private static void DFS(Tree<int> node, int level, ref int maxLevel, ref Tree<int> deepest)
    {
        if (node == null)
        {
            return;
        }
        if (level > maxLevel)
        {
            deepest = node;
            maxLevel = level;
        }
        foreach (var child in node.Children)
        {
            DFS(child, level + 1, ref maxLevel, ref deepest);
        }
    }

    private static IEnumerable<int> GetMiddleNodes()
    {
        return nodeByValue.Values.Where(x => x.Children.Count != 0 && x.Parent != null)
            .Select(x => x.Value).OrderBy(x => x).ToList();
    }

    private static IEnumerable<int> GetLeafNodes()
    {
        return nodeByValue.Values.Where(x => x.Children.Count == 0)
            .Select(x => x.Value).OrderBy(x => x).ToList();
    }

    private static Tree<int> GetRootNode()
    {
        return nodeByValue.Values.FirstOrDefault(v => v.Parent == null);
    }

    private static void ReadTree()
    {
        int nodeCount = int.Parse(Console.ReadLine());
        for (int i = 1; i < nodeCount; i++)
        {
            string[] edge = Console.ReadLine().Split(' ');
            AddEdge(int.Parse(edge[0]), int.Parse(edge[1]));
        }
    }

    private static Tree<int> GetTreeNodeByValue(int value)
    {
        if (!nodeByValue.ContainsKey(value))
        {
            nodeByValue[value] = new Tree<int>(value);
        }
        return nodeByValue[value];
    }

    private static void AddEdge(int parent, int child)
    {
        Tree<int> parentNode = GetTreeNodeByValue(parent);
        Tree<int> childNode = GetTreeNodeByValue(child);
        parentNode.Children.Add(childNode);
        childNode.Parent = parentNode;
    }
}
