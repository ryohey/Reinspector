using System.Linq;
using UnityEngine;

namespace Reinspector.Serializable
{
    public class GameObjectSerializable : UnityObjectSerializable
    {
        public int layer;
        public bool isStatic;
        public bool active;
        public ComponentUnion[] components = new ComponentUnion[] { };
        public GameObjectSerializable[] transformChildren = new GameObjectSerializable[] { };

        public GameObjectSerializable(): base() { }

        public GameObjectSerializable(GameObject gameObject): base(gameObject)
        {
            layer = gameObject.layer;
            isStatic = gameObject.isStatic;
            active = gameObject.activeSelf;

            components = gameObject.GetComponents<Component>()
                .Select(c => new ComponentUnion(c))
                .ToArray();

            transformChildren = gameObject.transform
                .GetAllChildren()
                .Select(t => new GameObjectSerializable(t.gameObject))
                .ToArray();
        }

        public GameObject Instantiate(RestorePostProcess postProcess)
        {

            var obj = new GameObject(name)
            {
                isStatic = isStatic
            };

            // 参照を復元するために元の InstanceID を保持させる
            var id = obj.AddComponent<Identifier>();
            id.gameObjectInstanceID = instanceID;

            obj.SetActive(active);

            foreach (var componentUnion in components)
            {
                var c = componentUnion.Value;
                var t = c.GetOriginalType();
                if (t != null)
                {
                    Component component;
                    if (t == typeof(Transform))
                    {
                        component = obj.transform;
                    }
                    else
                    {
                        component = obj.AddComponent(t);
                        if (component == null)
                        {
                            var debug = obj.AddComponent<DebugComponent>();
                            debug.componentType = t.FullName;
                        }
                    }

                    if (component != null)
                    {
                        c.Restore(component, postProcess);
                    }
                }
                else
                {
                    Debug.LogWarning($"Could not instantiate type for {c.GetType().FullName}");
                }
            }

            foreach (var c in transformChildren)
            {
                var child = c.Instantiate(postProcess);
                child.transform.SetParent(obj.transform, false);
            }

            return obj;
        }
    }
}
