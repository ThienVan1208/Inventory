using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotEffect : MonoBehaviour, IDropHandler, IPointerClickHandler
{// This class is attached to ItemSlot obj

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropItem = eventData.pointerDrag;
        if (transform.childCount != 0)
        {
            transform.GetChild(0).SetParent(dropItem.GetComponent<ItemEffect>().window_panel);
            

        }
        dropItem.GetComponent<ItemEffect>().window_panel = gameObject.transform;
        
    }

    public void OnPointerClick(PointerEventData eventData)// Click on UI to display infor of an item
    {
        if(transform.childCount != 0)
        {
            GameObject clickSlot = eventData.pointerClick;
            ItemEffect clickItem = clickSlot.transform.GetChild(0).GetComponent<ItemEffect>();
            InventoryDes.inventDesInstance.DisplayHeading(clickItem.nameItem);
            InventoryDes.inventDesInstance.DisplayContent(clickItem.textItem);
            InventoryDes.inventDesInstance.DisplayAvatar(clickItem.gameObject.GetComponent<Image>());
            InventoryDes.inventDesInstance.DisplayNumItem(clickItem.numberHeld);
        }
    }
}
