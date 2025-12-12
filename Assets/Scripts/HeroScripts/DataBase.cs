using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using static UnityEditor.Progress;

public class DataBase : MonoBehaviour
{
    [SerializeField] List<Item> items = new ();
    private void Start()
    {
        
    }
    public class Item 
    {
        int id;
        string name;
        Sprite image;
    }    
}
