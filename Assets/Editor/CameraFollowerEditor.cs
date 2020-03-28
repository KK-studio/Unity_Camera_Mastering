using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CameraFollower))]
public class CameraFollowerEditor : Editor
{
    
    [DrawGizmo(GizmoType.Selected)]
    static void DrawGizmosSelected(CameraFollower follower, GizmoType gizmoType)
    {

        if (follower.showGizmos)
        {
            Vector3 target = follower.target.position;
            Vector3 cur = follower.transform.position;
            Handles.DrawDottedLine(cur, target, 3);
            Gizmos.DrawWireSphere(target, 0.125f);
            float distance = (target - cur).magnitude;
            Handles.Label((cur - target) / 2, "distance : " + distance);
        }
    }
    
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EditorGUILayout.HelpBox("camera will follow target", MessageType.Info);
        
        if (GUILayout.Button("set offset"))
        {
            CameraFollower cameraFollower = (CameraFollower) target;
            cameraFollower.offset = cameraFollower.transform.position - cameraFollower.target.position;
        }
    }
    


    
}
