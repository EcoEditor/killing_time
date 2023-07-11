using System;
using System.Collections;
using RSG;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Infrastructure.Services
{
    public class CoroutineService
    {
        #region Internals

        private class CoroutineCore : MonoBehaviour
        {
            public event Action Destroyed;
            private void OnDestroy()
            {
                StopAllCoroutines();
                Destroyed?.Invoke();
            }
        }

        #endregion
        
        #region Fields

        private static CoroutineService _instance;

        private static CoroutineCore _core;

        private bool _isCoreDestroyed;
        
        #endregion

        #region Constructor

        private CoroutineService()
        {
            var go = new GameObject("CoroutineService");
            Object.DontDestroyOnLoad(go);
            _core = go.AddComponent<CoroutineCore>();
            _core.Destroyed += OnCoroutineCoreDestroyed;
        }

        #endregion
        
        #region Methods

        public IPromise Delay(float delay)
        {
            var p = new Promise();
            StartCoroutine(DelayCoroutine(delay, p));
            return p;
        }

        private IEnumerator DelayCoroutine(float delay, Promise p)
        {
            yield return new WaitForSeconds(delay);
            p.Resolve();
        }

        public Coroutine StartCoroutine(IEnumerator coroutineBody)
        {
            return _core.StartCoroutine(coroutineBody);
        }

        public void StopCoroutine(Coroutine coroutine)
        {
            if (_isCoreDestroyed)
            {
                return;
            }

            _core.StopCoroutine(coroutine);
        }

        private void OnCoroutineCoreDestroyed()
        {
            _isCoreDestroyed = true;
        }

        #endregion
        
        #region Properties

        public static CoroutineService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CoroutineService();
                }

                return _instance;
            }
        }

        #endregion
    }
}