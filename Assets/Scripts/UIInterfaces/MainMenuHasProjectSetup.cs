using System.Collections;
using System.Collections.Generic;
using UI.UIComponents;
using UnityEngine;

public class MainMenuHasProjectSetup : MonoBehaviour
{
    [SerializeField] private Transform _buttonParent;

    private void Start()
    {
        if (ProjectController.Instance.HasProject)
        {
            _buttonParent.gameObject.SetActive(true);
            GetComponent<TabPanel>()?.Jump();
        }
    }
}
