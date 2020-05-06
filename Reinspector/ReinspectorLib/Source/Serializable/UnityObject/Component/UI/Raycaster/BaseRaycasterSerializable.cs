using UnityEngine;
using UnityEngine.EventSystems;

namespace Reinspector.Serializable.UI
{
    public class BaseRaycasterSerializable : UIBehaviourSerializable
    {
        public BaseRaycasterSerializable() : base() { }

        public BaseRaycasterSerializable(BaseRaycaster raycaster) : base(raycaster)
        {

        }

        public override void Restore(Component component, RestorePostProcess post)
        {
            base.Restore(component, post);
        }
    }
}
