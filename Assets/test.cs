using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField] private AudioSource audio;

    private void Update()
    {
        transform.position = Vector3.right * audio.time;
    }
}
