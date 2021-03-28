using System.IO;
using FileHandling.Loading.BMP;
using UnityEngine;

namespace FileHandling.Loading
{
    public static class ImageLoader
    {
        public static Texture2D GetTexture(string url)
        {

            if (File.Exists(url))
            {
                if (url.EndsWith(".jpg") || url.EndsWith(".png"))
                    return JpgPngToTexture(url);
                if (url.EndsWith(".bmp"))
                    return BmPToTexture(url);
            }

            Debug.Log($"File {url} does not exist !");
            return null;
        }

        public static Texture2D JpgPngToTexture(string filePath)
        {
            Texture2D tex = null;
            byte[] fileData;
            fileData = File.ReadAllBytes(filePath);
            tex = new Texture2D(2, 2);
            tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
            return tex;
        }

        public static Texture2D BmPToTexture(string filePath)
        {
            Texture2D tex = null;
            byte[] fileData;

            fileData = File.ReadAllBytes(filePath);

            BMPLoader bmpLoader = new BMPLoader();
            //bmpLoader.ForceAlphaReadWhenPossible = true; //Uncomment to read alpha too

            //Load the BMP data
            BMPImage bmpImg = bmpLoader.LoadBMP(fileData);

            //Convert the Color32 array into a Texture2D
            tex = bmpImg.ToTexture2D();
            return tex;
        }
    }
}