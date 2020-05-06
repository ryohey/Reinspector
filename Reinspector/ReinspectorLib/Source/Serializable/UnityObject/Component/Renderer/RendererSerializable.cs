using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

namespace Reinspector.Serializable
{
    public class RendererSerializable: ComponentSerializable
    {
        public string sortingLayerName;
        public int sortingLayerID;
        public int sortingOrder;
        public int lightmapIndex;
        public int realtimeLightmapIndex;
        public Vector4 lightmapScaleOffset;
        public Vector4 realtimeLightmapScaleOffset;
        public MaterialSerializable[] materials;
        public ReflectionProbeUsage reflectionProbeUsage;
        public LightProbeUsage lightProbeUsage;
        public bool enabled;
        public ShadowCastingMode shadowCastingMode;
        public bool receiveShadows;
        public MotionVectorGenerationMode motionVectorGenerationMode;

        public RendererSerializable() : base() { }

        public RendererSerializable(Renderer renderer) : base(renderer)
        {
            sortingLayerName = renderer.sortingLayerName;
            sortingLayerID = renderer.sortingLayerID;
            sortingOrder = renderer.sortingOrder;
            lightmapIndex = renderer.lightmapIndex;
            realtimeLightmapIndex = renderer.realtimeLightmapIndex;
            lightmapScaleOffset = renderer.lightmapScaleOffset;
            realtimeLightmapScaleOffset = renderer.realtimeLightmapScaleOffset;
            reflectionProbeUsage = renderer.reflectionProbeUsage;
            lightProbeUsage = renderer.lightProbeUsage;
            enabled = renderer.enabled;

            materials = renderer.materials?.Select(m => new MaterialSerializable(m)).ToArray();
            shadowCastingMode = renderer.shadowCastingMode;
            receiveShadows = renderer.receiveShadows;
            motionVectorGenerationMode = renderer.motionVectorGenerationMode;
        }

        public override void Restore(Component component, RestorePostProcess post)
        {
            base.Restore(component, post);
            var renderer = component as Renderer;

            renderer.sortingLayerName = sortingLayerName;
            renderer.sortingLayerID = sortingLayerID;
            renderer.sortingOrder = sortingOrder;
            renderer.lightmapIndex = lightmapIndex;
            renderer.realtimeLightmapIndex = realtimeLightmapIndex;
            renderer.lightmapScaleOffset = lightmapScaleOffset;
            renderer.realtimeLightmapScaleOffset = realtimeLightmapScaleOffset;
            renderer.reflectionProbeUsage = reflectionProbeUsage;
            renderer.lightProbeUsage = lightProbeUsage;
            renderer.enabled = enabled;

            renderer.materials = materials?.Select(m => m.Instantiate()).ToArray();
            renderer.shadowCastingMode = shadowCastingMode;
            renderer.receiveShadows = receiveShadows;
            renderer.motionVectorGenerationMode = motionVectorGenerationMode;
        }
    }
}
