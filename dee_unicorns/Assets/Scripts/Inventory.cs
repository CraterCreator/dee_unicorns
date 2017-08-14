using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public string[] items;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(LoadItemData());
    }

    IEnumerator LoadItemData()
    {
        WWW itemsUrl = new WWW("localhost/unicorns_dee/Itemdata.php");
        yield return itemsUrl;
        string itemData = itemsUrl.text;
        items = itemData.Split(';');
    }

}
