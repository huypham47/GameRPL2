using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : UIInventoryAbstract
{
    private static UIInventory instance;
    public static UIInventory Instance => instance;
    [SerializeField] protected bool isOpen = true;

    protected override void Awake()
    {
        base.Awake();
        UIInventory.instance = this;
    }

    protected override void Start()
    {
        base.Start();
        //this.Toggle();
    }

    public virtual void Toggle()
    {
        this.isOpen = !this.isOpen;
        if (this.isOpen) Open();
        else this.Close();
        GameManager.Instance.TogglePause();
    }

    public virtual void Open()
    {
        this.inventoryCtrl.gameObject.SetActive(true);
        this.ShowItems();
    }

    public virtual void Close()
    {
        this.inventoryCtrl.gameObject.SetActive(false);
    }

    public virtual void ShowItems()
    {
        if (!isOpen) return;

        this.ClearItems();

        Debug.Log("Show item");
        List<ItemInventory> items = PlayerCtrl.Instance.Inventory.Items;
        InvItemSpawner spawner = this.inventoryCtrl.InvItemSpawner;

        foreach (ItemInventory item in items)
        {
            Debug.Log(item.itemProfileSO.name);
            spawner.SpawnItem(item);
        }
    }

    protected virtual void ClearItems()
    {

        this.inventoryCtrl.InvItemSpawner.ClearItems();
        Debug.Log("ClearItems");

    }
}
