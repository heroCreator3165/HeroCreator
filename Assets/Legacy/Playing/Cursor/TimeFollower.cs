using UnityEngine;

namespace Legacy.Playing.Cursor
{
    public class TimeFollower : MonoBehaviour
    {
        [SerializeField] private Vector3 ofset = Vector3.zero;

        private void Start()
        {
            TimeCursor.Instance.OnTimerMove += Move;
        }

        private void Move(float timer)
        {
            transform.position = ofset + TimeCursor.Instance.transform.position;
        }
    }
}
