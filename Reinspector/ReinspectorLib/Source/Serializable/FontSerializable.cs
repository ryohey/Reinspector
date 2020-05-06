using UnityEngine;

namespace Reinspector.Serializable
{
    public class FontSerializable: ObjectSerializable
    {
        public MaterialSerializable material;
        public string[] fontNames;

        public FontSerializable(): base() { }

        public FontSerializable(Font font): base(font)
        {
            material = font.material != null ? new MaterialSerializable(font.material) : null;
            fontNames = font.fontNames;
        }

        public Font Instantiate()
        {
            // FIXME: use the built-in font for now
            var font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            font.material = material?.Instantiate();
            font.fontNames = fontNames;
            return font;
        }
    }
}
