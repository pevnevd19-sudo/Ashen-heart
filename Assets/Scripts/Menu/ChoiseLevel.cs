using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChoiseLevel : MonoBehaviour
{
    [SerializeField] Button[] buttons;
    private void Start()
    {
        
        for (int i = 0; i <= 2; i++)
        {
            buttons[i].gameObject.SetActive(false);
        }
    }
}
