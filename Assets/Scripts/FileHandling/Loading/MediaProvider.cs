using System;
using System.Collections.Generic;
using System.IO;
using FileHandling.Loading;
using UnityEngine;

public static class MediaProvider
{
    private static Dictionary<Type, Dictionary<string, object>> resources = new Dictionary<Type, Dictionary<string, object>>();

    public static T GetResource<T>(string path)
    {
        if (path == null || !File.Exists(path))
        {
            Debug.Log($"File {path} is not available !");
            return default;
        }

        Dictionary<string, object> dictionary;
        if (resources.ContainsKey(typeof(T)))
        {
            dictionary = resources[typeof(T)];
        }
        else
        {
            dictionary = new Dictionary<string, object>();
            resources.Add(typeof(T), dictionary);
        }

        if (dictionary.ContainsKey(path))
        {
            var value = dictionary[path];
            return (T)Convert.ChangeType(value, typeof(T));
        }

        var resource = LoadFile(path);
        if (resource == null)
        {
            Debug.Log($"Resource not found {path} !");
            return default;
        }

        dictionary.Add(path, resource);
        return (T)Convert.ChangeType(resource, typeof(T));
    }

    private static object LoadFile(string path)
    {
        if (EndsWith(path, ".png", ".jpg", ".bmp"))
            return ImageLoader.GetTexture(path);
        if (EndsWith(path, ".mp3", ".wav"))
            return AudioClipLoader.LoadClip(path);
        return null;
    }

    private static bool EndsWith(string str, params string[] endings)
    {
        foreach (var ending in endings)
        {
            if (str.EndsWith(ending))
                return true;
        }

        return false;
    }
}