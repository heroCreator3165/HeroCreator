using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Legacy.Menu
{
    public class MenuFunctions : MonoBehaviour
    {
        [SerializeField] private Text fileTextBlock;

        [SerializeField] private Button PlayButton;
        [SerializeField] private Button RecordButton;


        public void SelectFile()
        {
            ProjectfileParser.Instance.SelectPath();
            var valid = ProjectfileParser.Instance.HasValidPath;
            if (valid)
            {
                fileTextBlock.text = ProjectfileParser.Instance.filePath;
            }

            PlayButton.interactable = valid;
            RecordButton.interactable = valid;
        }

        public void Play()
        {
            if (!ProjectfileParser.Instance.HasValidPath)
                return;
            SceneManager.LoadScene(1);
        }

        public void Record()
        {

        }
    }
}
