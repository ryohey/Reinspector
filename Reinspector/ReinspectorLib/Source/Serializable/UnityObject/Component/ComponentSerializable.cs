using System;
using UnityEngine;

namespace Reinspector.Serializable
{
    [Serializable]
    public class ComponentSerializable : UnityObjectSerializable
    {
        public string tag;

        public ComponentSerializable() : base() { }

        public ComponentSerializable(Component obj): base(obj)
        {
            tag = obj.tag;
        }

        public virtual void Restore(Component component, RestorePostProcess post)
        {
            base.Restore(component, post);
            component.tag = tag;
        }
    }
}

