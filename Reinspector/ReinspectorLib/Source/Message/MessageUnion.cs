using Reinspector.Message;
using UnityEngine;

namespace Reinspector
{
    public class MessageUnion
    {
        readonly public RequestSaveAllScenes requestSaveAllScenes;

        public IMessage Value =>
            requestSaveAllScenes as IMessage
            ;

        public MessageUnion() { }

        public MessageUnion(IMessage msg)
        {
            switch (msg)
            {
                case RequestSaveAllScenes m:
                    requestSaveAllScenes = m;
                    break;
                default:
                    Debug.LogError($"Invalid message type: {msg.GetType().FullName}");
                    break;
            }
        }
    }
}
