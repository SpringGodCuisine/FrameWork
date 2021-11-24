using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;

namespace FrameworkDesign
{
    public class Singleton<T> where T : Singleton<T>
    {
        private static T mInstance;

        public static T Instance
        {
            get
            {
                if (mInstance == null)
                {
                    var type = typeof(T);
                    var ctors = type.GetConstructors(BindingFlags.Instance
                        | BindingFlags.NonPublic);
                    var ctor = Array.Find(ctors, C => C.GetParameters().Length == 0);

                    if (ctor == null)
                    {
                        throw new Exception("Non Public Constructor Not Fount in " + type.Name);
                    }

                    mInstance =  ctor.Invoke(null) as T;
                }

                return mInstance;
            }
        }

    }
}
