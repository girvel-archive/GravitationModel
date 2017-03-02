using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Code.Common;
using UnityEngine;

namespace Assets.Code.Processors
{
    public class ActionProcessor : BehaviourSingleton<ActionProcessor>
    {
        private readonly Queue<Action> _actionQueue = new Queue<Action>();

        private readonly object _queueLock = new object();



        public void AddActionToQueue(Action action)
        {
            lock (_queueLock)
            {
                _actionQueue.Enqueue(action);
            }
        }

        

        private void FixedUpdate()
        {
            lock (_queueLock)
            {
                if (!_actionQueue.Any()) return;

                _actionQueue.Dequeue()();
            }
        }
    }
}