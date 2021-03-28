using Misc;
using UnityEngine;

namespace Editing
{
    [RequireComponent(typeof(DrawAudioClip), typeof(AudioSource))]
    public class AudioEditView : MonoBehaviour
    {
        public string clipPath;
        private AudioClip _clip;

        private DrawAudioClip _audioDrawer;
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioDrawer = GetComponent<DrawAudioClip>();
            _audioSource = GetComponent<AudioSource>();

            _audioSource.playOnAwake = false;
        }

        public void SetClip(string path)
        {
            _clip = MediaProvider.GetResource<AudioClip>(path);
            _audioDrawer.Draw(_clip);
        }

        public void Play()
        {
            _audioSource.Play();
        }

        public void Stop()
        {
            _audioSource.Stop();
        }

        public void SetClipTime(float start, float end)
        {

        }
    }
}