using Legacy.Playing.Cursor;
using Legacy.Playing.Players;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Legacy
{
    public class KeyBoardInput : MonoBehaviour
    {
        private void FixedUpdate()
        {
            if (Input.GetKeyUp(KeyCode.Escape))
                SceneManager.LoadScene(0);
            if (Input.GetKeyUp(KeyCode.Space))
            {
                TogglePause();
            }
        }

        private void TogglePause()
        {
            var paused = TimeCursor.Instance.IsRunning;
            if (paused)
            {
                TimeCursor.Instance.Play();
                VideoPanel.Instance.Resume();
            }
            else
            {
                TimeCursor.Instance.Pause();
                VideoPanel.Instance.Pause();
            }
        }
    }
}
