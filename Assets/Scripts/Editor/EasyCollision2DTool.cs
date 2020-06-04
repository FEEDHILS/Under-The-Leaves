using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EasyCollision2D))]
public class EasyCollision2DTool : Editor
{
    Vector2 point;
    int iter = 0;
    bool CanMove = false;

    EasyCollision2D col; // Reference to current EasyCollision2D Object.
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        col = (EasyCollision2D)target;
        
        GUILayout.BeginHorizontal();
        if(GUILayout.Button("Activate"))
        {
            col.ResetList();
            col.PointsCountUpdate();
            iter = 0;
            CanMove = true;
            Debug.Log("Tool Is Active");
        }

        if(GUILayout.Button("Stop Edit"))
        {
            StopEdit();
            Debug.Log("Points are placed");
        }

        if(GUILayout.Button("Reset"))
        {
            col.ResetList();
            iter = 0;
            StopEdit();
            Debug.Log("Tool Is Reset");
        }

        GUILayout.EndHorizontal();

        if(GUILayout.Button("Create Collider"))
        {
            col.CreateCollider();
            col.ResetList();
            iter = 0;
            StopEdit();
            Debug.Log("Work Done!");
        }
    }

    void MousePositionUpdate()
    {
        Vector2 mousePosition = Event.current.mousePosition;
        mousePosition.y = -mousePosition.y + SceneView.currentDrawingSceneView.camera.pixelHeight;
        Vector2 newMousePos = SceneView.currentDrawingSceneView.camera.ScreenToWorldPoint(mousePosition);

        point = newMousePos;
    }

    void OnSceneGUI()
    {
        MousePositionUpdate();
        PointManipulation();
    }

    void PointManipulation()
    {
        if(CanMove)
        {
            col.pos= point;
        }
            
        if(Event.current.button == 1 && Event.current.isMouse && CanMove)
        {
            if(iter % 2 != 0)
                col.CreatePoint();
            
            iter++;
            if(iter == col.PointsCount * 2)
            {
                StopEdit();
                Debug.Log("Points are placed");
            }
        }
    }

    void StopEdit()
    {
        CanMove = false;
    }
}
