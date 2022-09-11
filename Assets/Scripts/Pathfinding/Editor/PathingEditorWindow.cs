using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PathingEditorWindow : EditorWindow {

    [MenuItem("Museum Tools/Navigation")]
    private static void ShowWindow()
    {
        SceneModeUtility.SearchForType(typeof(PathNode));
        var window = GetWindow<PathingEditorWindow>();
        window.titleContent = new GUIContent("Museum Navigation");
        window.Show();
    }

    private void OnGUI() 
    {
       if(Event.current.type == EventType.MouseDown)
       {

       }
        
    }
}