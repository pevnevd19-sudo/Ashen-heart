using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FearScale : MonoBehaviour
{
    [SerializeField] private Image fearBar;
    [SerializeField] private Fear fear;

    private void Update()
    {
        fearBar.fillAmount = fear.CurrentFear / fear.MaxFear;
    }
}
