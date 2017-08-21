using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public string[] items;
    public List<Items> inv = new List<Items>();

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
        //items = itemData.Split(';');
        items = itemData.Split(';');

        for (int i = 0; i < items.Length; i++)
        {
            inv.Add(CreateItem.CreateAndSplitItem(items[i]));
            Debug.Log(inv[i].Damage);
        }
    }

}
