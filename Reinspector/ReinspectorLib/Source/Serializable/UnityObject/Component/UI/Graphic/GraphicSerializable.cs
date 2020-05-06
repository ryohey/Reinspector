using UnityEngine;
using UnityEngine.UI;

namespace Reinspector.Serializable.UI
{
    public class GraphicSerializable : UIBehaviourSerializable
    {
        public bool raycastTarget;
        public MaterialSerializable material;
        public Color color;

        public GraphicSerializable() : base() { }

        public GraphicSerializable(Graphic graphic) : base(graphic)
        {
            raycastTarget = graphic.raycastTarget;
            material = graphic.material != null ? new MaterialSerializable(graphic.material) : null;
            color = graphic.color;
        }

        public override void Restore(Component component, RestorePostProcess post)
        {
            base.Restore(component, post);

            var graphic = component as Graphic;

            graphic.raycastTarget = raycastTarget;
            graphic.material = material?.Instantiate();
            graphic.color = color;
        }
    }
}
