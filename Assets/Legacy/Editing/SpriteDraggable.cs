using UnityEngine;

namespace Legacy.Editing
{
    public abstract class SpriteDraggable : MonoBehaviour
    {
        private Color _mouseOverColor = Color.blue;
        private Color _originalColor = Color.yellow;
        private float _distance;

        protected SpriteRenderer renderer;
        
        protected virtual void Awake()
        {
            renderer = GetComponent<SpriteRenderer>();
            _originalColor = renderer.color;
        }

        private float distance;
        private Vector3 startDist;


        void OnMouseEnter()
        {
            renderer.color = _mouseOverColor;
        }

        void OnMouseExit()
        {
            renderer.color = _originalColor;
        }

        void OnMouseDown()
        {
            distance = Vector3.Distance(transform.position, Camera.main.transform.position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            startDist = transform.position - rayPoint;
        }

        void OnMouseDrag()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            MoveByMouse(rayPoint + startDist);
        }

        protected virtual void MoveByMouse(Vector3 position)
        {
            transform.position = position;
        }
    }
}

