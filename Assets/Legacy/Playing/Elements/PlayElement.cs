using UnityEngine;

namespace Legacy.Playing.Elements
{
    [RequireComponent(typeof(BoxCollider2D))]
    public abstract class PlayElement : MonoBehaviour
    {
        protected abstract void ParseAttributes(string[] args);
        protected abstract string[] GetAttributes();
        protected abstract float DestroyTime { get; }
        public abstract void Display();

        public bool destroyOnPlay = true;

        public void Play()
        {
            Display();
            if (destroyOnPlay)
                Destroy(gameObject, DestroyTime);
        }

        protected virtual void Awake()
        {
            var collider = GetComponent<BoxCollider2D>();
            collider.isTrigger = true;
            collider.size = new Vector2(0.01f, 1);
        }

        public static PlayElement Parse(string str)
        {
            var split = str.Split('>');
            if (split.Length != 3)
            {
                Debug.Log($"String {str} is not parsable !");
                return null;
            }

            var element = PlayElementTypeOrganizer.GetElement(split[0]);
            if (element == null) return null;

            var xPos = float.Parse(split[1]);
            element.transform.localPosition = Vector3.right * xPos;

            var attributes = split[2].Split(',');
            element.ParseAttributes(attributes);

            return element;
        }

        public string GetString()
        {
            var name = GetType().Name;
            var pos = transform.localPosition.x;
            var attributes = GetAttributes();
            return $"{name}>{pos}>{string.Join(",", attributes)}";
        }
    }
}