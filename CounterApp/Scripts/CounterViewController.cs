using System;
using UnityEngine;
using UnityEngine.UI;
using FrameworkDesign;

namespace CounterApp
{
    public class CounterViewController : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

            OnCountChangedEvent.Register(OnCountChanged);

            transform.Find("BtnAdd").GetComponent<Button>().onClick.AddListener(() =>
            {
                //½»»¥Âß¼­
                CounterModel.Count++;
            });


            transform.Find("BtnSub").GetComponent<Button>().onClick.AddListener(() =>
            {
                //½»»¥Âß¼­
                CounterModel.Count--;
            });
        }

        //±íÏÖÂß¼­
        private void OnCountChanged()
        {
            transform.Find("CountText").GetComponent<Text>().text = CounterModel.Count.ToString();
        }

        private void OnDestroy()
        {
            OnCountChangedEvent.UnRegister(OnCountChanged);
        }

    }


    public static class CounterModel
    {

        public static int mCount = 0;

        public static int Count
        {
            get
            {
                return mCount;

            }
            set
            {
                if (value != mCount)
                {
                    mCount = value;

                    OnCountChangedEvent.Trigger();
                }
            }
        }
    }

    public class OnCountChangedEvent : Event<OnCountChangedEvent>
    { 
    
    }
}

