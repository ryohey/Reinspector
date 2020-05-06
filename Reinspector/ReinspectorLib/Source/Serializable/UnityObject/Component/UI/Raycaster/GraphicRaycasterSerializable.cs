using UnityEngine;
using UnityEngine.UI;

namespace Reinspector.Serializable.UI
{
    public class GraphicRaycasterSerializable : BaseRaycasterSerializable
    {
        public GraphicRaycaster.BlockingObjects blockingObjects;

        public GraphicRaycasterSerializable() : base() { }

        public GraphicRaycasterSerializable(GraphicRaycaster raycaster) : base(raycaster)
        {
            blockingObjects = raycaster.blockingObjects;
        }

        public override void Restore(Component component, RestorePostProcess post)
        {
            base.Restore(component, post);

            var raycaster = component as GraphicRaycaster;

            raycaster.blockingObjects = blockingObjects;
        }
    }
}
