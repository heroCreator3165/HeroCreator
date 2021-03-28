using System.Collections;
using Misc;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace Legacy.Playing.Players
{
    public class VideoPanel : Singleton<VideoPanel>
    {
        [SerializeField] private VideoPlayer _videoPlayer;
        [SerializeField] private RenderTexture _renderTexture;
        [SerializeField] private RawImage _displayImage;
        [SerializeField] private AudioSource _audioSource;

        public void Setup()
        {
            _videoPlayer.playOnAwake = false;
            _videoPlayer.Stop();

            _videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
            _audioSource = GetComponent<AudioSource>() ?? gameObject.AddComponent<AudioSource>();
            _videoPlayer.SetTargetAudioSource(0, _audioSource);

            _videoPlayer.renderMode = VideoRenderMode.RenderTexture;
            _videoPlayer.targetTexture = _renderTexture;
            _displayImage.texture = _renderTexture;

            _renderTexture.Release();
        }

        public void PlayVideo(string videoUrl, double startTime = 0, double endTime = double.MaxValue)
        {
            Setup();
            //Setup Ratio
            _videoPlayer.url = videoUrl;
            _videoPlayer.Play();
            

            _videoPlayer.time = startTime;
            if (endTime != double.MaxValue && this.isActiveAndEnabled)
            {
                StartCoroutine(StopAfterFrame(endTime));
            }

            Show();
        }

        public void SetMute(bool mute)
        {
            _audioSource.mute = mute;
        }

        public void Pause()
        {
            _videoPlayer.Pause();
        }

        public void Resume()
        {
            _videoPlayer.Play();
        }

        //TODO Optimize to wait by seconds => fps and framedistance could yield return seconds to wait
        private IEnumerator StopAfterFrame(double endTime)
        {
            bool play = true;
            while (play)
            {
                if (_videoPlayer.time >= endTime)
                    break;


                yield return new WaitForSeconds((float)(endTime -_videoPlayer.time));
            }
            _videoPlayer.Stop();
            _videoPlayer.clip = null;
            Reset();
        }

        private void Reset()
        {
            _renderTexture.Release();
            Setup();
            StopAllCoroutines();
        }

        public void Hide()
        {
            StopAllCoroutines();
            _displayImage.color = Color.clear;
            _renderTexture.Release();
        }

        public void Show() => _displayImage.color = Color.white;
    }
}
