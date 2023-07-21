using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropSpawner : Spawner
{
    private static ItemDropSpawner instance;
    public static ItemDropSpawner Instance { get => instance; }

    [SerializeField] protected float dropRate = 1;

    protected override void Awake()
    {
        base.Awake();
        if (ItemDropSpawner.instance == null) ItemDropSpawner.instance = this; ;
        
        this.SetUp();
    }

    private void FixedUpdate()
    {
        this.DespawnItem();
    }

    public void SetUp()
    {
        foreach (var prefab in prefabs)
        {
            var item = prefab.GetComponent<ItemCtrl>();
            item.itemSpawner = this;
            item.SetUp();
        }
    }

    public virtual List<ItemDropRate> Drop(List<ItemDropRate> dropLists, Vector3 pos, Quaternion rot)
    {
        List<ItemDropRate> dropItems = new List<ItemDropRate>();
        if (dropLists.Count < 1) return dropItems;
        dropItems = this.DropItems(dropLists);

        foreach(ItemDropRate item in dropItems)
        {
            ItemCode itemCode = item.itemSO.itemCode;
            Transform itemDrop = this.Spawn(itemCode.ToString(), pos, rot);
            if (itemDrop == null) continue;
            itemDrop.gameObject.SetActive(true);
        }

        return dropItems;
        //itemDrop.gameObject.SetActive(true);
    }

    public virtual Transform DropFromInventory(ItemInventory itemInventory, Vector3 pos, Quaternion rot)
    {
        ItemCode itemCode = itemInventory.itemProfileSO.itemCode;
        Transform itemDrop = this.Spawn(itemCode.ToString(), pos, rot);
        if (itemDrop == null) return null;
        itemDrop.gameObject.SetActive(true);
        ItemCtrl itemCtrl = itemDrop.GetComponent<ItemCtrl>();
        itemCtrl.SetItemInventory(itemInventory);
        return itemDrop;
    }

    protected virtual List<ItemDropRate> DropItems(List<ItemDropRate> items)
    {
        List<ItemDropRate> droppedItems = new List<ItemDropRate>();

        float rate, itemRate;
        foreach(ItemDropRate item in items)
        {
            rate = Random.Range(0, 1f);
            itemRate = item.dropRate / 100000f * this.dropRate;
            if (rate <= itemRate)
            {
                droppedItems.Add(item);

            }
        }
        return droppedItems;
    }

    protected virtual void DespawnItem()
    {
        foreach (Transform item in holder)
        {
            if (!item.gameObject.activeSelf) continue;
            if (Vector3.Distance(PlayerCtrl.Instance.transform.position, item.position) >= 30f)
            {
                Despawn(item.transform);
            }
        }
    }
}
