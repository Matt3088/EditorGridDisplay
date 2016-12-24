using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;

public class EditorGridDisplayExampleWindow : EditorWindow
{
    Color[] colors = new Color[]
    {
        Color.red, Color.green, Color.blue, Color.yellow,
        Color.red, Color.green, Color.blue, Color.yellow
    };

    float scrollPosition = 0.0f;
    int itemWidth = 140;

    [MenuItem("Window/EditorGridDisplayExampleWindow")]
    static void Init()
    {
        EditorGridDisplayExampleWindow window = (EditorGridDisplayExampleWindow)EditorWindow.GetWindow(
            typeof(EditorGridDisplayExampleWindow), false, "EditorGridDisplay");
        window.position = new Rect(200, 200, 200, 500);
        window.minSize = new Vector2(200, 500);
    }

    public void OnGUI()
    {
        DrawColorTab(position);
    }

    public void DrawColorTab(Rect window)
    {
        //call begin, passing required variables (can be called at any time)
        EditorGridDisplay.Begin(window, itemWidth);

        //set the draw action, this is what tells the class what will be drawn for each data item (can be called at any time)
        EditorGridDisplay.SetDrawAction(index =>
        {
            //use the current index to access data to draw the current element
            Color current = colors[index];

            EditorGUILayout.BeginVertical(GUILayout.Width(itemWidth));
            EditorGUILayout.TextField("Test");

            EditorGUILayout.ColorField(GUIContent.none, current, false, false, false, null, GUILayout.Width(itemWidth), GUILayout.Height(itemWidth));

            GUILayout.Button("Button 1", GUILayout.Width(itemWidth));

            EditorGUILayout.EndVertical();
        });
        
        //once the draw function is set up, draw it! (this is actually what draws it)
        scrollPosition = EditorGridDisplay.Draw(scrollPosition, 8);

        EditorGUILayout.TextField("You can draw fields after and before it!");
    }
}