using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MusicChanger : MonoBehaviour
{
    [SerializeField] AudioSource musicVariable;

    private void Start()
    {
        if (musicVariable == null)
        {
            musicVariable = GetComponent<AudioSource>();
        }
        
    }
    private void Update()
    {
        
    }
}
