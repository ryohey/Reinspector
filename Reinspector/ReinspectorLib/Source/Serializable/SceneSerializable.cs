using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace Reinspector.Serializable
{
    public class SceneSerializable: ObjectSerializable
    {
        public string path;
        public string name;
        public bool isLoaded;
        public int buildIndex;
        public bool isDirty;
        public int rootCount;
        public GameObjectSerializable[] rootGameObjects;

        public SceneSerializable() : base() { }

        public SceneSerializable(Scene scene): base(scene)
        {
            path = scene.path;
            name = scene.name;
            isLoaded = scene.isLoaded;
            buildIndex = scene.buildIndex;
            isDirty = scene.isDirty;
            rootCount = scene.rootCount;
            rootGameObjects = scene.GetRootGameObjects().Select(obj => new GameObjectSerializable(obj)).ToArray();
        }

        public void InstantiateRootGameObjects(Transform parent, RestorePostProcess postProcess)
        {
            foreach (var ser in rootGameObjects)
            {
                var obj = ser.Instantiate(postProcess);
                obj.transform.SetParent(parent, false);
            }
        }
    }
}
