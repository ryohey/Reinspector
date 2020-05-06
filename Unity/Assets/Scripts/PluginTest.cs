using Reinspector;
using Reinspector.Message;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PluginTest : MonoBehaviour
{
    HttpMessageServer server;
    HttpMessageClient client;

    void Start()
    {
        server = new HttpMessageServer("http://localhost:3141/");
        client = new HttpMessageClient("http://localhost:3141/");

        server.Subscribe<RequestSaveAllScenes>(req =>
        {
            Debug.Log($"Server Received: {req.GetType().FullName}");
        });

        client.Subscribe<RequestSaveAllScenes>(req =>
        {
            Debug.Log($"Client Received: {req.GetType().FullName}");
        });
        server.SubscribeAny(req =>
        {
            Debug.Log($"Server Received Any: {req.GetType().FullName}");
        });

        client.SubscribeAny(req =>
        {
            Debug.Log($"Client Received Any: {req.GetType().FullName}");
        });
    }

    public void CheckEvents()
    {
        client.CheckEvents();
    }

    public void SendFromServer()
    {
        server.Post(new RequestSaveAllScenes());
    }

    public void SendFromClient()
    {
        client.Post(new RequestSaveAllScenes());
    }

    void Serialize()
    {
        var scene = SceneManager.GetActiveScene();
        var data = SceneSerializer.Serialize(scene);
        SceneSerializer.DeserializeGameObjects(data, transform);
    }
}
