using System.Collections.Generic;
using UnityEngine;

namespace Reinspector
{
    public static class TransformExtensions
    {
        public static List<Transform> GetAllChildren(this Transform transform)
        {
            var list = new List<Transform>();
            for (var i = 0; i < transform.childCount; i++)
            {
                list.Add(transform.GetChild(i));
            }
            return list;
        }
    }
}
