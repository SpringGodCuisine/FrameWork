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
            transform.Find("BtnAdd").GetComponent<Button>().onClick.AddListener(() =>
            {
                //交互逻辑
                CounterModel.Count++;
                //表现逻辑
                UpdateView();
            });


            transform.Find("BtnSub").GetComponent<Button>().onClick.AddListener(() =>
            {
                //交互逻辑
                CounterModel.Count--;
                //表现逻辑
                UpdateView();
            });
        }

        void UpdateView()
        {
            transform.Find("CountText").GetComponent<Text>().text = CounterModel.Count.ToString();
        }

    }


    public static class CounterModel
    {
        public static int Count = 0;
    }
}

