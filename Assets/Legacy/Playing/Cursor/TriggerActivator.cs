using Legacy.Playing.Elements;
using UnityEngine;

namespace Legacy.Playing.Cursor
{
    public class TriggerActivator : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            if (GetComponent<Rigidbody2D>() == null)
            {
                gameObject.AddComponent<Rigidbody2D>();
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!enabled) return;

            var element = other.GetComponent<PlayElement>();
            element?.Play();
        }
    }
}
