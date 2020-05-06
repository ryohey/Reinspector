using UnityEngine;

namespace Reinspector.Serializable
{
    public class CanvasRendererSerializable : ComponentSerializable
    {
        public bool cull;
        public int popMaterialCount;
        public int materialCount;
        public bool hasPopInstruction;

        public CanvasRendererSerializable() : base() { }

        public CanvasRendererSerializable(CanvasRenderer renderer) : base (renderer)
        {
            cull = renderer.cull;
            popMaterialCount = renderer.popMaterialCount;
            materialCount = renderer.materialCount;
            hasPopInstruction = renderer.hasPopInstruction;
        }

        public override void Restore(Component component, RestorePostProcess post)
        {
            base.Restore(component, post);

            var renderer = component as CanvasRenderer;

            renderer.cull = cull;
            renderer.popMaterialCount = popMaterialCount;
            renderer.materialCount = materialCount;
            renderer.hasPopInstruction = hasPopInstruction;
        }
    }
}
