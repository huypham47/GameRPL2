using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class ItemLooter : ItemAbstract
{
    [SerializeField] protected BoxCollider boxCollider;
    [SerializeField] protected Rigidbody _rigidbody;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadTrigger();
        this.LoadRigibody();
    }


    protected virtual void LoadTrigger()
    {
        if (this.boxCollider != null) return;
        this.boxCollider = transform.GetComponent<BoxCollider>();
        this.boxCollider.isTrigger = true;
    }

    protected virtual void LoadRigibody()
    {
        if (this._rigidbody != null) return;
        this._rigidbody = transform.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        ItemPickupable itemPickupable = other.transform.GetComponent<ItemPickupable>();
        if (itemPickupable == null) return;

        ItemCode itemCode = itemPickupable.GetItemCode();
        ItemInventory itemInventory = itemPickupable.ItemCtrl.ItemInventory;

        if (this.inventory.AddItem(itemInventory))
        {
            itemPickupable.Picked();
        }
    }


}
