using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    List<ItemInventory> items= new List<ItemInventory>();
    [SerializeField] GameObject gameObjectShow;
    [SerializeField] GameObject inventoryMainObj;


    public class ItemInventory
    {
        GameObject gameobj;
        int id;
        int count;
    }
}
