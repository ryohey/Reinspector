#if UNITY_EDITOR

using Reinspector;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Inspector
{
    class LoadSceneFromFile
    {
        [MenuItem("Reinspector/Open File")]
        public static void OpenFile()
        {
            var path = EditorUtility.OpenFilePanel("Open a serialized scene file", "", "bin");
            if (path.Length != 0)
            {
                var data = File.ReadAllBytes(path);
                var parent = new GameObject(Path.GetFileName(path));
                SceneSerializer.DeserializeGameObjects(data, parent.transform);
            }
        }
    }
}

#endif
