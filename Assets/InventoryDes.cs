using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDes : MonoBehaviour
{// This class is attached to DescriptionPanel obj

    public static InventoryDes inventDesInstance;
    public Image avatar;
    public TextMeshProUGUI content, heading, numberOfItem;
    public GameObject button;
    private void Awake()
    {
        inventDesInstance = this;
    }
    public void DisplayContent(string _content)
    {
        content.text = _content;
    }
    public void DisplayHeading(string _heading)
    {
        heading.text = _heading;
    }
    public void DisplayAvatar(Image _avatar)
    {
        ActiveBagInfo();
        avatar.sprite = _avatar.sprite;
    }
    public void DisplayNumItem(int _num)
    {
        numberOfItem.text = "Held: " + _num.ToString();
    }
    private void Start()
    {
        avatar.transform.parent.gameObject.SetActive(false);
    }
    public void InitBag()// Enable will inactive infor of an item
    {
        avatar.sprite = null;
        avatar.transform.parent.gameObject.SetActive(false);

        content.text = "";
        content.gameObject.SetActive(false);
        heading.text = "";
        heading.gameObject.SetActive(false);

        numberOfItem.text = "";
        numberOfItem.gameObject.SetActive(false);
        button.SetActive(false);
    }
    void ActiveBagInfo()
    {
        avatar.transform.parent.gameObject.SetActive(true);
        content.gameObject.SetActive(true);
        heading.gameObject.SetActive(true);
        numberOfItem.gameObject.SetActive(true);
        button.SetActive(true);
    }

    public void UseItem()
    {
        if(heading.text == "Health")
        {
            Debug.Log("Use HP item");
        }
        if (heading.text == "Mana")
        {
            Debug.Log("Use mana item");
        }
        if (heading.text == "Gold")
        {
            Debug.Log("Use gold item");
        }
        if (heading.text == "Stone")
        {
            Debug.Log("Use Stone item");
        }
        if (heading.text == "Four-leaf Clover")
        {
            Debug.Log("Use Clover item");
        }
        if (heading.text == "Key")
        {
            Debug.Log("Use key item");
        }
        if (heading.text == "Skull")
        {
            Debug.Log("Use skull item");
        }
        if (heading.text == "Boost")
        {
            Debug.Log("Use Boost item");
        }
        Bag.bagInstance.ListItem[heading.text]--;
        numberOfItem.text = "Held: " + Bag.bagInstance.ListItem[heading.text];
        if (Bag.bagInstance.ListItem[heading.text] <= 0)
        {
            
            Bag.bagInstance.RemoveItem(heading.text);
            InitBag();
        }
    }
    public void DropItem()
    {

    }
}
