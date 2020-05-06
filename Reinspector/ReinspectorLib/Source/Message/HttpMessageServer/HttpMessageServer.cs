using Reinspector.Message;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using UnityEngine;

namespace Reinspector
{
    public class HttpMessageServer : IMessageBroker
    {
        private readonly string url;
        private readonly Serializer serializer = new Serializer();
        private readonly List<IMessage> messages = new List<IMessage>();
        private readonly EventDispatcher<IMessage> dispatcher = new EventDispatcher<IMessage>();
        private HttpListener listener;

        private DateTime lastConnectionTime;
        public bool IsConnected => new TimeSpan(DateTime.Now.Ticks - lastConnectionTime.Ticks).TotalSeconds < 5;

        public HttpMessageServer(string url)
        {
            this.url = url;
            StartListener();
        }

        void StartListener()
        {
            listener = new HttpListener();
            listener.Prefixes.Add(url);

            try
            {
                listener.Start();
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
                return;
            }

            listener.BeginGetContext(RequestCallback, listener);
            Debug.Log($"Start server {url}");
        }

        void RequestCallback(IAsyncResult result)
        {
            try
            {
                var listener = (HttpListener)result.AsyncState;
                var context = listener.EndGetContext(result);
                var req = context.Request;
                var res = context.Response;
                Debug.Log($"Receive: [{req.HttpMethod}] {req.Url}");
                lastConnectionTime = DateTime.Now;
                switch (req.HttpMethod)
                {
                    case "POST":
                        {
                            var data = req.InputStream.ReadAllBytes();
                            var message = serializer.Deserialize<MessageUnion>(data)?.Value;

                            if (message != null)
                            {
                                dispatcher.Dispatch(message);
                            }
                            res.StatusCode = (int)HttpStatusCode.OK;
                            var content = Encoding.UTF8.GetBytes("OK");
                            res.OutputStream.Write(content, 0, content.Length);
                            break;
                        }
                    case "GET":
                        {
                            var msg = messages.Select(m => new MessageUnion(m)).ToArray();
                            var data = serializer.Serialize(msg);
                            res.StatusCode = (int)HttpStatusCode.OK;
                            res.OutputStream.Write(data, 0, data.Length);
                            messages.Clear();
                            break;
                        }
                    default:
                        res.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                }
                res.Close(); 
                listener.BeginGetContext(RequestCallback, listener);
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
                Debug.LogError(e.StackTrace);
            }
        }

        public void Post<T>(T obj) where T : class, IMessage
        {
            messages.Add(obj);
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
