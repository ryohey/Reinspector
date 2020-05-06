using System;
using System.IO;
using BepInEx;
using Reinspector;
using Reinspector.Message;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ReinspectorPlugin
{
    [BepInPlugin("jp.codingcafe.reinspector", "Reinspector", "0.0.1")]
    public class ReinspectorPlugin : BaseUnityPlugin
    {
        private readonly IMessageBroker messageBroker = new HttpMessageClient("http://localhost:3141/");

        void Awake()
        {
            var dllLoader = new DllLoader();
            var dllFolder = Path.GetDirectoryName(new Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).LocalPath);
            Debug.Log(dllFolder);
            dllLoader.LoadDll(Path.Combine(dllFolder, "ReinspectorLib.dll"));
            ObserveMessages();
        }

        void ObserveMessages()
        {
            messageBroker.Subscribe<RequestSaveAllScenes>(_ => SaveAllScenes());
        }

        void SaveAllScenes()
        {
            SceneUtil.GetAllScenes(true).ForEach(SaveSceneToFile);
        }

        void SaveSceneToFile(Scene scene)
        {
            var data = SceneSerializer.Serialize(scene);
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var now = DateTime.Now.ToString("yyyy-M-dd-HH-mm-ss");
            var savePath = Path.Combine(path, $"[{Application.productName}] {scene.name} {now}.bin");

            File.WriteAllBytes(savePath, data);
            Logger.LogInfo($"The dumped scene file are written to {savePath}");
        }

    }
}
