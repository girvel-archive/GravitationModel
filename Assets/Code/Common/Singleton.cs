using System;

namespace Assets.Code.Common
{
    public class Singleton<T> where T : class
    {
        protected static T _instance;

        public static T Current
        {
            get { return _instance ?? (_instance = Activator.CreateInstance<T>()); }
        }
    }
}