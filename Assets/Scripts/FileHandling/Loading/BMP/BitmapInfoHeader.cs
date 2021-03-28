﻿using UnityEngine;

namespace FileHandling.Loading.BMP
{
    public struct BitmapInfoHeader
    {
        public uint size;
        public int width;
        public int height;
        public ushort nColorPlanes; // always 1
        public ushort nBitsPerPixel; // [1,4,8,16,24,32]
        public BMPComressionMode compressionMethod;
        public uint rawImageSize; // can be "0"
        public int xPPM;
        public int yPPM;
        public uint nPaletteColors;
        public uint nImportantColors;

        public int absWidth { get { return Mathf.Abs(width); } }
        public int absHeight { get { return Mathf.Abs(height); } }

    }
}