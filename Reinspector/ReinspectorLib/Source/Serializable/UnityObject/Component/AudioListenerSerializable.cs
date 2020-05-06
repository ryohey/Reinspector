using UnityEngine;

namespace Reinspector.Serializable
{
    public class AudioListenerSerializable : ComponentSerializable
    {
        public AudioListenerSerializable(): base() { }

        public AudioListenerSerializable(AudioListener obj) : base(obj)
        {
        }
    }
}
