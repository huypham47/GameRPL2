using System;
using UnityEngine;

public enum ItemCode
{
    NoItem = 0,
    Health = 1,
    AmmoBox = 2,
    MaxHP = 3,
}

public class ItemCodeParse
{
    public static ItemCode FromString(string itemName)
    {
        try
        {
            return (ItemCode)System.Enum.Parse(typeof(ItemCode), itemName);
        }
        catch(ArgumentException e)
        {
            Debug.Log(e.ToString());
            return ItemCode.NoItem;
        }
    }
}
