using System;
using System.Collections.Generic;
using UnityEngine;

namespace Reinspector
{
    public class RestorePostProcess
    {
        private IList<Action<GameObject>> actions = new List<Action<GameObject>>();
        
        public void Register(Action<GameObject> action)
        {
            actions.Add(action);
        }

        public void Run(GameObject root)
        {
            foreach (var action in actions)
            {
                action(root);
            }
        }
    }
}
