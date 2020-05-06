using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ReinspectorPlugin
{
    public static class SceneUtil
    {
        public static List<Scene> GetAllScenes(bool includeDontDestroyOnLoad = false)
        {
            var scenes = new List<Scene>();

            for (var i = 0; i < SceneManager.sceneCount; i++)
            {
                scenes.Add(SceneManager.GetSceneAt(i));
            }

            if (includeDontDestroyOnLoad)
            {
                var scene = GetDontDestroyOnLoadScene();
                if (scene != null)
                {
                    scenes.Add(scene);
                }
            }

            return scenes;
        }

        static Scene GetDontDestroyOnLoadScene()
        {
            GameObject temp = null;
            try
            {
                temp = new GameObject();
                Object.DontDestroyOnLoad(temp);
                var dontDestroyOnLoad = temp.scene;
                Object.DestroyImmediate(temp);
                temp = null;

                return dontDestroyOnLoad;
            }
            finally
            {
                if (temp != null)
                {
                    Object.DestroyImmediate(temp);
                }
            }
        }
    }
}
