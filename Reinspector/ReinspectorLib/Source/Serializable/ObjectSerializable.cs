using System;

namespace Reinspector.Serializable
{
    [Serializable]
    public class ObjectSerializable
    {
        public string __type;

        public ObjectSerializable() { }

        public ObjectSerializable(object obj)
        {
            __type = obj.GetType().FullName;
        }

        public virtual Type GetOriginalType()
        {
            return Type.GetType(__type);
        }
    }
}
