using System;

namespace MyList;

public class Program
{
    public static void Main(string[] args)
    {
        MyList myList = new MyList();

        myList.EndInsert(1);
        myList.EndInsert(2);
        myList.EndInsert(3);

        myList.ShowList();

        // Console.WriteLine(myList.Last.Prev.Data);
        // Console.WriteLine(myList.Length);
    }
}

public class Node
{
    public int Data { get; set; }
    public Node? Next { get; set; }
    public Node? Prev { get; set; }

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
    public Node? First { get; set; }
    public Node? Last { get; set; }

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

        Console.WriteLine();
    }

    public bool EndInsert(int data)
    {
        var insertNode = new Node();

        insertNode.Data = data;
        insertNode.Next = null;

        if (this.Length == 0)
        {
            insertNode.Prev = null;

            this.First = insertNode;
            this.Last = insertNode;
            this.Length++;
        }
        else
        {
            insertNode.Prev = this.Last;
            this.Last.Next = insertNode;

            this.Last = insertNode;
            this.Length++;
        }

        return true;
    }
}