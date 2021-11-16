using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CounterApp
{
    public class CounterViewController : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

            CounterModel.OnCountChanged += OnCountChanged;

            OnCountChanged(CounterModel.Count);

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
        private void OnCountChanged(int newCount)
        {
            transform.Find("CountText").GetComponent<Text>().text = newCount.ToString();
        }

        private void OnDestroy()
        {
            CounterModel.OnCountChanged -= OnCountChanged;
        }

    }


    public static class CounterModel
    {

        public static int mCount = 0;

        public static Action<int> OnCountChanged;

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

                    OnCountChanged?.Invoke(value);
                }
            }
        }
    }
}

