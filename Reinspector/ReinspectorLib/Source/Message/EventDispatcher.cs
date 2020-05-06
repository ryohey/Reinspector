using System;
using System.Collections.Generic;
using UnityEngine;

namespace Reinspector
{
    public class EventDispatcher<MessageType>
    {
        private readonly Dictionary<Type, List<Action<object>>> listeners = new Dictionary<Type, List<Action<object>>>();
        private readonly List<Action<MessageType>> anyListeners = new List<Action<MessageType>>();

        public void Dispatch(MessageType message)
        {
            Debug.Log($"Receive Message: {message.GetType().FullName}");
            var type = message.GetType();
            if (listeners.ContainsKey(type))
            {
                listeners[type].ForEach(action => action(message));
            }
            anyListeners.ForEach(action => action(message));
        }

        public void Subscribe<T>(Action<T> callback) where T : class, MessageType
        {
            var type = typeof(T);
            List<Action<object>> list;

            if (listeners.ContainsKey(type))
            {
                list = listeners[type];
            }
            else
            {
                list = new List<Action<object>>();
                listeners[type] = list;
            }
            list.Add(obj => callback(obj as T));
        }

        public void SubscribeAny(Action<MessageType> callback)
        {
            anyListeners.Add(callback);
        }
    }
}
