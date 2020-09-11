using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleLinkList : IEnumerable<Node>
{
    private Node head;
    public Node First
    {
        get { return head; }
    }

    private Node tail;
    public Node Last
    {
        get { return tail;  }
    }

    public int Length { get; private set; }

    public IEnumerator<Node> GetEnumerator()
    {
        Node current = head;
        while (current != null)
        {
            yield return current;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerable GetEnumeratorReverse()
    {
        Node current = tail;
        while (current != null)
        {
            yield return current;
            current = current.Prev;
        }
    }

    //addlast
        public void Add(string data)
    {
        Node newNode = new Node(data);
        if (tail == null)
        {
            head = newNode;
        }
        else
        {
            newNode.Prev = tail;
            tail.Next = newNode;
        }

        tail = newNode;
        Length++;
    }


    public void Addfirst(string data)
    {
        Node newNode = new Node(data);
        newNode.Next = head;

        if (head == null)
        {
            tail = newNode;
        }
        else
        {
            head.Prev = newNode;
        }

        head = newNode;
        Length++;
    }

    //checks if item exists in list
    public bool Contains(string value)
    {
        Node current = head;
        while (current != null)
        {
            if (current.Data == value)
            {
                return true;
            }

            current = current.Next;
        }
        return false;
    }

    //finds first node that contains specified value
    public Node Find(string value)
    {
        Node current = head;
        while (current != null)
        {
            if (current.Data == value)
            {
                return current;
            }

            current = current.Next;
        }
        return null;
    }
    //finds last node that contains specified value
    public Node FindLast(string value)
    {
        Node current = tail;
        while (current != null)
        {
            if (current.Data == value)
            {
                return current;
            }

            current = current.Prev;
        }
        return null;
    }
}

//public class Node
//{
//    private string _data;
//    public string Data
//    {
//        get { return _data; }
//        set { _data = value; }
//    }

//    private Node _next;
//    public Node Next
//    {
//        get { return _next; }
//        set { _next = value; }
//    }


//    private Node _prev;
//    public Node Prev
//    {
//        get { return _prev; }
//        set { _prev = value; }
//    }

//    public Node(string data)
//    {
//        Data = data;
//    }
//}
