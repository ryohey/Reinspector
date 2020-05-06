using UnityEngine;

namespace Reinspector.Serializable
{
    public class Texture2DSerializable: TextureSerializable
    {
        public TextureFormat format;
        public byte[] data;

        public Texture2DSerializable(): base() { }

        public Texture2DSerializable(Texture2D tex): base(tex)
        {
            var copy = tex.Duplicate();
            format = copy.format;
            data = copy.GetRawTextureData();
        }

        public override Texture Instantiate()
        {
            var tex = new Texture2D(width, height, format, false);
            Restore(tex);
            if (data != null)
            {
                tex.LoadRawTextureData(data);
            }
            tex.Apply();
            return tex;
        }
    }
}
