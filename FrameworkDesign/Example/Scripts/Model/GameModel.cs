using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameworkDesign.Example
{
    public interface IGameModel
    {
        public BindableProperty<int> KillCount { get; }

        public BindableProperty<int> Gold { get; }

        public BindableProperty<int> Score { get; }

        public BindableProperty<int> BestScore { get; }

    }

    public class GameModel : IGameModel
    {
        public BindableProperty<int> KillCount { get; } = new BindableProperty<int>
        {
            Value = 0
        };

        public BindableProperty<int> Gold { get; } = new BindableProperty<int>
        {
            Value = 0
        };

        public BindableProperty<int> Score { get; } = new BindableProperty<int>
        {
            Value = 0
        };

        public BindableProperty<int> BestScore { get; } = new BindableProperty<int>
        {
            Value = 0
        };

    }
}


