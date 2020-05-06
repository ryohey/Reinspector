using UnityEngine;
using UnityEngine.UI;

namespace Reinspector.Serializable.UI
{
    public class OutlineSerializable : ShadowSerializable
    {
        public OutlineSerializable() : base() { }

        public OutlineSerializable(Outline raycaster) : base(raycaster)
        {
        }

        public override void Restore(Component component, RestorePostProcess post)
        {
            base.Restore(component, post);
        }
    }
}
