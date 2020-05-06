using UnityEngine;

namespace Reinspector.Serializable
{
    public class MaterialSerializable: UnityObjectSerializable
    {
        public string[] shaderKeywords;
        public bool enableInstancing;
        public bool doubleSidedGI;
        public MaterialGlobalIlluminationFlags globalIlluminationFlags;
        public int renderQueue;
        public Vector2 mainTextureScale;
        public Vector2 mainTextureOffset;
        public ShaderSerializable shader;

        // properties
        public Color color;
        public TextureUnion mainTex;

        public MaterialSerializable(): base() { }

        public MaterialSerializable(Material material): base(material)
        {
            shaderKeywords = material.shaderKeywords;
            enableInstancing = material.enableInstancing;
            doubleSidedGI = material.doubleSidedGI;
            globalIlluminationFlags = material.globalIlluminationFlags;
            renderQueue = material.renderQueue;
            mainTextureScale = material.mainTextureScale;
            mainTextureOffset = material.mainTextureOffset;
            shader = material.shader != null ? new ShaderSerializable(material.shader) : null;

            if (material.HasProperty("_Color"))
            {
                color = material.GetColor("_Color");
            }
            if (material.HasProperty("_MainTex"))
            {
                var tex = material.GetTexture("_MainTex");
                mainTex = tex != null ? new TextureUnion(tex) : null;
            }
        }

        public Material Instantiate()
        {
            var material = new Material(shader?.Instantiate())
            {
                shaderKeywords = shaderKeywords,
                enableInstancing = enableInstancing,
                doubleSidedGI = doubleSidedGI,
                globalIlluminationFlags = globalIlluminationFlags,
                renderQueue = renderQueue,
                mainTextureScale = mainTextureScale,
                mainTextureOffset = mainTextureOffset
            };

            if (material.HasProperty("_Color"))
            {
                material.SetColor("_Color", color);
            }
            if (material.HasProperty("_MainTex") && mainTex != null)
            {
                material.SetTexture("_MainTex", mainTex.Value.Instantiate());
            }

            return material;
        }
    }
}
