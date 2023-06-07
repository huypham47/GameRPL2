using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class ItemPickupable : _MonoBehaviour
{
    [SerializeField] protected BoxCollider collider;

    [SerializeField] protected ItemCtrl itemCtrl;
    public ItemCtrl ItemCtrl => itemCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBoxCollider();
        this.LoadItemCtrl();
    }

    protected virtual void LoadItemCtrl()
    {
        if (this.itemCtrl != null) return;
        this.itemCtrl = transform.parent.GetComponent<ItemCtrl>();
    }

    public static ItemCode String2ItemCode(string itemName)
    {
        return (ItemCode)System.Enum.Parse(typeof(ItemCode), itemName);
    }

    protected virtual void LoadBoxCollider()
    {
        if (this.collider != null) return;
        this.collider = GetComponent<BoxCollider>();
    }

    public virtual ItemCode GetItemCode()
    {
        return ItemPickupable.String2ItemCode(transform.parent.name);
    }

    public virtual void Picked()
    {
        this.itemCtrl.ItemDespawn.DespawnObject();
    }
}
