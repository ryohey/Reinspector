using UnityEngine;

namespace Reinspector.Serializable
{
    public class ShaderSerializable: UnityObjectSerializable
    {
        public ShaderSerializable(): base() { }

        public ShaderSerializable(Shader shader): base(shader)
        {
            // TODO
        }

        public Shader Instantiate()
        {
            // TODO: Fix
            var shader = Shader.Find(name);

            if (shader == null)
            {
                shader = GetDefault();
                Debug.LogWarning($"Shader not found: {name}");
            }
            return shader;
        }

        private static Shader GetDefault()
        {
            return Shader.Find("Legacy Shaders/Diffuse");
        }
    }
}
