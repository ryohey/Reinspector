using UnityEngine;
using UnityEngine.UI;

namespace Reinspector.Serializable.UI
{
    public class MaskableGraphicSerializable : GraphicSerializable
    {
        public bool maskable;

        public MaskableGraphicSerializable() : base() { }

        public MaskableGraphicSerializable(MaskableGraphic graphic) : base(graphic)
        {
            maskable = graphic.maskable;
        }

        public override void Restore(Component component, RestorePostProcess post)
        {
            base.Restore(component, post);

            var graphic = component as MaskableGraphic;

            graphic.maskable = maskable;
        }
    }
}
