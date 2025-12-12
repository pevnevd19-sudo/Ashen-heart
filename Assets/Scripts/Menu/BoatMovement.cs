using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    [SerializeField] private RectTransform boatPosition;
    [SerializeField]private int speed;
    private int rightMaxPosition = 488;
    private int leftMaxPosition = -490;
    private int direction = 1;
    

    private void FlipBoat(int flipDirection)
    {
        Vector2 flipBoat = boatPosition.localScale;
        flipBoat.x = flipDirection;
        boatPosition.localScale = flipBoat;
    }
    private void Update()
    {
        Vector2 boatMovement = boatPosition.anchoredPosition;
        boatMovement.x += speed * direction * Time.deltaTime;
        boatPosition.anchoredPosition = boatMovement;

        if (boatPosition.anchoredPosition.x >= rightMaxPosition)
        {

            direction = -1;
            FlipBoat(-1);
        }
        if (boatPosition.anchoredPosition.x <= leftMaxPosition)
        {
            direction = 1;
            FlipBoat(1);
        }
    }
}
