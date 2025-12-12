using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class TriggerInvisibleOff : MonoBehaviour
{
    [SerializeField]private PeopleInvisible peopleInvisible;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<PeopleInvisible>() != null)
        {
            peopleInvisible.RandomSpawn();
        }
    }

}
