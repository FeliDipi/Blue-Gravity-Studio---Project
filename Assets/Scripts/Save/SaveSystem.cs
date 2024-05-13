using System;
using System.Collections.Generic;
using UnityEngine;

namespace BGS.Save
{
    public class SaveSystem : MonoBehaviour
    {
        public static SaveSystem Instance;

        private Dictionary<Type, object> _data = new Dictionary<Type, object>();

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
            else Destroy(this);
        }

        public bool ExistData(Type key)
        {
            return _data.ContainsKey(key);
        }

        public T LoadData<T>(Type key)
        {
            if (!ExistData(key)) return default;

            return (T)_data[key];
        }

        public void SaveData(Type key, object data)
        {
            if (!ExistData(key)) _data.Add(key, data);
            else _data[key] = data;
        }
    }
}