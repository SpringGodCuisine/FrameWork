using System;
using UnityEngine;

namespace FrameworkDesign.Example
{
    public class Game : MonoBehaviour
    {
        public void Awake()
        {
            GameStartEvent.Register(OnGameStart);
            GameModel.KillCount.OnValueChanged += OnEnemyKilled;
        }

        private void OnEnemyKilled(int KillCount)
        {
            if (GameModel.KillCount.Value == 10)
                GamePassEvent.Trigger();
        }

        private void OnGameStart()
        {
            transform.Find("Enemies").gameObject.SetActive(true);
        }

        private void OnDestroy()
        {
            GameStartEvent.UnRegister(OnGameStart);
            GameModel.KillCount.OnValueChanged -= OnEnemyKilled;
        }
    }

}
