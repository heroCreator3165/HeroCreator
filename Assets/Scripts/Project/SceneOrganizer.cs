using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project
{
    [CreateAssetMenu(menuName = "Create/SceneOrganizer")]
    public class SceneOrganizer : ScriptableObject
    {
        [Scene]
        [SerializeField] private string[] scenes;

        public int SceneCount => scenes.Length;

        public void LoadScene(int index)
        {
            index = index < 0 ? 0 : index;
            index = index >= SceneCount ? SceneCount - 1 : index;
            SceneManager.LoadScene(scenes[index]);
        }
    }
}