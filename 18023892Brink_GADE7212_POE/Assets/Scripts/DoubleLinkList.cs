using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleLinkList : IEnumerable<Node>
{
    //https://www.youtube.com/watch?v=N02o3EaNkXk

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

    //-----------------------ADD (ADD LAST)-----------------------//
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

    //-----------------------ADD FIRST-----------------------//
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
    //-----------------------GET SPECIFIC NODE-----------------------//
    //https://www.geeksforgeeks.org/write-a-function-to-get-nth-node-in-a-linked-list/

    public string GetNth(int index)
    {
        Node current = head;
        int count = 1; /* index of Node we are  
                        currently looking at */
        while (current != null)
        {
            if (count == index)
            {
                return current.Data;
            }

            count++;
            current = current.Next;
            //Debug.Log(current.Data);
        }
        return "0";
    }
    public string GetNext()
    {
        Node current = head;
        while (current != null)
        {
            return current.Data;
        }

        current = current.Next;
        Length++;
        return "0";

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
