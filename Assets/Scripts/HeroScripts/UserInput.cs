using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    public Vector2 vc;
    [SerializeField] Move mv;
    private void Update()
    {
        vc = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
        mv.setdirection (vc);
    }
}
