#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PluginTest))]
public class PluginTestEditor: Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var obj = (PluginTest)target;

        if (GUILayout.Button("SendFromServer"))
        {
            obj.SendFromServer();
        }

        if (GUILayout.Button("SendFromClient"))
        {
            obj.SendFromClient();
        }

        if (GUILayout.Button("CheckEvents"))
        {
            obj.CheckEvents();
        }
    }
}

#endif
