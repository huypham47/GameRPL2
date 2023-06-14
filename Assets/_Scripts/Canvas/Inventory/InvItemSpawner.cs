using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InvItemSpawner : Spawner
{
    private static InvItemSpawner instance;
    public static InvItemSpawner Instance { get => instance; }
    public static string itemNormal = "UIInvItem";

    [SerializeField] protected UIInventoryCtrl inventoryCtrl;
    public UIInventoryCtrl UIInventoryCtrl => inventoryCtrl;

    protected override void Awake()
    {
        base.Awake();
        if (InvItemSpawner.instance != null) return;
        InvItemSpawner.instance = this;
    }

    

    protected override void LoadHolder()
    {
        this.LoadUIInventoryCtrl();

        if (this.holder != null) return;
        this.holder = this.inventoryCtrl.Content;
    }

    protected virtual void LoadUIInventoryCtrl()
    {
        if (this.inventoryCtrl != null) return;
        this.inventoryCtrl = transform.parent.GetComponent<UIInventoryCtrl>();
    }
}
