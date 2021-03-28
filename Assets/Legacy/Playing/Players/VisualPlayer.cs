using Misc;
using UnityEngine;

namespace Legacy.Playing.Players
{
    public class VisualPlayer : Singleton<VisualPlayer>
    {
        private VideoPanel Video => VideoPanel.Instance;
        private ImageDisplay Image => ImageDisplay.Instance;

        public override void Awake()
        {
            Video.Hide();
            Image.Hide();
            base.Awake();
        }

        public void ShowImage(Texture texture)
        {
            Image.ShowImage(texture);
            Video.Hide();
        }

        public void ShowVideo(string videoUrl, bool mute = false, double startTime = 0, double endTime = long.MaxValue)
        {
            Video.PlayVideo(videoUrl, startTime, endTime);
            Video.SetMute(mute);
            Image.Hide();
        }
    }
}
