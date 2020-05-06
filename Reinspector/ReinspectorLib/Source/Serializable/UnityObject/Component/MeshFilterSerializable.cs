using UnityEngine;

namespace Reinspector.Serializable
{ 
    public class MeshFilterSerializable: ComponentSerializable
    {
        public MeshSerializable mesh;

        public MeshFilterSerializable(): base() { }

        public MeshFilterSerializable(MeshFilter meshFilter): base(meshFilter)
        {
            mesh = meshFilter.mesh != null ? new MeshSerializable(meshFilter.mesh) : null;
        }

        public override void Restore(Component component, RestorePostProcess post)
        {
            base.Restore(component, post);
            var meshFilter = component as MeshFilter;
            meshFilter.mesh = mesh?.Instantiate();
        }
    }
}
