using System;
using System.Collections;
using Infrastructure.Services;
using UnityEngine;

namespace Runes.Infrastructure
{
    public class TimePulseService
    {
        #region Fields

        private static TimePulseService _instance;

        #endregion

        #region Constructors

        private TimePulseService()
        {
        }

        #endregion
        
        #region Functions

        public Coroutine PulseEvery(float time, Action pulseCallback)
        {
            return CoroutineService.Instance.StartCoroutine(PulseEveryCoroutine(time, pulseCallback));
        }

        private IEnumerator PulseEveryCoroutine(float time, Action pulseCallback)
        {
            while (true)
            {
                yield return new WaitForSecondsRealtime(time);
                pulseCallback?.Invoke();
            }
        }

        private static TimePulseService CreateInstance()
        {
            return new TimePulseService();
        }
        
        #endregion

        #region Properties

        public static TimePulseService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = CreateInstance();
                }

                return _instance;
            }
        }

        #endregion
    }
}