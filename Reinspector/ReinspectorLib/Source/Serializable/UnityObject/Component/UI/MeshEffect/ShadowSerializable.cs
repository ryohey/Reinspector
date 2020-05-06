using UnityEngine;
using UnityEngine.UI;

namespace Reinspector.Serializable.UI
{
    public class ShadowSerializable : BaseMeshEffectSerializable
    {
        public Color effectColor;
        public Vector2 effectDistance;
        public bool useGraphicAlpha;

        public ShadowSerializable() : base() { }

        public ShadowSerializable(Shadow shadow) : base(shadow)
        {
            effectColor = shadow.effectColor;
            effectDistance = shadow.effectDistance;
            useGraphicAlpha = shadow.useGraphicAlpha;
        }

        public override void Restore(Component component, RestorePostProcess post)
        {
            base.Restore(component, post);

            var shadow = component as Shadow;

            shadow.effectColor = effectColor;
            shadow.effectDistance = effectDistance;
            shadow.useGraphicAlpha = useGraphicAlpha;
        }
    }
}
