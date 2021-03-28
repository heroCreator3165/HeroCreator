using Legacy.Playing.Elements;
using UnityEngine;

namespace Legacy.Editing.Views
{
    public class VideoView : VisualElementView
    {
        [SerializeField] private Texture2D previewTexture;
        private PlayVideo _videoComponent;

        public override PlayElement GetElement()
        {
            return _videoComponent ?? (_videoComponent = GetComponent<PlayVideo>());
        }

        public override float GetLength => (GetElement() as PlayVideo).Duration;
        protected override Texture2D GetTexture => previewTexture;
    }
}