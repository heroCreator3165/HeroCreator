using UnityEngine;

namespace FileHandling.Loading
{
    public static class AudioClipLoader
    {
        public static AudioClip LoadClip(string path)
        {
            if (path.EndsWith(".wav"))
            {
                return new WWW(path).GetAudioClip(false, true, AudioType.WAV);
            }
            if (path.EndsWith(".mp3"))
            {
                return new WWW(path).GetAudioClip(false, true, AudioType.MPEG);
            }

            return null;
        }
    }
}