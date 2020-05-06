using UnityEngine;

namespace Reinspector.Serializable
{
    public class TextureSerializable: UnityObjectSerializable
    {
        public int width;
        public int height;

        public TextureWrapMode wrapMode;

        public FilterMode filterMode;

        public float mipMapBias;
        public int anisoLevel;

        public TextureSerializable() : base() { }

        public TextureSerializable(Texture tex): base(tex)
        {
            width = tex.width;
            height = tex.height;

            wrapMode = tex.wrapMode;

            filterMode = tex.filterMode;

            mipMapBias = tex.mipMapBias;
            anisoLevel = tex.anisoLevel;
        }

        public virtual Texture Instantiate()
        {
            Debug.LogError("Try to deserialize base class: Texture");
            return null;
        }

        public void Restore(Texture tex)
        {
            tex.wrapMode = wrapMode;
            tex.mipMapBias = mipMapBias;
            tex.anisoLevel = anisoLevel;
            tex.filterMode = filterMode;
        }
    }
}
