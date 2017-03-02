using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Common
{
    public class ObjectProcessor<TProcessor, T> : BehaviourSingleton<TProcessor> 
        where TProcessor : ObjectProcessor<TProcessor, T>
    {
        public List<T> Objects { get; private set; }

        protected override void Awake()
        {
            base.Awake();

            Objects = new List<T>();
        }
    }
}