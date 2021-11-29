using System;
using UnityEngine;
using UnityEngine.UI;
using FrameworkDesign;

namespace CounterApp
{
    public class CounterViewController : MonoBehaviour
    {
        private ICounterModel mCounterModel;
          
        // Start is called before the first frame update
        void Start()
        {
            mCounterModel = CounterApp.Get<ICounterModel>();

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

    public interface ICounterModel : IModel
    { 
        BindableProperty<int> Count { get; }
    }
    public class CounterModel : ICounterModel
    {
        public void Init()
        {
            var Storage = Architecture.GetUtility<IStorage>();

            Count.Value = Storage.LoadInt("COUNTER_COUNT", 0);

            Count.OnValueChanged += count =>
            {
                Storage.SaveInt("COUNTER_COUNT", count);
            };
        }


        public BindableProperty<int> Count { get; } = new BindableProperty<int>
        {
            Value = 0
        };
        public IArchitecture Architecture { get; set; }


    }

}

