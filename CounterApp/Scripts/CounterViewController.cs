using System;
using UnityEngine;
using UnityEngine.UI;
using FrameworkDesign;

namespace CounterApp
{
    public class CounterViewController : MonoBehaviour
    {
        private CounterModel mCounterModel;
          
        // Start is called before the first frame update
        void Start()
        {
            mCounterModel = CounterApp.Get<CounterModel>();

            mCounterModel.Count.OnValueChanged += OnCountChanged;

            OnCountChanged(mCounterModel.Count.Value);

            transform.Find("BtnAdd").GetComponent<Button>().onClick.AddListener(() =>
            {
                //½»»¥Âß¼­
                new AddCountCommand()
                .Execute();
            });


            transform.Find("BtnSub").GetComponent<Button>().onClick.AddListener(() =>
            {
                //½»»¥Âß¼­
                new SubCountCommand()
                .Execute();
            });
        }

        //±íÏÖÂß¼­
        private void OnCountChanged(int newCount)
        {
            transform.Find("CountText").GetComponent<Text>().text = newCount.ToString();
        }

        private void OnDestroy()
        {
            mCounterModel.Count.OnValueChanged -= OnCountChanged;
        }

    }


    public class CounterModel
    {
        public BindableProperty<int> Count = new BindableProperty<int>
        {
            Value = 0
        };
    }

}

