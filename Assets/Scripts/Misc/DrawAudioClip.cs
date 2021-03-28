using UnityEngine;
using UnityEngine.UI;

namespace Misc
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class DrawAudioClip : MonoBehaviour
    {
        public int height = 500;
        public Color waveformColor = Color.green;
        public Color backGroundColor = Color.black;
        public float saturation = 1f;

        private SpriteRenderer _imageComponent;
        public AudioClip _audioClip;

        void Start()
        {
            _imageComponent = GetComponent<SpriteRenderer>();
            DrawClip();
        }

        private void DrawClip()
        {
            if (_audioClip == null)
                return;

            var width = 4096;
            Texture2D texture =
                ClipDrawer.PaintWaveformSpectrum(_audioClip, saturation, width, height, waveformColor, backGroundColor);
            _imageComponent.sprite =
                Sprite.Create(texture, new Rect(0f, 0f, texture.width, texture.height), new Vector2(0f, 0.5f));
            gameObject.ScaleToSize2D(new Vector3(_audioClip.length, height));
        }

        public void Draw(AudioClip clip, int? height = null)
        {
            _audioClip = clip;
            this.height = height ?? this.height;
            DrawClip();
        }
    }
}