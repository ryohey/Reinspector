using System;
using System.Collections;
using UnityEngine;

public static class CoroutineHandlerExtension
{
    public static void SetInterval(this CoroutineHandler handler, float timeSpan, Action action)
    {
        handler.StartCoroutine(Timer(timeSpan, action));
    }

    public static IEnumerator Timer(float timeSpan, Action action)
    {
        while (true)
        {
            yield return new WaitForSeconds(timeSpan);
            action();
        }
    }
}
