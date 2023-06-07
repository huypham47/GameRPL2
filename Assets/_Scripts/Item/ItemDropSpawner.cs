using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropSpawner : Spawner
{
    private static ItemDropSpawner instance;
    public static ItemDropSpawner Instance { get => instance; }

    public static string enemyOne = "Enemy_2";

    protected override void Awake()
    {
        base.Awake();
        if (ItemDropSpawner.instance != null) return;
        ItemDropSpawner.instance = this;
    }

    public virtual void Drop(List<DropRate> dropLists, Vector3 pos, Quaternion rot)
    {
        ItemCode itemCode = dropLists[0].itemSO.itemCode;
        Transform itemDrop = this.Spawn(itemCode.ToString(), pos, rot);
        //itemDrop.gameObject.SetActive(true);
    }

    public virtual void Drop(ItemInventory itemInventory, Vector3 pos, Quaternion rot)
    {
        ItemCode itemCode = itemInventory.itemProfileSO.itemCode;
        Transform itemDrop = this.Spawn(itemCode.ToString(), pos, rot);

        Debug.Log(itemDrop.name);

        itemDrop.gameObject.SetActive(true);
    }
}
