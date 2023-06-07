using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : _MonoBehaviour
{
    [SerializeField] protected ItemDespawn itemDespawn;
    public ItemDespawn ItemDespawn => itemDespawn;

    [SerializeField] protected ItemProfileSO itemS0;
    public ItemProfileSO ItemSO => itemS0;

    
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadItemDespawn();
        this.LoadItemProfileSO();
    }

   

    protected virtual void LoadItemDespawn()
    {
        if (this.itemDespawn != null) return;
        this.itemDespawn = GetComponentInChildren<ItemDespawn>();
    }

    protected virtual void LoadItemProfileSO()
    {
        if (this.itemS0 != null) return;
        string resPath = "ItemProfiles/" + transform.name;
        this.itemS0 = Resources.Load<ItemProfileSO>(resPath);
    }
}
