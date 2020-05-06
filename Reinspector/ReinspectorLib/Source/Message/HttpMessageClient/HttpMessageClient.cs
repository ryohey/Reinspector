using Reinspector.Message;
using System;
using System.Collections;
using System.Linq;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;

namespace Reinspector
{
    public class HttpMessageClient: IMessageBroker
    {
        private readonly string url;
        private readonly Serializer serializer = new Serializer();
        private readonly EventDispatcher<IMessage> dispatcher = new EventDispatcher<IMessage>();

        public HttpMessageClient(string url)
        {
            this.url = url;
            CoroutineHandler.Instance.SetInterval(1, CheckEvents);
        }

        public void CheckEvents()
        {
            CoroutineHandler.Instance.StartCoroutine(GetMessages());
        }

        IEnumerator GetMessages()
        {
            var req = UnityWebRequest.Get(url);
            req.downloadHandler = new DownloadHandlerBuffer();
            Debug.Log($"GET {url}");
            yield return req.Send();

            var status = req.responseCode;
            Debug.Log($"GET Response: {status}");

            if (!string.IsNullOrEmpty(req.error))
            {
                Debug.LogError(req.error);
            }
            else if (status != (int)HttpStatusCode.OK)
            {
                Debug.LogError($"{status} Error");
            }
            else
            {
                Debug.Log($"Success: GET {url}");
                var data = req.downloadHandler.data;
                var messages = serializer.Deserialize<MessageUnion[]>(data);
                Debug.Log($"Receive {messages.Count()} messages");
                messages
                    ?.Select(m => m.Value)
                    .ToList()
                    .ForEach(dispatcher.Dispatch);
            }
        }

        public void Post<T>(T obj) where T : class, IMessage
        {
            CoroutineHandler.Instance.StartCoroutine(PostMessage(obj));
        }

        IEnumerator PostMessage<T>(T obj) where T: IMessage
        {
            var data = serializer.Serialize(new MessageUnion(obj));
            var req = new UnityWebRequest(url, "POST")
            {
                uploadHandler = new UploadHandlerRaw(data)
            };
            Debug.Log($"POST {url}");
            yield return req.Send();

            if (!string.IsNullOrEmpty(req.error))
            {
                Debug.LogError(req.error);
            }
            else
            {
                Debug.Log($"Success: POST {url}");
            }
        }

        public void Subscribe<T>(Action<T> callback) where T : class, IMessage
        {
            dispatcher.Subscribe(callback);
        }

        public void SubscribeAny(Action<IMessage> callback)
        {
            dispatcher.SubscribeAny(callback);
        }
    }
}
