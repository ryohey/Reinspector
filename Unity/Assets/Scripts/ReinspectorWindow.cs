#if UNITY_EDITOR

using Reinspector;
using Reinspector.Message;
using UnityEditor;
using UnityEngine;

class ReinspectorWindow : EditorWindow
{
    HttpMessageServer server = new HttpMessageServer("http://localhost:3141/");

    [MenuItem("Reinspector/Server")]
    public static void ShowWindow()
    {
        GetWindow(typeof(ReinspectorWindow));
    }

    void OnGUI()
    {
        if (server == null)
        {
            return;
        }

        GUILayout.Label(server.IsConnected ? "Connected" : "Disconnected");

        if (!server.IsConnected)
        {
            return;
        }

        if (GUILayout.Button("Save all scenes to file"))
        {
            server.Post(new RequestSaveAllScenes());
        }
    }
}

#endif
