using Legacy.Playing.Elements;
using UnityEngine;

namespace Legacy.Editing.Views
{
    public class ImageView : VisualElementView
    {
        private ShowImage _imageComponent;

        public override PlayElement GetElement()
        {
            return _imageComponent ?? (_imageComponent = GetComponent<ShowImage>());
        }

        public override float GetLength => (GetElement() as ShowImage)?.duration ??  0f;
        protected override Texture2D GetTexture => (GetElement() as ShowImage)?.Texture;
    }
}
