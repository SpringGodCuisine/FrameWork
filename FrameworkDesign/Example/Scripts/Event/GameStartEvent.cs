using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace FrameworkDesign.Example
{
    public class GameStartEvent : MonoBehaviour
    {
        private static Action mOnEvent;

        public static void Register(Action onEvent)
        {
            mOnEvent += onEvent;
        }

        public static void UnRegister(Action onEvent)
        {
            mOnEvent -= onEvent;
        }

        public static void Trigger()
        {
            mOnEvent?.Invoke();
        }
    }
}

