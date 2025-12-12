using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UIElements;

public class PeopleInvisible : MonoBehaviour
{
    [SerializeField] private GameObject[] peoples;
    [SerializeField] private RectTransform boatTrigger;
    void Start()
    {
        RandomSpawn();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RandomSpawn()
    {
        for (int i = 0; i < 1; i++)
        {
            i = Random.Range(0, 4);
            peoples[i] = peoples[i];
            peoples[i].SetActive(true);
            Debug.Log(i);
        }
    }
    public void PeopleInvisibleOn()
    {
        for (int i = 0; i <=3; i++)
        {
            peoples[i].SetActive(false);
        }
    }
}
