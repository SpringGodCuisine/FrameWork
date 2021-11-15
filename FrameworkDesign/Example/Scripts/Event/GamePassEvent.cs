using System;

namespace FrameworkDesign.Example
{
    public static class GamePassEvent
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


