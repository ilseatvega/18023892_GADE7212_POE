using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
using System;
using System.Linq;

[Serializable]

public class ScriptableDialogue : ScriptableObject
{
    public List<EdgeData> GraphEdges = new List<EdgeData>();
    public List<DialogueNodeData> NodeData = new List<DialogueNodeData>();
    
    //method to retun all adjacent nodes
    public List<DialogueNodeData> ReturnOptions(DialogueNodeData current)
    {
        List<EdgeData> edges = GraphEdges.Where(x=>x.firstNodeID == current.nodeID).ToList();
        List<DialogueNodeData> nodes = new List<DialogueNodeData>();

        edges.ForEach(e=>NodeData.Where(n=>n.nodeID == e.secondNodeID).ToList().ForEach(n => nodes.Add(n)));

        return nodes;
    }

}
