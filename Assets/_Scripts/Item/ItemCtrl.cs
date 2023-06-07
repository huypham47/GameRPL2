using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : _MonoBehaviour
{
    [SerializeField] protected ItemDespawn itemDespawn;
    public ItemDespawn ItemDespawn => itemDespawn;
    [SerializeField] protected ItemInventory itemInventory;
    public ItemInventory ItemInventory => itemInventory;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadItemDespawn();
        this.LoadItemInventory();
    }

    private void OnEnable()
    {
        this.ResetItem();
    }

    public virtual void SetItemInventory(ItemInventory itemInventory)
    {
        this.itemInventory = itemInventory.Clone();
    }

    protected virtual void LoadItemDespawn()
    {
        if (this.itemDespawn != null) return;
        this.itemDespawn = GetComponentInChildren<ItemDespawn>();
    }

    protected virtual void LoadItemInventory()
    {
        if (this.itemInventory.itemProfileSO != null) return;
        ItemCode itemCode = ItemCodeParse.FromString(transform.name);
        ItemProfileSO itemProfileSO = ItemProfileSO.FindByItemCode(itemCode);
        this.itemInventory.itemProfileSO = itemProfileSO;
        this.ResetItem();
    }

    protected virtual void ResetItem()
    {
        this.itemInventory.itemCount = 1;
        this.itemInventory.upgradeLevel = 0;

    }
}
