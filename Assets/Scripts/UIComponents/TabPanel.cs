using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace UI.UIComponents
{
    public class TabPanel : MonoBehaviour
    {
        [SerializeField] private Button _buttonPrefab;
        [SerializeField] private GameObject _contentParent;
        [SerializeField] private GameObject _buttonParent;
        [SerializeField] private TabGroup[] _tabs;
        [SerializeField] private Color highlightColor;
        [SerializeField] private Color inactiveColor;

        public void Awake()
        {
            foreach (var tab in _tabs)
            {
                CreateTabButton(tab);
            }

            SetAllInavtive();
            _tabs.FirstOrDefault()?.SetActive();
        }

        public void CreateTabButton(TabGroup tab)
        {
            var buttonGameObject = Instantiate(_buttonPrefab, _buttonParent.transform);
            var buttonComponent = buttonGameObject.GetComponent<Button>();
            tab.button = buttonComponent;
        
            var text = buttonGameObject.GetComponentInChildren<Text>();
            text.text = tab.name;
            text.resizeTextForBestFit = true;

            buttonComponent.onClick.AddListener(SetAllInavtive);
            buttonComponent.onClick.AddListener(tab.SetActive);

            tab.highlightColor = highlightColor;
            tab.inactiveColor = inactiveColor;
        }

        private void SetAllInavtive()
        {
            foreach (var tab in _tabs)
            {
                tab.Active = false;
            }
        }

        public void Jump()
        {
            var activeIndex = 0;
            for (var i = 0; i < _tabs.Length; i++)
            {
                if (_tabs[i].Active)
                {
                    activeIndex = i + 1;
                }
            }

            if (activeIndex >= _tabs.Length) activeIndex = 0;

            SetAllInavtive();
            _tabs[activeIndex].SetActive();
        }
    }

    [System.Serializable]
    public class TabGroup
    {
        public string name;
        public GameObject element;
        [NonSerialized]
        public Button button;
        [NonSerialized]
        public Color highlightColor;
        [NonSerialized]
        public Color inactiveColor;

        public bool Active
        {
            get => element.activeSelf;
            set
            {
                button.image.color = value ? highlightColor : inactiveColor;
                element.SetActive(value);
            }
        }

        public void SetActive() => Active = true;
    }
}