using UnityEngine;

namespace Legacy.Playing
{
    public class PlayOnLoad : MonoBehaviour
    {
        private void Start()
        {
            if (ProjectfileParser.Instance.HasValidPath)
            {
                ProjectfileParser.Instance.LoadAll();
            }
        }
    }
}
