using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GridManager))]
public class GridEditor : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        GridManager grid = (GridManager)target;
        
        if (GUILayout.Button("Generate Grid")) {
            grid.GenerateGrid();
        }
    }
}
