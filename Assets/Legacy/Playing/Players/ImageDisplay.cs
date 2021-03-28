using Misc;
using UnityEngine;
using UnityEngine.UI;

namespace Legacy.Playing.Players
{
    [RequireComponent(typeof(RawImage))]
    public class ImageDisplay : Singleton<ImageDisplay>
    {
        private RawImage imageComponent;

        private void Start()
        {
            imageComponent = GetComponent<RawImage>() ?? gameObject.AddComponent<RawImage>();
            Hide();
        }

        public void ShowImage(Texture image)
        {
            imageComponent.texture = image;
            Show();
        }

        public void Hide()
        {
            if (imageComponent == null) return;
            imageComponent.color = Color.clear;
            imageComponent.texture = null;
        }

        public void Show()
        {
            imageComponent.color = Color.white;
        }
    }
}
