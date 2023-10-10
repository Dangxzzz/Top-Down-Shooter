﻿using System;
using System.Collections.Generic;
using TDS.Infrastracture.Locator;
using UnityEngine;

namespace TDS.Infrastracture.Services
{
    public class ServiceLocator : MonoBehaviour
    {
        #region Variables

        private static ServiceLocator _instance;

        private const string LogTag = nameof(ServiceLocator);

        private readonly Dictionary<Type, IService> _servicesByTypes = new();

        #endregion

        #region Properties

        public static ServiceLocator Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject go = new(nameof(ServiceLocator));
                    DontDestroyOnLoad(go);
                    _instance = go.AddComponent<ServiceLocator>();
                }

                return _instance;
            }
        }

        #endregion

        #region Public methods

        public T Get<T>() where T : class
        {
            _servicesByTypes.TryGetValue(typeof(T), out IService value);
            return value as T;
        }

        public void Register<T>(T service) where T : class, IService
        {
            Type key = typeof(T);
            if (_servicesByTypes.ContainsKey(key))
            {
                Debug.LogError($"[{LogTag}:{nameof(Register)}] Duplicate register of services '{key}'!");
                return;
            }

            _servicesByTypes.Add(key, service);
        }

        public void RegisterMonoBeh<T>() where T : MonoBehaviour, IService
        {
            Type key = typeof(T);
            if (_servicesByTypes.ContainsKey(key))
            {
                Debug.LogError($"[{LogTag}:{nameof(RegisterMonoBeh)}] Duplicate register of services '{key}'!");
                return;
            }

            GameObject go = new(typeof(T).Name);
            DontDestroyOnLoad(go);
            T component = go.AddComponent<T>();

            _servicesByTypes.Add(key, component);
        }

        public void Unregister<T>() where T : class, IService
        {
            Type key = typeof(T);
            if (!_servicesByTypes.ContainsKey(key))
            {
                Debug.LogError($"[{LogTag}:{nameof(Unregister)}] Service '{key}' is not registered!");
                return;
            }

            _servicesByTypes.Remove(key);
        }

        #endregion
    }
}
