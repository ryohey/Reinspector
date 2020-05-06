using System;
using UnityEngine;

namespace Reinspector.Serializable
{
    [Serializable]
    public class CameraSerializable : ComponentSerializable
    {
        public CameraClearFlags clearFlags;
        public Color backgroundColor;
        public int eventMask;
        public bool layerCullSpherical;
        public CameraType cameraType;
        public bool useOcclusionCulling;
        public int cullingMask;
        public Matrix4x4 projectionMatrix;
        public float fieldOfView;
        public DepthTextureMode depthTextureMode;
        public Rect rect;
        public int targetDisplay;
        public float nearClipPlane;
        public float farClipPlane;
        public float depth;

        public CameraSerializable(): base() { }

        public CameraSerializable(Camera obj) : base(obj)
        {
            clearFlags = obj.clearFlags;
            backgroundColor = obj.backgroundColor;
            cullingMask = obj.cullingMask;
            eventMask = obj.eventMask;
            layerCullSpherical = obj.layerCullSpherical;
            cameraType = obj.cameraType;
            useOcclusionCulling = obj.useOcclusionCulling;
            projectionMatrix = obj.projectionMatrix;
            fieldOfView = obj.fieldOfView;
            depthTextureMode = obj.depthTextureMode;
            targetDisplay = obj.targetDisplay;
            rect = obj.rect;
            nearClipPlane = obj.nearClipPlane;
            farClipPlane = obj.farClipPlane;
            depth = obj.depth;
        }

        public override void Restore(Component component, RestorePostProcess post)
        {
            base.Restore(component, post);

            var camera = component as Camera;

            camera.clearFlags = clearFlags;
            camera.backgroundColor = backgroundColor;
            camera.cullingMask = cullingMask;
            camera.eventMask = eventMask;
            camera.layerCullSpherical = layerCullSpherical;
            camera.cameraType = cameraType;
            camera.useOcclusionCulling = useOcclusionCulling;
            camera.projectionMatrix = projectionMatrix;
            camera.fieldOfView = fieldOfView;
            camera.depthTextureMode = depthTextureMode;
            camera.targetDisplay = targetDisplay;
            camera.rect = rect;
            camera.nearClipPlane = nearClipPlane;
            camera.farClipPlane = farClipPlane;
            camera.depth = depth;
        }
    }
}
