using Reinspector.Serializable;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Reinspector
{
    public static class SceneSerializer
    {
        private static Serializer serializer = new Serializer();

        public static byte[] Serialize(Scene scene)
        {
            var ser = new SceneSerializable(scene);
            return serializer.Serialize(ser);
        }

        public static void DeserializeGameObjects(byte[] data, Transform parent)
        {
            var restored = serializer.Deserialize<SceneSerializable>(data);
            var postProcess = new RestorePostProcess();
            restored.InstantiateRootGameObjects(parent, postProcess);
            postProcess.Run(parent.gameObject);
        }
    }
}
