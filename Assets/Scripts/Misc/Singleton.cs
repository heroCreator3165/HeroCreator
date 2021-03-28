using UnityEngine;

namespace Misc
{
    public class Singleton<T> : MonoBehaviour where T : Component
    {
        private static T instance;

        [SerializeField] private bool dontDestroyOnLoad = false;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();
                    if (instance == null)
                    {
                        GameObject obj = new GameObject();
                        obj.name = typeof(T).Name;
                        obj.hideFlags = HideFlags.DontSave;
                        instance = obj.AddComponent<T>();
                    }
                }
                return instance;
            }
        }

        public virtual void Awake()
        {
            if(dontDestroyOnLoad)
                DontDestroyOnLoad(this.gameObject);
            if (instance == null)
            {
                instance = this as T;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
