using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAbstract : _MonoBehaviour
{
    [SerializeField] protected Inventory inventory;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadInventory();
    }

    protected virtual void LoadInventory()
    {
        if (this.inventory != null) return;
        this.inventory = transform.parent.GetComponent<Inventory>();
    }
}
