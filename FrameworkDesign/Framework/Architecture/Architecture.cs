using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameworkDesign
{
    public interface IArchitecture
    { 
        void RegisterModel<T>(T instance) where T : IModel;

        void RegisterUtility<T>(T instance);

        T GetUtility<T>() where T : class;
    }

    public abstract class Architecture<T>: IArchitecture where T : Architecture<T>, new()
    {
        /// <summary>
        /// �Ƿ��ʼ�����
        /// </summary>
        private bool mInited = false;

        private List<IModel> mModels = new List<IModel>();

        private static T mArchitecture;

        public static Action<T> OnRegisterPatch = architecture => { };
        static void MakeSureArchitecture()
        {
            if (mArchitecture == null)
            {
                mArchitecture = new T();
                mArchitecture.Init();

                OnRegisterPatch?.Invoke(mArchitecture);

                foreach (var architectureModel in mArchitecture.mModels)
                {
                    architectureModel.Init();  
                }

                mArchitecture.mModels.Clear();
                mArchitecture.mInited = true;
            }
        }

        protected abstract void Init();

        private IOCContainer mContainer = new IOCContainer();

        public static T Get<T>() where T : class
        {
            MakeSureArchitecture();
            return mArchitecture.mContainer.Get<T>();
        }

        public static void Register<T>(T instance)
        {
            MakeSureArchitecture();

            mArchitecture.mContainer.Register<T>(instance);
        }

        public void RegisterModel<T>(T model) where T : IModel
        { 
            model.Architecture = this;
            mContainer.Register<T>(model);
            mModels.Add(model);

            if (!mInited)
            {
                mModels.Add(model);
            }
            else
            {
                model.Init();
            }
        }

        public void RegisterUtility<T>(T utility)
        {
            mContainer.Register<T>(utility);
        }

        public T GetUtility<T>() where T : class
        {
            return mContainer.Get<T>();
        }


    }
}

