using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryCtrl : _MonoBehaviour
{
    private static UIInventoryCtrl instance;
    public static UIInventoryCtrl Instance { get => instance; }

    [SerializeField] protected UIInventory inventory;
    public UIInventory UIInventory => inventory;

    [SerializeField] protected InvItemSpawner invItemSpawner;
    public InvItemSpawner InvItemSpawner => invItemSpawner;

    [SerializeField] protected Transform content;
    public Transform Content => content;

    protected override void Awake()
    {
        base.Awake();
        if (UIInventoryCtrl.instance != null) return;
        UIInventoryCtrl.instance = this;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadInvItemSpawner();
        this.LoadContent();
        this.LoadUIInventory();
    }

    protected virtual void LoadUIInventory()
    {
        if (this.inventory != null) return;
        this.inventory = GetComponentInChildren<UIInventory>();
    }

    protected virtual void LoadInvItemSpawner()
    {
        if (this.invItemSpawner != null) return;
        this.invItemSpawner = GetComponentInChildren<InvItemSpawner>();
    }

    protected virtual void LoadContent()
    {
        if (this.content != null) return;
        this.content = transform.Find("Scroll View").Find("Viewport").Find("Content");
    }
}
