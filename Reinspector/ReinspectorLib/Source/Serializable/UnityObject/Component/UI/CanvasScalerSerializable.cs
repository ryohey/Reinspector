using UnityEngine;
using UnityEngine.UI;

namespace Reinspector.Serializable.UI
{
    public class CanvasScalerSerializable : UIBehaviourSerializable
    {
        public CanvasScaler.ScaleMode uiScaleMode;
        public Vector2 referenceResolution;
        public CanvasScaler.ScreenMatchMode screenMatchMode;
        public float matchWidthOrHeight;
        public float defaultSpriteDPI;
        public float fallbackScreenDPI;
        public float referencePixelsPerUnit;
        public float dynamicPixelsPerUnit;
        public CanvasScaler.Unit physicalUnit;
        public float scaleFactor;

        public CanvasScalerSerializable() : base() { }

        public CanvasScalerSerializable(CanvasScaler scaler) : base(scaler)
        {
            uiScaleMode = scaler.uiScaleMode;
            referenceResolution = scaler.referenceResolution;
            screenMatchMode = scaler.screenMatchMode;
            matchWidthOrHeight = scaler.matchWidthOrHeight;
            defaultSpriteDPI = scaler.defaultSpriteDPI;
            fallbackScreenDPI = scaler.fallbackScreenDPI;
            referencePixelsPerUnit = scaler.referencePixelsPerUnit;
            dynamicPixelsPerUnit = scaler.dynamicPixelsPerUnit;
            physicalUnit = scaler.physicalUnit;
            scaleFactor = scaler.scaleFactor;
        }

        public override void Restore(Component component, RestorePostProcess post)
        {
            base.Restore(component, post);

            var scaler = component as CanvasScaler;

            scaler.uiScaleMode = uiScaleMode;
            scaler.referenceResolution = referenceResolution;
            scaler.screenMatchMode = screenMatchMode;
            scaler.matchWidthOrHeight = matchWidthOrHeight;
            scaler.defaultSpriteDPI = defaultSpriteDPI;
            scaler.fallbackScreenDPI = fallbackScreenDPI;
            scaler.referencePixelsPerUnit = referencePixelsPerUnit;
            scaler.dynamicPixelsPerUnit = dynamicPixelsPerUnit;
            scaler.physicalUnit = physicalUnit;
            scaler.scaleFactor = scaleFactor;
        }
    }
}
