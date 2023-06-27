using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : ItemAbstract
{
    protected virtual void DropItemIndex(int itemIndex, Vector3 pos, Quaternion rot)
    {
        ItemInventory itemInventory = this.inventory.Items[itemIndex];
        this.inventory.Items.RemoveAt(itemIndex);
        ItemDropSpawner.Instance.DropFromInventory(itemInventory, pos, rot);
    }
}
