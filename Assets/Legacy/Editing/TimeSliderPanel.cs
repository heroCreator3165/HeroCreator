using Legacy.Playing.Cursor;
using UnityEngine;
using Slider = UnityEngine.UI.Slider;

namespace Legacy.Editing
{
    public class TimeSliderPanel : MonoBehaviour
    {
        [SerializeField] private Slider slider;

        private void Start()
        {
            ElementHolder.Instance.OnIndexChanged += ChangeMax;
            TimeCursor.Instance.OnTick += SetValue;
        }

        private void SetValue(float value)
        {
            slider.value = value;
        }

        private void ChangeMax(float maxpos)
        {
            slider.maxValue = maxpos + 20f;
        }

        public void UpdateCursor(float value)
        {
            TimeCursor.Instance.CurrentTime = value;
        }
    }
}
