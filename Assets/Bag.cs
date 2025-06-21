using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bag : MonoBehaviour // attach for InventoryPanel, used for adding items
{
    public static Bag bagInstance;

    // Hold the info of items
    [HideInInspector]
    public Dictionary<string, int> ListItem = new Dictionary<string, int>();

    // This is used for find the proper image of item added
    public List<Image> ListUI = new List<Image>();

    // this is attached to ListPanel obj, used for getting ItemSlot's child
    public GameObject listPanel;

    private void Awake()
    {
        bagInstance = this;
    }
    private void Start()
    {
        gameObject.SetActive(false);
    }
    
    public void AddItem(string name_item)
    {

        try
        {
            // if itemSlot is empty
            ListItem.Add(name_item, 1);
            Image addImg = null;
            foreach (Image findImg in ListUI)// used for finding proper image in ListUI
            {
                if (findImg.GetComponent<ItemEffect>().nameItem.Equals(name_item))
                {
                    addImg = Instantiate(findImg);
                    break;
                }
            }

            // Attach image found above to Bag UI
            if (addImg != null)
            {
                for (int i = 0; i < listPanel.transform.childCount; i++)
                {
                    if (listPanel.transform.GetChild(i).childCount == 0)
                    {
                        addImg.transform.SetParent(listPanel.transform.GetChild(i));
                        addImg.transform.localScale = Vector3.one;
                        break;
                    }
                }
            }

        }
        // if item exists
        catch (ArgumentException ex)
        {
            
            ListItem[name_item]++;

            // find item and increase numHeld
            for(int i = 0; i < listPanel.transform.childCount; i++)
            {
                ItemEffect getItem = listPanel.transform.GetChild(i).GetChild(0).GetComponent<ItemEffect>();
                if (getItem.nameItem.Equals(name_item))
                {
                    getItem.numberHeld = ListItem[name_item];
                    break;
                }
            }
            
        }
        Debug.Log(name_item + ":" + ListItem[name_item].ToString()); 
    }
    public void RemoveItem(string name_item)// Used in InventoryDes class
    {
        for(int i = 0; i < listPanel.transform.childCount; i++)
        {
            GameObject remove_item = listPanel.transform.GetChild(i).gameObject;
            if (remove_item.transform.childCount != 0)
            {
                Debug.Log("child count != 0");
                if (remove_item.transform.GetChild(0).GetComponent<ItemEffect>().nameItem.Equals(name_item))
                {
                    Destroy(remove_item.transform.GetChild(0).gameObject);
                    Debug.Log("destroy"); 
                    return;
                }
            }
        }
    }
}
