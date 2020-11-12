using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
using UnityEngine.UI;
using System;
using System.Linq;

public class NewDialogueManager : MonoBehaviour
{
    //singletoooon
    public static NewDialogueManager _dlm;
    public static NewDialogueManager DLM { get { return _dlm; } }

    private void Awake()
    {
        if (_dlm != null && _dlm != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _dlm = this;
        }
    }

    [SerializeField]
    private ScriptableDialogue activeDialogue;
    private EdgeData _edgeData;
    private DialogueNodeData currentNode;

    public bool inDialogue;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && inDialogue)
        {
            NextDialogue();
        }
    }
    public void activateDialogue(ScriptableDialogue DialIn)
    {
        activeDialogue = DialIn;
        StartDialogue();

    }

    public void Interact()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(currentNode.dialogueTxt);
            foreach (var node in activeDialogue.ReturnOptions(currentNode))
            {
                Debug.Log(node.dialogueTxt);
                //pls maam just work
                //currentnode++;
            }
        }
    }

    public void StartDialogue()
    {
        inDialogue = true;

        EdgeData leadingEdge = activeDialogue.GraphEdges.Where(x => x.portName == "StartNodeEdge").First();
        //set current node ID to the first nodeID
        currentNode = activeDialogue.NodeData.Where(x => x.nodeID == leadingEdge.secondNodeID).First();

        //Debug.Log(currentNode.dialogueTxt);
    }

    public void NextDialogue()
    {

    }

    public void EndDialogue()
    {
        inDialogue = false;
    }

}
