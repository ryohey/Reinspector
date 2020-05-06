using UnityEngine;

namespace Reinspector.Serializable
{
    public class PhysicMaterialSerializable: UnityObjectSerializable
    {
        public float bounciness;
        public float dynamicFriction;
        public float staticFriction;
        public PhysicMaterialCombine frictionCombine;
        public PhysicMaterialCombine bounceCombine;

        public PhysicMaterialSerializable(): base() { }

        public PhysicMaterialSerializable(PhysicMaterial material): base(material)
        {
            bounciness = material.bounciness;
            dynamicFriction = material.dynamicFriction;
            staticFriction = material.staticFriction;
            frictionCombine = material.frictionCombine;
            bounceCombine = material.bounceCombine;
        }
    }
}
