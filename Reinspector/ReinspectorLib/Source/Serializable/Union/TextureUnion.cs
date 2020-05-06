using UnityEngine;

namespace Reinspector.Serializable
{
    public class TextureUnion
    {
        public Texture2DSerializable texture2D;
        public TextureSerializable texture;

        public TextureSerializable Value =>
            texture2D as TextureSerializable
            ?? texture;

        public TextureUnion() { }

        public TextureUnion(Texture tex)
        {
            switch(tex)
            {
                case Texture2D t:
                    texture2D = new Texture2DSerializable(t);
                    break;
                case Texture t:
                    Debug.LogWarning("Serialize as base class Texture: " + t.GetType().FullName);
                    texture = new TextureSerializable(t);
                    break;
            }
        }
    }
}
