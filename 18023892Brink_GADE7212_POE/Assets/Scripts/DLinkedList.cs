﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class for the linked list
//public class DLinkedList
//{
//    //stores head node
//    private Node root;
//    //stores current node
//    private Node active;

//    //constructor
//    public DLinkedList(Node root)
//    {
//        this.root = root;
//        active = root;
//    }

//    //--------METHODS--------
//    //naviagtional utility - moves nodes or reads them
//    public void Next()
//    {
//        active = active.getNext();
//    }
//    public void Prev()
//    {
//        active = active.getPrev();
//    }
//    public string ReadData()
//    {
//        return active.getData();
//    }
//    public Node getActive()
//    {
//        return this.active;
//    }
//    //modification utilities - adding
//    public void AddNode(Node node, Node active)
//    {
//        //recursion - pretty useful
//            if (active.getNext() == null)
//            {
//                active.setNext(node);
//            }
//            else
//            {
//                AddNode(node, active.getNext());
//            }
//    }
//}

////class for the nodes
//public class Node
//{
//    private string data;

//    private Node next;
//    private Node prev;

//    public Node(string data)
//    {
//        this.data = data;
//    }

//    //-------METHODS---------//
//    //GETTERS
//    public Node getNext()
//    {
//        return next;
//    }
//    public Node getPrev()
//    {
//        return prev;
//    }
//    public string getData()
//    {
//        return data;
//    }
//    //SETTERS
//    public void setNext(Node next)
//    {
//        //to make sure list is linked in bth directions
//        next.setPrev(this);
//        this.next = next;
//    }
//    public void setPrev(Node prev)
//    {
//        this.prev = prev;
//    }
//}
