using Legacy.Playing.Players;
using UnityEngine;

namespace Legacy.Playing.Elements
{
    public class PlayVideo : PlayElement, PlayingElement
    {
        [SerializeField] private string videoUrl;
        [SerializeField] private double startTime = 0;
        [SerializeField] private double endTime = long.MaxValue;
        [SerializeField] private bool mute = true;

        public override void Display()
        {
            VisualPlayer.Instance.ShowVideo(videoUrl,mute, startTime, endTime);
        }

        protected override void ParseAttributes(string[] args)
        {
            videoUrl = args[0];
            startTime = double.Parse(args[1]);
            endTime = double.Parse(args[2]);
            mute = bool.Parse(args[3]);
        }

        protected override string[] GetAttributes()
        {
            return new[] {videoUrl, startTime.ToString(), endTime.ToString(), mute.ToString()};
        }

        protected override float DestroyTime => 0f;

        public float StartPosition
        {
            get => transform.localPosition.x;
            set => transform.localPosition = new Vector3(value, transform.localPosition.y, transform.localPosition.z);
        }
        public float EndPosition { get => transform.localPosition.x + Duration; set => endTime = value - transform.localPosition.x; }
        public float Duration => (float) (endTime - startTime);
    }
}
