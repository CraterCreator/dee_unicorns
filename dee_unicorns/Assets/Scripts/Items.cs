using UnityEngine;

public class Items
{
    string name = "";
    string ammoType = "";
    string modelName = "";

    float damage = 0;
    float fireRate = 0;
    float weaponRange = 0;

    int weight = 0;
    int id = 0;
    int clipSize = 0;

    Texture2D iconName;

    public void Init(int ID, string weaponName)
    {
        id = ID;
        name = weaponName;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string AmmoType
    {
        get { return ammoType; }
        set { ammoType = value; }
    }

    public string ModelName
    {
        get { return modelName; }
        set { modelName = value; }
    }

    public float Damage
    {
        get { return damage; }
        set { damage = value; }
    }

    public float FireRate
    {
        get { return fireRate; }
        set { fireRate = value; }
    }

    public float WeaponRange
    {
        get { return weaponRange; }
        set { weaponRange = value; }
    }

    public int Weight
    {
        get { return weight; }
        set { weight = value; }
    }

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public int ClipSize
    {
        get { return clipSize; }
        set { clipSize = value; }
    }

    public Texture2D IconName
    {
        get { return iconName; }
        set { iconName = value; }
    }
}
