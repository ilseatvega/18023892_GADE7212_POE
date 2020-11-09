using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//in order to make the graphview
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

public class DialogueGraph : EditorWindow
{
    private DialogueGV _graphView;

    //static method to open the Dilaogue Graph Window
    //to be able to call it statically from the editor
    //graph = main menu, dialogue graph = sub menu
    [MenuItem("Graph/Dialogue Graph")]
    public static void OpenDialogueGraphWindow()
    {
        var window = GetWindow<DialogueGraph>();
        //giving the window a title
        window.titleContent = new GUIContent("Dialogue Graph");
    }

    //when window is enabled
    private void OnEnable()
    {
        ConstructGV();
        CreateToolbar();
    }

    private void OnDisable()
    {
        //removing it so it doesnt overlap if it is opened multiple times
        rootVisualElement.Remove(_graphView);
    }

    private void ConstructGV()
    {
        //instance of dialogue gv
        _graphView = new DialogueGV
        {
            //name of this instance
            name = "DialogueGraph"
        };

        _graphView.StretchToParentSize();
        //adding graph window to unity work space window
        rootVisualElement.Add(_graphView);
    }

    //a toolbar tat will allow us to easily create a new node using a node creation button
    private void CreateToolbar()
    {
        var toolbar = new Toolbar();

        var nodeCreateButton = new Button(clickEvent: () => { _graphView.CreateNode("Dialogue Node"); });
        nodeCreateButton.text = "Create Node";
        toolbar.Add(nodeCreateButton);

        //add toolbar into editor window
        rootVisualElement.Add(toolbar);
    }
}
