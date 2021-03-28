using System.Collections.Generic;
using System.Linq;
using Misc;
using UnityEngine;

namespace Legacy.Editing
{
    public class ElementHolder : Singleton<ElementHolder>
    {
        private List<PlayElementView> _items = new List<PlayElementView>();

        private float MaxItemPosition => _items.Last()?.TimePosition ?? 0f;

        public delegate void OnIndexChange(float maxPos);

        public delegate void OnAddItem(PlayElementView view);

        public event OnIndexChange OnIndexChanged;
        public event OnAddItem OnItemAdded;

        private void Start()
        {
            LoadChildren();
        }

        private void LoadChildren()
        {
            var children = GetComponentsInChildren<PlayElementView>().OrderBy(x => x.TimePosition);
            _items.Clear();
            _items.AddRange(children);
            UpdateOrder();
        }

        public void AddItem(PlayElementView view)
        {
            _items.Add(view);
            UpdateOrder();
            OnItemAdded?.Invoke(view);
            view.transform.parent = transform;
        }

        public void UpdateOrder()
        {
            _items = _items.OrderBy(x => x.TimePosition).ToList();
            OnIndexChanged?.Invoke(MaxItemPosition);
        }

        public float GetZoom()
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                var scroll = Input.mouseScrollDelta;
                if (scroll.y != 0f)
                {
                    return scroll.y;
                }
            }
            return 0f;
        }

        private void Update()
        {
            var zoom = GetZoom();
            if (zoom != 0f)
            {
                Zoom(zoom * Time.deltaTime);
            }
        }

        private void Zoom(float zoom)
        {
            transform.localScale += Vector3.right * zoom;
            if(transform.localScale.x < 0)
                transform.localScale = new Vector3(0.001f, 1f, 1f);
        }
    }
}