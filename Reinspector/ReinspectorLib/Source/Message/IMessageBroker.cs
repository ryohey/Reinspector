using System;

namespace Reinspector
{
    public interface IMessageBroker
    {
        void Subscribe<T>(Action<T> callback) where T : class, Message.IMessage;
        void SubscribeAny(Action<Message.IMessage> callback);
        void Post<T>(T obj) where T : class, Message.IMessage;
    }
}
