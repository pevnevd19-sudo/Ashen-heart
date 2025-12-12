using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

public class CloudRightRandomAnim : MonoBehaviour
{
    public RectTransform cloud;
    private int speed;
    private int rightLimit=565;
    private int leftLimit=-630;

    private int direction = 1;


    private void Start()
    {
        if (cloud == null)
            cloud = GetComponent<RectTransform>();
        speed = Random.Range(5,10);
    }
    private void Update()
    {

        Vector2 pos = cloud.anchoredPosition;
        pos.x += speed * direction * Time.deltaTime;
        cloud.anchoredPosition = pos;

        if (pos.x>=rightLimit)
        {
            direction = -1;
            speed = Random.Range(5, 10);
        }
        else if (pos.x<=leftLimit)
        {
            direction = 1;
            speed = Random.Range(5, 10);
        }

    }
}
