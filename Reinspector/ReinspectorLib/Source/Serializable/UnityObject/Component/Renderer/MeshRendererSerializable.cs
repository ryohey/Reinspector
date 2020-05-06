using UnityEngine;

namespace Reinspector.Serializable
{ 
    public class MeshRendererSerializable: RendererSerializable
    {
        public MeshSerializable additionalVertexStreams;

        public MeshRendererSerializable() : base() { }

        public MeshRendererSerializable(MeshRenderer renderer) : base(renderer)
        {
            additionalVertexStreams = renderer.additionalVertexStreams != null ? new MeshSerializable(renderer.additionalVertexStreams) : null;
        }

        public override void Restore(Component component, RestorePostProcess post)
        {
            base.Restore(component, post);

            var renderer = component as MeshRenderer;
            renderer.additionalVertexStreams = additionalVertexStreams?.Instantiate();
        }
    }
}
