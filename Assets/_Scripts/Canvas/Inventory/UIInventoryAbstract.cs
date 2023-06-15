using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryAbstract : _MonoBehaviour
{
    [SerializeField] protected UIInventoryCtrl inventoryCtrl;
    public UIInventoryCtrl UIInventoryCtrl => inventoryCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadUIInventoryCtrl();
    }
    protected virtual void LoadUIInventoryCtrl()
    {
        if (this.inventoryCtrl != null) return;
        this.inventoryCtrl = transform.parent.GetComponent<UIInventoryCtrl>();
    }
}
