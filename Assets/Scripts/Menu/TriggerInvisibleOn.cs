using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInvisibleOn : MonoBehaviour
{
    [SerializeField] private PeopleInvisible peopleInvisible;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<PeopleInvisible>() != null)
        {
            peopleInvisible.PeopleInvisibleOn();
        }
    }
}
