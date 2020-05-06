using UnityEngine;

namespace Reinspector.Serializable
{
    public class TransformSerializable : ComponentSerializable
    {
        public Vector3 localPosition;
        public Quaternion localRotation;
        public Vector3 localScale;

        public TransformSerializable(): base() { }

        public TransformSerializable(Transform transform): base(transform)
        {
            localPosition = transform.localPosition;
            localRotation = transform.localRotation;
            localScale = transform.localScale;
        }

        public override void Restore(Component component, RestorePostProcess post)
        {
            base.Restore(component, post);
            var t = component as Transform;
            t.localPosition = localPosition;
            t.localRotation = localRotation;
            t.localScale = localScale;
        }
    }
}
