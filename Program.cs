using System;

namespace MyList;

public class Program
{
    public static void Main(string[] args)
    {
        MyList myList = new MyList();

        myList.BeginningInsertion(1);
        // myList.BeginningInsertion(2);
        // myList.EndInsertion(4);
        // myList.BeginningInsertion(3);

        // myList.ShowList();

        // Console.WriteLine(myList.BeginningRemove());
        // Console.WriteLine(myList.BeginningRemove());
        // Console.WriteLine(myList.BeginningRemove());

        // Console.WriteLine(myList.First);

        // myList.ShowList();
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
    public int Length { get; set; }
    public Node First { get; set; }
    public Node Last { get; set; }

    public MyList()
    {
        Length = 0;
        First = null;
        Last = null;
    }

    public void ShowList()
    {
        var nodeAux = this.First;

        for (var i = 0; i < this.Length; i++)
        {
            Console.Write($"{nodeAux.Data} ");

            nodeAux = nodeAux.Next;
        }

        if (this.Length != 0)
        {
            Console.WriteLine();
        }
    }

    public void EndInsertion(int data)
    {
        var insertNode = new Node();

        insertNode.Data = data;
        insertNode.Next = null;

        if (this.Length == 0)
        {
            insertNode.Prev = null;

            this.First = insertNode;
            this.Last = insertNode;
        }
        else
        {
            insertNode.Prev = this.Last;
            this.Last.Next = insertNode;

            this.Last = insertNode;
        }

        this.Length++;
    }

    public void BeginningInsertion(int data)
    {
        var insertNode = new Node();

        insertNode.Data = data;
        insertNode.Prev = null;

        if (this.Length == 0)
        {
            insertNode.Next = null;

            this.First = insertNode;
            this.Last = insertNode;
        }
        else
        {
            insertNode.Next = this.First;
            this.First.Prev = insertNode;

            this.First = insertNode;
        }

        this.Length++;
    }

    public int BeginningRemove()
    {
        int returnData;

        if (this.Length == 0)
        {
            return -1;
        }
        else if (this.Length == 1)
        {
            returnData = this.First.Data;

            this.First = null;
            this.Last = null;
        }
        else
        {
            returnData = this.First.Data;

            this.First = this.First.Next;
            this.First.Prev = null;
        }

        this.Length--;

        return returnData;
    }

    public int EndRemove()
    {
        int returnData = 0;

        if (this.Length == 0)
        {
            return -1;
        }
        else if (this.Length == 1)
        {
            returnData = this.Last.Data;

            this.First = null;
            this.Last = null;
        }
        else
        {
            returnData = this.Last.Data;

            this.Last = this.Last.Prev;
            this.Last.Next = null;
        }

        this.Length--;

        return returnData;
    }
}