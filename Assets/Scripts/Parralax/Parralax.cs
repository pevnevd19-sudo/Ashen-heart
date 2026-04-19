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
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    private void FixedUpdate()
    {
        float distance = (cam.transform.position.x * speedParralax);

        transform.position = new Vector3(startpos + distance, transform.position.y, transform.position.z);
        SpawnBack();
    }
    private void SpawnBack()
    {
        if (cam.transform.position.x > cam.transform.position.x + 30)
        {
            Instantiate(BackGround[0], new Vector3(transform.position.x + 40, transform.position.y), Quaternion.identity);
            BackGround.Add(gameObject);
            Destroy(BackGround[0]);
            BackGround.RemoveAt(0);
        }
    }
}
