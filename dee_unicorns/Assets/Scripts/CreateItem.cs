using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateItem : MonoBehaviour
{

    public static Items CreateAndSplitItem(string ItemId)
    {
        string[] items = ItemId.Split('|');

        Items temp = new Items();

        int id = System.Convert.ToInt32(items[0]);
        string name = items[1];
        int clipSize = System.Convert.ToInt32(items[2]);
        float damage = float.Parse(items[3]);
        float fireRate = float.Parse(items[4]);
        float weaponRange = float.Parse(items[5]);
        int weight = System.Convert.ToInt32(items[6]);
        string ammoType = items[7];
        string iconName = items[8];
        string modelName = items[9];

        temp.Name = name;
        temp.AmmoType = ammoType;
        temp.ModelName = modelName;
        temp.IconName = Resources.Load("Icons/" + iconName) as Texture2D;
        temp.Damage = damage;
        temp.FireRate = fireRate;
        temp.WeaponRange = weaponRange;
        temp.Weight = weight;
        temp.Id = id;
        temp.ClipSize = clipSize;

        return temp;
    }

}
