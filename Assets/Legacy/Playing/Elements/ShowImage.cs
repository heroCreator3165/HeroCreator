using Legacy.Playing.Players;
using UnityEngine;

namespace Legacy.Playing.Elements
{
    public class ShowImage : PlayElement, PlayingElement
    {
        [SerializeField] protected string textureUrl;
        public float duration = 60;

        private Texture2D _texture;
        public Texture2D Texture => _texture ?? (_texture = GetTexture());

        public override void Display()
        {
            if (Texture == null) return;
            VisualPlayer.Instance.ShowImage(_texture);
        }

        private Texture2D GetTexture()
        {
            return MediaProvider.GetResource<Texture2D>(textureUrl);
        }

        protected override void ParseAttributes(string[] args)
        {
            textureUrl = args[0];
            duration = float.Parse(args[1]);
        }

        protected override string[] GetAttributes()
        {
            return new[] {textureUrl, duration.ToString()};
        }

        protected override float DestroyTime => duration;

        public float StartPosition
        {
            get=> transform.localPosition.x;
            set => transform.localPosition = new Vector3(value, transform.localPosition.y, transform.localPosition.z);
        }
        public float EndPosition { get => transform.localPosition.x + duration; set => duration = value-transform.localPosition.x; }
        public float Duration => duration;
    }
}
