﻿namespace FileHandling.Loading.BMP
{
    public struct BMPFileHeader
    {
        public ushort magic; // "BM"
        public uint filesize;
        public uint reserved;
        public uint offset;
    }
}