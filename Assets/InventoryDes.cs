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
        avatar.transform.parent.gameObject.SetActive(false);
        content.gameObject.SetActive(false);
        heading.gameObject.SetActive(false);
        numberOfItem.gameObject.SetActive(false);
    }
    void ActiveBagInfo()
    {
        avatar.transform.parent.gameObject.SetActive(true);
        content.gameObject.SetActive(true);
        heading.gameObject.SetActive(true);
        numberOfItem.gameObject.SetActive(true);
    }
}
