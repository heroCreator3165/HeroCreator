using System.Collections.Generic;
using UnityEngine;

namespace FileHandling.Loading.BMP
{
    public class BMPImage
    {
        public BMPFileHeader header;
        public BitmapInfoHeader info;
        public uint rMask = 0x00FF0000;
        public uint gMask = 0x0000FF00;
        public uint bMask = 0x000000FF;
        public uint aMask = 0x00000000;
        public List<Color32> palette;
        public Color32[] imageData;
        public Texture2D ToTexture2D()
        {
            var tex = new Texture2D(info.absWidth, info.absHeight);
            tex.SetPixels32(imageData);
            tex.Apply();
            return tex;
        }
    }
}