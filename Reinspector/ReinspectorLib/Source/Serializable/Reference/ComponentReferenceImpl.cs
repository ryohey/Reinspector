using UnityEngine;

namespace Reinspector.Serializable
{
    public class TransformReference: ComponentReference<Transform>
    {
        public TransformReference() : base() { }
        public TransformReference(Transform obj) : base(obj) { }
    }

    public class CameraReference: ComponentReference<Camera> 
    {
        public CameraReference() : base() { }
        public CameraReference(Camera obj): base(obj) { }
    }
}
