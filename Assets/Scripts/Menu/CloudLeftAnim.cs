using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CloudLeftAnim : MonoBehaviour
{
    private RectTransform cloud;
    private int rightLimit = 565;
    private int leftLimit = -630;
    private int speed;

    private int direction = -1;
    
    void Start()
    {
        if (cloud == null)
        {
            cloud = GetComponent<RectTransform>();
        }
        speed = Random.Range(5, 10);
    }
    

    
    void Update()
    {
        Vector2 position = cloud.anchoredPosition;
        position.x += speed * direction * Time.deltaTime;
        cloud.anchoredPosition = position;

        if (position.x >= rightLimit)
        {
            direction = -1;
            speed = Random.Range(5, 10);
        }
        else if (position.x <= leftLimit)
        {
            direction = 1;
            speed = Random.Range(5, 10);
        }
        
    }
}
