using B83.MeshTools;
using UnityEngine;

namespace Reinspector.Serializable
{
    public class MeshSerializable : UnityObjectSerializable
    {
        public byte[] data;

        public MeshSerializable(): base() { }

        public MeshSerializable(Mesh mesh) : base(mesh)
        {
            data = MeshSerializer.SerializeMesh(mesh);
        }

        public Mesh Instantiate()
        {
            var mesh = MeshSerializer.DeserializeMesh(data);
            return mesh;
        }
    }
}
