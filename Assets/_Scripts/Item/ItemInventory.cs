using System;
using UnityEngine;

[Serializable]
public class ItemInventory
{
    public ItemProfileSO itemProfileSO;
    public int itemCount = 0;
    public int maxStack = 7;
    public int upgradeLevel = 0;
}
