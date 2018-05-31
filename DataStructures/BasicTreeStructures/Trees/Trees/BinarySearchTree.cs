using System;
using System.Collections.Generic;

public class BinarySearchTree<T> where T : IComparable<T>
{
    private class Node
    {
        public T Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Node(T value)
        {
            this.Value = value;
        }
    }

    private Node root;

    public BinarySearchTree()
    {

    }

    private BinarySearchTree(Node root)
    {
        this.Copy(root);
    }

    private void Copy(Node root)
    {
        if (root == null)
        {
            return;
        }

        this.Insert(root.Value);
        this.Copy(root.Left);
        this.Copy(root.Right);
    }

    public void Insert(T value)
    {
        Node newNode = new Node(value);
        if (this.root == null)
        {
            this.root = newNode;
            return;
        }
        Node current = this.root;
        Node parent = null;

        while (current != null)
        {
            if (current.Value.CompareTo(value) > 0)
            {
                parent = current;
                current = current.Left;
            }
            else if (current.Value.CompareTo(value) < 0)
            {
                parent = current;
                current = current.Right;
            }
            else
            {
                break;
            }
        }
        if (parent.Value.CompareTo(value) > 0)
        {
            parent.Left = newNode;
        }
        else
        {
            parent.Right = newNode;
        }
    }

    public bool Contains(T element)
    {
        Node current = FindElement(element);

        return current != null;
    }

    private Node FindElement(T element)
    {
        Node current = root;

        while (current != null)
        {
            if (current.Value.CompareTo(element) > 0)
            {
                current = current.Left;
            }
            else if (current.Value.CompareTo(element) < 0)
            {
                current = current.Right;
            }
            else
            {
                break;
            }
        }

        return current;
    }

    public void DeleteMin()
    {
        if (this.root == null)
        {
            return;
        }
        Node current = this.root;
        Node parent = null;
        while (current.Left != null)
        {
            parent = current;
            current = current.Left;
        }
        if (parent == null)
        {
            this.root = current.Right;
        }
        else
        {
            parent.Left = current.Right;
        }
    }

    public BinarySearchTree<T> Search(T element)
    {
        Node current = FindElement(element);

        return new BinarySearchTree<T>(current);
    }

    public IEnumerable<T> Range(T startRange, T endRange)
    {
        Queue<T> queue = new Queue<T>();
        this.GetElementsInRange(startRange, endRange, queue, root);
        return queue;
    }

    private void GetElementsInRange(T startRange, T endRange, Queue<T> queue, Node node)
    {
        if (node == null)
        {
            return;
        }
        // if -1 => there is left child smaller than the startIndex
        int lowerBound = startRange.CompareTo(node.Value);
        // if 1 => there is right child bigger than the endIndex
        int upperBound = endRange.CompareTo(node.Value);

        bool hasLeftChild = lowerBound < 0;
        bool hasRightChild = lowerBound > 0;
        bool hasNoSmallerAndBiggerChildIn = lowerBound <= 0 && upperBound >= 0;


        if (hasLeftChild)
        {
            this.GetElementsInRange(startRange, endRange, queue, node.Left);
        }
        if (hasNoSmallerAndBiggerChildIn)
        {
            queue.Enqueue(node.Value);
        }
        if (hasRightChild)
        {
            this.GetElementsInRange(startRange, endRange, queue, node.Right);
        }
    }

    public void EachInOrder(Action<T> action)
    {
        this.EachInOrder(this.root, action);
    }

    private void EachInOrder(Node node, Action<T> action)
    {
        if (node == null)
        {
            return;
        }
        this.EachInOrder(node.Left, action);
        action(node.Value);
        this.EachInOrder(node.Right, action);
    }
}
