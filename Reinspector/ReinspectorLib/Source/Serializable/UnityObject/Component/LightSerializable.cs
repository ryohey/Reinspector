using UnityEngine;
using UnityEngine.Rendering;

namespace Reinspector.Serializable
{
    public class LightSerializable : ComponentSerializable
    {
        public LightType type;

        public float range;
        public float spotAngle;

        public Color color;

        public float intensity;
        public float bounceIntensity;

        public LightShadows shadows;
        public float shadowStrength;
        public LightShadowResolution shadowResolution;
        public float shadowBias;
        public float shadowNormalBias;
        public float shadowNearPlane;

        public TextureUnion cookie;
        public float cookieSize;
        public LightRenderMode renderMode;
        public int cullingMask;

        public LightSerializable() : base() { }

        public LightSerializable(Light obj) : base(obj)
        {
            type = obj.type;
            range = obj.range;
            spotAngle = obj.spotAngle;

            color = obj.color;
            intensity = obj.intensity;
            bounceIntensity = obj.bounceIntensity;

            shadows = obj.shadows;
            shadowStrength = obj.shadowStrength;
            shadowResolution = obj.shadowResolution;
            shadowBias = obj.shadowBias;
            shadowNormalBias = obj.shadowNormalBias;
            shadowNearPlane = obj.shadowNearPlane;

            cookie = obj.cookie != null ? new TextureUnion(obj.cookie) : null;
            cookieSize = obj.cookieSize;
            renderMode = obj.renderMode;
            cullingMask = obj.cullingMask;
        }

        public override void Restore(Component component, RestorePostProcess post)
        {
            base.Restore(component, post);

            var light = component as Light;
            light.type = type;
            light.range = range;
            light.spotAngle = spotAngle;

            light.color = color;
            light.intensity = intensity;
            light.bounceIntensity = bounceIntensity;

            light.shadows = shadows;
            light.shadowStrength = shadowStrength;
            light.shadowResolution = shadowResolution;
            light.shadowBias = shadowBias;
            light.shadowNormalBias = shadowNormalBias;
            light.shadowNearPlane = shadowNearPlane;

            light.cookie = cookie?.Value.Instantiate();
            light.cookieSize = cookieSize;
            light.renderMode = renderMode;
            light.cullingMask = cullingMask;
        }
    }
}
