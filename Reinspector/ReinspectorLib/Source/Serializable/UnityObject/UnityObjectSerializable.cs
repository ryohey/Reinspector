using UnityEngine;

namespace Reinspector.Serializable
{
    public class UnityObjectSerializable: ObjectSerializable
    {
        public int instanceID;
        public string name;
        public HideFlags hideFlags;

        public UnityObjectSerializable(): base() { }

        public UnityObjectSerializable(Object obj): base(obj)
        {
            instanceID = obj.GetInstanceID();
            name = obj.name;
            hideFlags = obj.hideFlags;
        }

        public virtual void Restore(Object obj, RestorePostProcess post)
        {
            obj.name = name;
            obj.hideFlags = hideFlags;
        }

        public override System.Type GetOriginalType()
        {
            return System.Type.GetType($"{__type}, UnityEngine");
        }
    }
}
