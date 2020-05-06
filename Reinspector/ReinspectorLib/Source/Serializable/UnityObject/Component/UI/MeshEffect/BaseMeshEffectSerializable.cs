using UnityEngine;
using UnityEngine.UI;

namespace Reinspector.Serializable.UI
{
    public class BaseMeshEffectSerializable: UIBehaviourSerializable
    {
        public BaseMeshEffectSerializable() : base() { }

        public BaseMeshEffectSerializable(BaseMeshEffect effect) : base(effect)
        {
        }

        public override void Restore(Component component, RestorePostProcess post)
        {
            base.Restore(component, post);
        }
    }
}
