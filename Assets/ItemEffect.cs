using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ItemEffect : MonoBehaviour, IEndDragHandler, IDragHandler, IBeginDragHandler
{
    // This class is attached to item UI

    [HideInInspector]
    public Transform window_panel;
    public string nameItem;// used for AddItem method in Bag class and must be the same as nameItem in ItemEffect class
    public int numberHeld = 1;

    [TextArea(1,10)]
    public string textItem;
    public void OnBeginDrag(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().raycastTarget = false;
        window_panel = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(window_panel);
        gameObject.GetComponent<Image>().raycastTarget = true;
    }
}
