using UnityEngine;
using UnityEngine.EventSystems;

namespace Reinspector.Serializable.UI
{
    public class UIBehaviourSerializable: ComponentSerializable
    {
        public UIBehaviourSerializable() : base() { }

        public UIBehaviourSerializable(UIBehaviour behaviour) : base(behaviour)
        {

        }

        public override void Restore(Component component, RestorePostProcess post)
        {
            base.Restore(component, post);
        }

        public override System.Type GetOriginalType()
        {
            return System.Type.GetType($"{__type}, UnityEngine.UI");
        }
    }
}
