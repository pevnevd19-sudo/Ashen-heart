using System.Collections.Generic;
using UnityEngine;

public class Parralax : MonoBehaviour
{
    private float startpos, length;
    [SerializeField] private Camera cam;
    [SerializeField] private float speedParralax;
    [SerializeField] private List<GameObject> BackGround;

    private void Start()
    {
        BackGround.Add(gameObject);
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x - 2;
    }
    private void FixedUpdate()
    {
        float distance = (cam.transform.position.x * speedParralax);
        transform.position = new Vector3(startpos + distance, transform.position.y, transform.position.z);
    }
   
}
