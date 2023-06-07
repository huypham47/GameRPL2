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
        this.DropItemIndex(1);
    }

    protected virtual void DropItemIndex(int itemIndex)
    {
        ItemInventory itemInventory = this.inventory.Items[itemIndex];
        Vector3 pos = transform.position - transform.forward*100;
        ItemDropSpawner.Instance.Drop(itemInventory, pos, transform.rotation);
    }
}
