using UnityEngine;

namespace Reinspector.Serializable
{
    public class CanvasSerializable : ComponentSerializable
    {
        public string sortingLayerName;
        public AdditionalCanvasShaderChannels additionalShaderChannels;
        public int sortingLayerID;
        public int targetDisplay;
        public int sortingOrder;
        public bool overrideSorting;
        public float planeDistance;
        public bool overridePixelPerfect;
        public float referencePixelsPerUnit;
        public float scaleFactor;
        public CameraReference worldCamera;
        public RenderMode renderMode;
        public bool pixelPerfect;

        public CanvasSerializable(): base() { }

        public CanvasSerializable(Canvas canvas): base(canvas)
        {
            sortingLayerName = canvas.sortingLayerName;
            additionalShaderChannels = canvas.additionalShaderChannels;
            sortingLayerID = canvas.sortingLayerID;
            targetDisplay = canvas.targetDisplay;
            sortingOrder = canvas.sortingOrder;
            overrideSorting = canvas.overrideSorting;
            planeDistance = canvas.planeDistance;
            overridePixelPerfect = canvas.overridePixelPerfect;
            referencePixelsPerUnit = canvas.referencePixelsPerUnit;
            scaleFactor = canvas.scaleFactor;
            worldCamera = canvas.worldCamera != null ? new CameraReference(canvas.worldCamera) : null;
            renderMode = canvas.renderMode;
            pixelPerfect = canvas.pixelPerfect;
        }

        public override void Restore(Component component, RestorePostProcess post)
        {
            base.Restore(component, post);

            var canvas = component as Canvas;
            canvas.sortingLayerName = sortingLayerName;
            canvas.additionalShaderChannels = additionalShaderChannels;
            canvas.sortingLayerID = sortingLayerID;
            canvas.targetDisplay = targetDisplay;
            canvas.sortingOrder = sortingOrder;
            canvas.overrideSorting = overrideSorting;
            canvas.planeDistance = planeDistance;
            canvas.overridePixelPerfect = overridePixelPerfect;
            canvas.referencePixelsPerUnit = referencePixelsPerUnit;
            canvas.scaleFactor = scaleFactor;
            worldCamera?.Restore(post, camera => canvas.worldCamera = camera);
            canvas.renderMode = renderMode;
            canvas.pixelPerfect = pixelPerfect;
        }
    }
}
