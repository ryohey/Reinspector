using System;
using System.Linq;
using UnityEngine;

namespace Reinspector.Serializable
{
    public class ComponentReference<T> where T: Component
    {
        public int gameObjectInstanceID;

        public ComponentReference() { }

        public ComponentReference(T component)
        {
            gameObjectInstanceID = component.gameObject.GetInstanceID();
        }

        public void Restore(RestorePostProcess postProcess, Action<T> callback)
        {
            postProcess.Register(root =>
            {
                var referenceObject = root.GetComponentsInChildren<Identifier>().FirstOrDefault(id => id.gameObjectInstanceID == gameObjectInstanceID);
                if (referenceObject != null)
                {
                    callback(referenceObject.GetComponent<T>());
                }
                else
                {
                    Debug.LogWarning($"Reference Not Found: {typeof(T).FullName} ({gameObjectInstanceID})");
                }
            });
        }
    }
}
