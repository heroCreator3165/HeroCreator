using UnityEngine;

namespace Legacy.Editing.Views
{
    [RequireComponent(typeof(SpriteRenderer))]
    public abstract class VisualElementView : PlayElementView
    {
        public abstract float GetLength { get; }
        protected abstract Texture2D GetTexture { get; }

        private SpriteRenderer _renderer;
        private BoxCollider2D _collider;

        private static float elementSize = 0.25f;

        protected virtual void Awake()
        {
            base.Awake();
            _renderer = GetComponentInChildren<SpriteRenderer>();
            _collider = GetComponent<BoxCollider2D>();
        }

        protected override void Start()
        {
            base.Start();

            FitTexture();
            Resize();
        }

        private void FitTexture()
        {
            var texture = GetTexture;
            var ySize = elementSize * 10f;
            var xSize = 10f;

            var sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, xSize, ySize), new Vector2(0f, ySize/2f), 100f);
            _renderer.sprite = sprite;

            var colliderSize = _renderer.sprite.bounds.size;
            _collider.size = colliderSize;
            _collider.offset = new Vector2((colliderSize.x / 2), 0);
        }

        public void Resize()
        {
            var size = GetLength;

            var bounds = _renderer.sprite.bounds;
            var xSize = bounds.size.x;
            var xScale = size / xSize;

            var ySize = bounds.size.y;
            var yScale = elementSize / ySize;

            transform.localScale = new Vector3(xScale, yScale, 1f);
        }
    }
}
