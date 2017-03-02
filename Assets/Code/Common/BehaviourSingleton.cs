using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Common
{
    public class BehaviourSingleton<T> : MonoBehaviour where T : BehaviourSingleton<T>
    {
        public static T Current;

        

        protected virtual void Awake()
        {
            Current = (T)this;
        }
    }
}