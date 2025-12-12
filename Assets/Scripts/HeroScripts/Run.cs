using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class Run : MonoBehaviour
{
    private float currentEnergy = 100f;
    private float maxEnergy = 100f;
    private bool runButtonIsActive = false;
    [SerializeField] private Image energyScale;
    [SerializeField] private Move move;
    [SerializeField] private UserInput characterPosition;
    private int increaseEnergy = 3;
    private int decreaseEnergy = 7;
    private int walkSpeed = 10;
    private int runSpeed = 15;

    private void Update()
    {
        bool isMoving = Mathf.Abs(characterPosition.vc.x) >= 0.1f || Mathf.Abs(characterPosition.vc.y) >= 0.1f;

        if (runButtonIsActive && isMoving)
        {
            if (energyScale.fillAmount <= 0)
            {
                move.speed = walkSpeed;
                RunButtonIsNotActive();
            }
            currentEnergy -= decreaseEnergy * Time.deltaTime;
        }
        else if (!runButtonIsActive || !isMoving)
        {
            currentEnergy += increaseEnergy * Time.deltaTime;
        }
        currentEnergy = Mathf.Clamp(currentEnergy, 0, maxEnergy);
        energyScale.fillAmount = currentEnergy / maxEnergy;
    }
    public void RunButtonIsActive()
    {
        runButtonIsActive = true;
        move.speed = runSpeed;
    }
    public void RunButtonIsNotActive()
    {
        runButtonIsActive = false;
        move.speed = walkSpeed;
    }
}
