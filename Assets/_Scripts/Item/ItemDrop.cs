using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : ItemAbstract
{
    protected override void Start()
    {
        base.Start();
        Invoke(nameof(this.Test), 5f);
    }

    protected virtual void Test()
    {
        Vector3 pos = transform.position - transform.forward * 100;

        this.DropItemIndex(1, pos, transform.rotation);
    }

    protected virtual void DropItemIndex(int itemIndex, Vector3 pos, Quaternion rot)
    {
        ItemInventory itemInventory = this.inventory.Items[itemIndex];
        this.inventory.Items.RemoveAt(itemIndex);
        ItemDropSpawner.Instance.Drop(itemInventory, pos, rot);
    }
}
