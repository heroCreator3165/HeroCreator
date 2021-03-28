using System.IO;
using Misc;
using UnityEngine;

namespace Legacy.Playing.Elements
{
    [RequireComponent(typeof(AudioSource), typeof(SpriteRenderer))]
    public class ShowBeat : PlayElement
    {
        [SerializeField] private string clipPath;
        [SerializeField] private string displayFilePath;
        private AudioClip clip;
        private AudioSource source;

        private SpriteRenderer renderer;

        protected override void Awake()
        {
            base.Awake();
            source = gameObject.GetComponent<AudioSource>();
            source.playOnAwake = false;

            var collider = GetComponent<BoxCollider2D>();
            collider.isTrigger = true;
            collider.size = new Vector2(1, 1);
        }

        private void Start()
        {
            clip = MediaProvider.GetResource<AudioClip>(clipPath);
            source.clip = clip;

            LoadImage();
            gameObject.ScaleToSize2D(new Vector3(0.4f, 0.3f, 1));
        }


        protected override void ParseAttributes(string[] args)
        {
            clipPath = args[0];
            displayFilePath = args[1];
        }

        protected override string[] GetAttributes()
        {
            return new[] {clipPath, displayFilePath};
        }

        protected override float DestroyTime => clip?.length ?? 0;

        public override void Display()
        {
            source.Play();
        }

        private void LoadImage()
        {
            if (!File.Exists(displayFilePath))
            {
                Debug.Log("Image not found !");
                return;
            }

            var image = MediaProvider.GetResource<Texture2D>(displayFilePath);
            if (image == null) return;

            renderer = GetComponent<SpriteRenderer>() ?? gameObject.AddComponent<SpriteRenderer>();
            renderer.sprite = Sprite.Create(image, new Rect(0,0, image.width, image.height), new Vector2(0.5f,0.5f), 100f);
        }
    }
}
