using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInform : UIPlayerAbstract
{
    private static UIInform instance;
    public static UIInform Instance => instance;
    [SerializeField] protected bool isOpen = true;
    public bool IsOpen => isOpen;

    protected override void Awake()
    {
        base.Awake();
        if (UIInform.instance != null) return;
        UIInform.instance = this;
    }

    protected override void Start()
    {
        base.Start();
        this.Toggle();
    }

    public virtual void Toggle()
    {
        this.isOpen = !this.isOpen;
        if (this.isOpen) Open();
        else this.Close();
    }

    public virtual void Open()
    {
        RectTransform rt = UIInventoryCtrl.Instance.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(700, 750);
        rt.anchoredPosition = new Vector3(700, 17, 0);
        this.playerCtrl.SetAlphaCanvas(1);
        //this.ShowItems();
    }

    public virtual void Close()
    {
        RectTransform rt = UIInventoryCtrl.Instance.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(1150, 750);
        rt.anchoredPosition = new Vector3(960, 17, 0);
        this.playerCtrl.SetAlphaCanvas(0);

    }

    //public virtual void ShowItems()
    //{
    //    if (!isOpen) return;

    //    this.ClearItems();

    //    List<ItemInventory> items = PlayerCtrl.Instance.Inventory.Items;
    //    InvItemSpawner spawner = this.inventoryCtrl.InvItemSpawner;

    //    for (int i = 0; i < items.Count; i++)
    //    {
    //        spawner.SpawnItem(items[i]);
    //    }
    //    this.SortItem();
    //}

    //protected virtual void SortItem()
    //{
    //    switch (inventorySort)
    //    {
    //        case InventorySort.SortByName:
    //            this.SortByName();
    //            break;
    //        case InventorySort.SortByCount:
    //            break;
    //        default:
    //            break;
    //    }
    //}

    //protected virtual void SortByName()
    //{
    //    int itemCount = this.inventoryCtrl.Content.childCount;

    //    Transform currentItem, nextItem;
    //    UIItemInventory currentUItem, nextIUIItem;
    //    ItemProfileSO currentProfile, nextProfile;
    //    string currentName, nextName;
    //    bool isSorting = false;

    //    for (int i = 0; i < itemCount - 1; i++)
    //    {
    //        currentItem = this.inventoryCtrl.Content.GetChild(i);
    //        nextItem = this.inventoryCtrl.Content.GetChild(i + 1);

    //        currentUItem = currentItem.GetComponent<UIItemInventory>();
    //        nextIUIItem = nextItem.GetComponent<UIItemInventory>();

    //        currentProfile = currentUItem.ItemInventory.itemProfileSO;
    //        nextProfile = nextIUIItem.ItemInventory.itemProfileSO;

    //        currentName = currentProfile.itemName;
    //        nextName = nextProfile.itemName;

    //        int compare = string.Compare(currentName, nextName);

    //        if (compare == 1)
    //        {
    //            this.SwapItem(currentItem, nextItem);
    //            isSorting = true;
    //        }
    //    }

    //    if (isSorting) this.SortByName();
    //}

    //protected virtual void SwapItem(Transform currentItem, Transform nextItem)
    //{
    //    int currentIndex = currentItem.GetSiblingIndex();
    //    int nextIndex = nextItem.GetSiblingIndex();

    //    currentItem.SetSiblingIndex(nextIndex);
    //    nextItem.SetSiblingIndex(currentIndex);
    //}

    //protected virtual void ClearItems()
    //{
    //    this.inventoryCtrl.InvItemSpawner.ClearItems();
    //}
}
