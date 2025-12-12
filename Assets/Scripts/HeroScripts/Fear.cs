using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Fear : MonoBehaviour
{
    private bool isInFearZone = false;
    private Fear fear;
    private float currentFear = 0;
    private float maxFear = 100;
    private float fearIncraseSpeed = 10;
    private float fearDecreaseSpeed = 2;

    public float CurrentFear { get => currentFear; }
    public float MaxFear { get => maxFear; }

    private void Update()
    {
        if (isInFearZone == true)
        {
            currentFear += fearIncraseSpeed * Time.deltaTime;
        }
        else if (isInFearZone == false)
        {
            currentFear -= fearDecreaseSpeed * Time.deltaTime;
        }
        currentFear = Mathf.Clamp(currentFear, 0, maxFear);
    }

    
    private void OnTriggerEnter2D(Collider2D fearArea)
    {
        if (fearArea.CompareTag("FearArea"))
        {
            isInFearZone = true;
        }
    }


    private void OnTriggerExit2D(Collider2D fearArea)
    {
        if (fearArea.CompareTag("FearArea"))
        {
            isInFearZone = false;
        }
    }
}
