using System;

namespace MyList;

public class Program
{
    public static void Main(string[] args)
    {
        MyList List = new MyList();

        List.BeginningInsertion(1);
        List.BeginningInsertion(2);

        // Console.WriteLine(List.Contains(3));

        Console.WriteLine(List.Length());

        // List.ShowList();
    }
}

public class Node
{
    public int Data { get; set; }
    public Node Next { get; set; }
    public Node Prev { get; set; }

    public Node(int Data, Node Next, Node Prev)
    {
        this.Data = Data;
        this.Next = Next;
        this.Prev = Prev;
    }

    public Node() { }
}

public class MyList
{
    private int _length { get; set; }
    private Node _first { get; set; }
    private Node _last { get; set; }

    public MyList()
    {
        _length = 0;
        _first = null;
        _last = null;
    }

    public void ShowList()
    {
        var nodeAux = this._first;

        for (var i = 0; i < this._length; i++)
        {
            Console.Write($"{nodeAux.Data} ");

            nodeAux = nodeAux.Next;
        }

        if (this._length != 0)
        {
            Console.WriteLine();
        }
    }

    public void EndInsertion(int data)
    {
        var insertNode = new Node();

        insertNode.Data = data;
        insertNode.Next = null;

        if (this._length == 0)
        {
            insertNode.Prev = null;

            this._first = insertNode;
            this._last = insertNode;
        }
        else
        {
            insertNode.Prev = this._last;
            this._last.Next = insertNode;

            this._last = insertNode;
        }

        this._length++;
    }

    public void BeginningInsertion(int data)
    {
        var insertNode = new Node();

        insertNode.Data = data;
        insertNode.Prev = null;

        if (this._length == 0)
        {
            insertNode.Next = null;

            this._first = insertNode;
            this._last = insertNode;
        }
        else
        {
            insertNode.Next = this._first;
            this._first.Prev = insertNode;

            this._first = insertNode;
        }

        this._length++;
    }

    public int BeginningRemove()
    {
        int returnData;

        if (this._length == 0)
        {
            return -1;
        }
        else if (this._length == 1)
        {
            returnData = this._first.Data;

            this._first = null;
            this._last = null;
        }
        else
        {
            returnData = this._first.Data;

            this._first = this._first.Next;
            this._first.Prev = null;
        }

        this._length--;

        return returnData;
    }

    public int EndRemove()
    {
        int returnData = 0;

        if (this._length == 0)
        {
            return -1;
        }
        else if (this._length == 1)
        {
            returnData = this._last.Data;

            this._first = null;
            this._last = null;
        }
        else
        {
            returnData = this._last.Data;

            this._last = this._last.Prev;
            this._last.Next = null;
        }

        this._length--;

        return returnData;
    }

    public bool Contains(int data)
    {
        Node nodeAux;

        if (this._length == 0)
        {
            return false;
        }
        else
        {
            nodeAux = this._first;

            for (int i = 0; i < this._length; i++)
            {
                if (nodeAux.Data == data)
                {
                    return true;
                }

                nodeAux = nodeAux.Next;
            }
        }

        return false;
    }

    public int Length()
    {
        return this._length;
    }
}