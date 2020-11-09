﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//in order to make the graphview
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using System;

public class DialogueGV : GraphView
{
    //making use of this video for creating a graph view to imlement the graph dialogue
    //https://www.youtube.com/watch?v=7KHGH0fPL84

        //default node size 
    private readonly Vector2 defaultNodeSize = new Vector2(150, 200);

    //constructor
    public DialogueGV()
    {
        //screen go zoooom
        SetupZoom(ContentZoomer.DefaultMinScale, ContentZoomer.DefaultMaxScale);

        //content dragger, selection dragger and rectangle selector
        this.AddManipulator(new ContentDragger());
        this.AddManipulator(new SelectionDragger());
        this.AddManipulator(new RectangleSelector());

        //add element of entry point node to graph view
        AddElement(CreateEntryPointNode());
    }

    //creating a port
    //takes n the node, the direction the port is going to, and the cpacity of the port
    private Port CreatePort(DialogueNode node, Direction portDirection, Port.Capacity portCapacity = Port.Capacity.Single)
    {
        //not transmitting data between ports so type is arbitrary
        return node.InstantiatePort(Orientation.Horizontal, portDirection, portCapacity, typeof(float));
    }

    //creating the first node
    private DialogueNode CreateEntryPointNode()
    {
        //new node and what it contains
        var node = new DialogueNode
        {
            //node name
            title = "Start",
            //makng a new unique id for it
            nodeID = Guid.NewGuid().ToString(),
            //the dialogue text
            dialogueText = "EntryPoint",
            //whether or not this is the entry node
            entryPoint = true
        };

        var createdPort = CreatePort(node, Direction.Output);
        createdPort.portName = "Next";
        //output container for this new node
        node.outputContainer.Add(createdPort);

        //refresh after adding ports to update the visuals 
        node.RefreshExpandedState();
        node.RefreshPorts();

        //setting the pos of the node in the graph view
        node.SetPosition(new Rect(100, 200, 200, 150));
        //return the node
        return node;
    }

    //basically the same as enry node, but for dialogue so some changes such as multiple ports
    public DialogueNode CreateDialogueNode(string nodeName)
    {
        var dialogueNode = new DialogueNode
        {
            title = nodeName,
            dialogueText = nodeName,
            nodeID = Guid.NewGuid().ToString()
        };

        //can have multiple ports
        var inputPort = CreatePort(dialogueNode, Direction.Input, Port.Capacity.Multi);
        inputPort.portName = "Input";
        dialogueNode.inputContainer.Add(inputPort);

        //clicking the button to add a new choice port
        var button = new Button(clickEvent: () => { AddChoicePort(dialogueNode); });
        //adding the choice button to allow us to add a new port that will represent a new dialogue choice
        button.text = "New Choice";
        dialogueNode.titleContainer.Add(button);

        //refresh after adding ports to update the visuals 
        dialogueNode.RefreshExpandedState();
        dialogueNode.RefreshPorts();

        //setting the pos of the node in the graph view
        dialogueNode.SetPosition(new Rect(Vector2.zero, defaultNodeSize));
        //return the node
        return dialogueNode;
    }

    private void AddChoicePort(DialogueNode dialogueNode)
    {
        //creating a port
        var createdPort = CreatePort(dialogueNode, Direction.Output);

        //change port name for each option
        //search for all ports in output container of this node
        var outputPortCount = dialogueNode.outputContainer.Query("connector").ToList().Count;
        //assign port name as choice port count
        createdPort.portName = $"Choice {outputPortCount}";

        //add this port to output container
        dialogueNode.outputContainer.Add(createdPort);

        //refresh after adding ports to update the visuals 
        dialogueNode.RefreshExpandedState();
        dialogueNode.RefreshPorts();
    }

    //creating the node so that it dsplays on the graph view
    public void CreateNode(string nodeName)
    {
        AddElement(CreateDialogueNode(nodeName));
    }

    //a list of which ports are compatible - for connecting ports to nodes to create edges
    public override List<Port> GetCompatiblePorts(Port startPort, NodeAdapter nodeAdapter)
    {
        var compatiblePorts = new List<Port>();

        //dont want to connect port to itself, or a node input port to its own output port (infinite loop)
        //if conditions are met, add it to compatible list
        ports.ForEach(funcCall: (port) =>
            {
                if (startPort !=port && startPort.node != port.node)
                {
                    compatiblePorts.Add(port);
                }
            }
        );
        
        return compatiblePorts;
    }
}
