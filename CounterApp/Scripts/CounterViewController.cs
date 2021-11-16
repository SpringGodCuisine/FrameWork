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

            CounterModel.Count.OnValueChanged += OnCountChanged;

            OnCountChanged(CounterModel.Count.Value);

            transform.Find("BtnAdd").GetComponent<Button>().onClick.AddListener(() =>
            {
                //½»»¥Âß¼­
                CounterModel.Count.Value++;
            });


            transform.Find("BtnSub").GetComponent<Button>().onClick.AddListener(() =>
            {
                //½»»¥Âß¼­
                CounterModel.Count.Value--;
            });
        }

        //±íÏÖÂß¼­
        private void OnCountChanged(int newCount)
        {
            transform.Find("CountText").GetComponent<Text>().text = newCount.ToString();
        }

        private void OnDestroy()
        {
            CounterModel.Count.OnValueChanged -= OnCountChanged;
        }

    }


    public static class CounterModel
    {
        public static BindableProperty<int> Count = new BindableProperty<int>
        {
            Value = 0
        };
    }

}

