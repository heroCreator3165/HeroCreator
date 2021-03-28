using Legacy.Playing.Elements;
using UnityEngine;

namespace Legacy.Editing
{
    public abstract class PlayElementView : TimeBarSpriteDraggable
    {
        public float TimePosition => transform.position.x;
        public abstract PlayElement GetElement();

        protected virtual void Start()
        {
            ElementHolder.Instance.AddItem(this);
            GetElement().destroyOnPlay = false;
        }

        protected virtual void OnMouseUp()
        {
            ElementHolder.Instance.UpdateOrder();
        }

        public static T Create<T>(float position, PlayElementSetupParameters parameters) where T:PlayElementView
        {
            var newElement = new GameObject(nameof(T));
            newElement.transform.position = Vector3.right * position;
            var element = newElement.AddComponent<T>();
            parameters.SetupElement(element);
            return element;
        } 
    }
}