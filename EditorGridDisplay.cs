using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System;

public class EditorGridDisplay
{
    private static int minItemWidth = 100;
    private static Rect currentRect;
    private static Rect currentRectMargin;
    private static int counter = 0;
    private static Action<int> drawAction = null;
    private static int UNITY_DEFAULT_MARGIN = 4;
    private static int UNITY_SCROLLBAR_WIDTH = 15;
    private static int UNITY_SCROLLBAR_WIDTH_HALF = 8;

    public static void Begin(Rect gridArea, int itemWidth)
    {
        currentRect = gridArea;
        minItemWidth = itemWidth;
        EditorGUILayout.BeginVertical(GUILayout.Width(gridArea.width), GUILayout.Height(gridArea.height));
    }

    public static void SetDrawAction(Action<int> draw)
    {
        drawAction = draw;
    }

    public static float Draw(float scrollPos, int count)
    {
        if(drawAction == null)
        {
            throw new ArgumentNullException("Draw Action was null. Call SetDrawAction before calling Draw.");
        }

        //the rectangle passed in is without including the margins of the scrollbar
        currentRectMargin = currentRect;
        currentRectMargin.width -= UNITY_SCROLLBAR_WIDTH_HALF;

        scrollPos = EditorGUILayout.BeginScrollView(new Vector2(0.0f, scrollPos), GUIStyle.none, GUI.skin.verticalScrollbar, GUILayout.Width(currentRect.width), GUILayout.Height(currentRect.height)).y;
        //calculate the width minus the editor margins + scrollbar

        int numHorz = Mathf.FloorToInt((currentRect.width - UNITY_SCROLLBAR_WIDTH - UNITY_DEFAULT_MARGIN) / (minItemWidth + UNITY_DEFAULT_MARGIN));
        float maxVertf = (float)count / (float)numHorz;
        int maxVert = Mathf.CeilToInt(maxVertf);

        for (int y = 0; y < maxVert; y++)
        {
            EditorGUILayout.BeginVertical(GUILayout.Width(currentRectMargin.width));
            EditorGUILayout.BeginHorizontal(GUILayout.Width(currentRectMargin.width));

            for (int x = 0; x < numHorz; x++)
            {
                int counter = numHorz * y + x;
                
                if (counter >= count)
                {
                    break;
                }

                drawAction(counter);
            }

            EditorGUILayout.EndHorizontal();
            EditorGUILayout.EndVertical();
        }

        EditorGUILayout.EndScrollView();
        return scrollPos;
    }
}
