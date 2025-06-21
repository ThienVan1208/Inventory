using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    // This class is attached to Item Prefabs

    public string name_item;// used for AddItem method in Bag class and must be the same as nameItem in ItemEffect class
    private bool canCollect;
    
    private void CollectItem()
    {
        Bag.bagInstance.AddItem(name_item);
        Destroy(gameObject);
    }
    private void Update()
    {
        if(canCollect && Input.GetKeyDown(KeyCode.E))
        {
            CollectItem();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canCollect = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            canCollect = false;
        }
    }
}
