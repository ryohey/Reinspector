using System;
using System.Collections.Generic;
using BepInEx;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ExamplePlugin
{
    [BepInPlugin("org.bepinex.plugins.exampleplugin", "Example Plug-In", "1.0.0.0")]
    public class ExamplePlugin : BaseUnityPlugin
    {
        void Awake()
        {
            Logger.LogInfo("Awake()");

            try
            {
                DontDestroyOnLoad(this);
                SceneManager.sceneLoaded += OnSceneLoaded; ;
            }
            catch (Exception e)
            {
                Debug.LogError(e.ToString());
            }
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            Logger.LogInfo("OnSceneLoaded");
            ScanScene();
        }

        void Start()
        {
            Logger.LogInfo("Start()");
        }

        private void ScanScene()
        {
            Logger.LogInfo("Start scanning the scene");
            var rootObjects = new List<GameObject>();
            var scene = SceneManager.GetActiveScene();
            scene.GetRootGameObjects(rootObjects);

            foreach (var obj in rootObjects)
            {
                obj.transform.Traverse(t =>
                {
                    Logger.LogInfo(t.gameObject.name);
                });
            }
        }
    }

    public static class TransformExtensions
    {
        public static void Traverse(this Transform transform, Action<Transform> callback)
        {
            callback(transform);

            for (var i = 0; i < transform.childCount; i++)
            {
                var t = transform.GetChild(i);
                t.Traverse(callback);
            }
        }
    }
}
