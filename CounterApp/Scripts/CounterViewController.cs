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

            CounterModel.Instance.Count.OnValueChanged += OnCountChanged;

            OnCountChanged(CounterModel.Instance.Count.Value);

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
            CounterModel.Instance.Count.OnValueChanged -= OnCountChanged;
        }

    }


    public class CounterModel:Singleton<CounterModel>
    {
        private CounterModel() { }

        public BindableProperty<int> Count = new BindableProperty<int>
        {
            Value = 0
        };
    }

}

