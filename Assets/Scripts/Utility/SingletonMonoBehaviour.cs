using UnityEngine;

namespace Utility
{
    public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = (T)FindObjectOfType(typeof(T));
                    if (_instance == null)
                    {
                        SetupInstance();
                    }
                    else
                    {
                        string typeName = typeof(T).Name;
                        Debug.Log("[Singleton] " + typeName + " instance already created: " +
                                _instance.gameObject.name);
                    }
                }

                return _instance;
            }
        }

        // シーン内だけのSingletonとする
        protected static bool _isSceneSingleton = false;

        public virtual void Awake()
        {
            RemoveDuplicates();
        }

        /// <summary>
        /// Instanceのセットアップ
        /// </summary>
        private static void SetupInstance()
        {
            _instance = (T)FindObjectOfType(typeof(T));

            if (_instance == null)
            {
                GameObject gameObj = new GameObject();
                gameObj.name = typeof(T).Name;

                _instance = gameObj.AddComponent<T>();
                if (!_isSceneSingleton)
                {
                    DontDestroyOnLoad(gameObj);
                }
            }
        }

        /// <summary>
        /// Instanceが複数シーンにないか確認
        /// </summary>
        private void RemoveDuplicates()
        {
            if (_instance == null)
            {
                _instance = this as T;
                // シーン内だけのSingletonとする
                if (!_isSceneSingleton)
                {
                    DontDestroyOnLoad(gameObject);
                }
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

}

