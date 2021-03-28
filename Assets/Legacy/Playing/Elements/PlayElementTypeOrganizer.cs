using System;
using System.Linq;
using UnityEngine;

namespace Legacy.Playing.Elements
{
    internal static class PlayElementTypeOrganizer
    {
        public static readonly Type[] Types;

        static PlayElementTypeOrganizer()
        {
            Types = typeof(PlayElement)
                .Assembly.GetTypes()
                .Where(t => t.IsSubclassOf(typeof(PlayElement)) && !t.IsAbstract).ToArray();
        }

        public static PlayElement GetElement(string className)
        {
            var type = Types.First(x => x.Name == className);
            if (type == null)
            {
                Debug.Log($"Type : {className} could not be parsed.");
                return null;
            }

            var go = new GameObject(className);
            var playElement = go.AddComponent(type);
            return playElement as PlayElement;
        }
    }
}