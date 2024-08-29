using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu()]
public class ItemScriptObject : ScriptableObject
{
    public int id;
    public string Name;
    public string Description;
    public string Icon;
    public GameObject Prefeb;
    public ItemType ItemType;
    public List<ItemProperty> PropertyList;
}

public enum ItemType
{ 
    Weapon,
    Consumable,
}

public class ItemProperty
{
    public ItemProperty PropertyType;
    public int Value;
}

public enum PropertyType
{ 
    HP,
    Attack,
    Energy,
    Defence,
    MP,
    Speed
}