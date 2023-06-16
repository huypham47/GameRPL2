using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIInventory : UIInventoryAbstract
{
    private static UIInventory instance;
    public static UIInventory Instance => instance;
    [SerializeField] protected bool isOpen = true;
    [SerializeField] protected InventorySort inventorySort = InventorySort.SortByName;

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

        List<ItemInventory> items = PlayerCtrl.Instance.Inventory.Items;
        InvItemSpawner spawner = this.inventoryCtrl.InvItemSpawner;

        foreach (ItemInventory item in items)
        {
            spawner.SpawnItem(item);
        }
        this.SortItem();
    }

    protected virtual void SortItem()
    {
        switch (inventorySort)
        {
            case InventorySort.SortByName:
                this.SortByName();
                Debug.Log("No sort");
                break;
            case InventorySort.SortByCount:
                Debug.Log("SortByCount");
                break;
            default:
                Debug.Log("SortByName");
                break;
        }
    }

    protected virtual void SortByName()
    {
        int itemCount = this.inventoryCtrl.Content.childCount;

        Transform currentItem, nextItem;
        UIItemInventory currentUItem, nextIUIItem;
        ItemProfileSO currentProfile, nextProfile;
        string currentName, nextName;
        bool isSorting = false;

        for (int i = 0; i < itemCount - 1; i++)
        {
            currentItem = this.inventoryCtrl.Content.GetChild(i);
            nextItem = this.inventoryCtrl.Content.GetChild(i+1);

            currentUItem = currentItem.GetComponent<UIItemInventory>();
            nextIUIItem = nextItem.GetComponent<UIItemInventory>();

            currentProfile = currentUItem.ItemInventory.itemProfileSO;
            nextProfile = nextIUIItem.ItemInventory.itemProfileSO;

            currentName = currentProfile.itemName;
            nextName = nextProfile.itemName;

            int compare = string.Compare(currentName, nextName);

            if(compare == 1)
            {
                this.SwapItem(currentItem, nextItem);
                isSorting = true;
            }
        }

        if (isSorting) this.SortByName();
    }

    protected virtual void SwapItem(Transform currentItem, Transform nextItem)
    {
        int currentIndex = currentItem.GetSiblingIndex();
        int nextIndex = nextItem.GetSiblingIndex();

        currentItem.SetSiblingIndex(nextIndex);
        nextItem.SetSiblingIndex(currentIndex);
    }

    protected virtual void ClearItems()
    {
        this.inventoryCtrl.InvItemSpawner.ClearItems();
    }
}
