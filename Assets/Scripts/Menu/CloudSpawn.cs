using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawn : MonoBehaviour
{
    RectTransform cloud;
    private int yMin = -2;
    private int yMax = 150;
    private int xMin = -363;
    private int xMax = 373;
    
    void Start()
    {
        if (cloud == null)
        {
            cloud = GetComponent<RectTransform>();
        }

        Vector2 position = cloud.anchoredPosition;
        position.x = Random.Range(xMin, xMax);
        position.y = Random.Range(yMin, yMax);
        cloud.anchoredPosition = position;

    }
}
