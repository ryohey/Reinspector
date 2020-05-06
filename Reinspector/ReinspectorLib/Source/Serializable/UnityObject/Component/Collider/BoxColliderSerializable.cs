using UnityEngine;

namespace Reinspector.Serializable
{
    public class BoxColliderSerializable: ColliderSerializable
    {
        public Vector3 center;
        public Vector3 size;

        public BoxColliderSerializable() : base() { }

        public BoxColliderSerializable(BoxCollider collider): base(collider)
        {
            center = collider.center;
            size = collider.size;
        }
    }
}
