using UnityEngine;

namespace Reinspector.Serializable
{
    public class ColliderSerializable : ComponentSerializable
    {
        public bool enabled;
        public bool isTrigger;
        public float contactOffset;
        public PhysicMaterialSerializable material;

        public ColliderSerializable(): base() {}

        public ColliderSerializable(Collider collider): base(collider)
        {
            enabled = collider.enabled;
            isTrigger = collider.isTrigger;
            contactOffset = collider.contactOffset;
            material = collider.material != null ? new PhysicMaterialSerializable(collider.material) : null;
        }
    }
}
