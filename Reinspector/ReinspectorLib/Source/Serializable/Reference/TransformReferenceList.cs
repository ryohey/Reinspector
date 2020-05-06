using System;
using System.Linq;
using UnityEngine;

namespace Reinspector.Serializable
{
    public class TransformReferenceList
    {
        public int[] gameObjectInstanceIDs;

        public TransformReferenceList() { }

        public TransformReferenceList(Transform[] transforms)
        {
            gameObjectInstanceIDs = transforms.Select(t => t.gameObject.GetInstanceID()).ToArray();
        }

        public void Restore(RestorePostProcess postProcess, Action<Transform[]> callback)
        {
            postProcess.Register(root =>
            {
                var identifiers = root.GetComponentsInChildren<Identifier>();
                var transforms = gameObjectInstanceIDs
                    .Select(gameObjectInstanceID => identifiers.FirstOrDefault(id => id.gameObjectInstanceID == gameObjectInstanceID))
                    .Select(obj => obj.transform)
                    .ToArray();
                callback(transforms);
            });
        }
    }
}
