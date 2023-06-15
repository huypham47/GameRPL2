using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIItemInventory : _MonoBehaviour
{
    [SerializeField] protected TMP_Text itemName;
    public TMP_Text ItemName => itemName;

    [SerializeField] protected TMP_Text itemCount;
    public TMP_Text ItemCount => itemCount;

    [SerializeField] protected Image  itemImage;
    public Image ItemImage => itemImage;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadItemName();
        this.LoadItemImage();
        this.LoadItemCount();
    }

    protected virtual void LoadItemName()
    {
        if (this.itemName != null) return;
        this.itemName = transform.Find("ItemName").GetComponent<TMP_Text>();
    }

    protected virtual void LoadItemCount()
    {
        if (this.itemCount != null) return;
        this.itemCount = transform.Find("ItemCount").GetComponent<TMP_Text>();
    }

    protected virtual void LoadItemImage()
    {
        if (this.itemImage != null) return;
        this.itemImage = transform.Find("ItemImage").GetComponent<Image>();
    }

    public virtual void ShowItem(ItemInventory item)
    {
        this.itemName.text = item.itemProfileSO.itemName;
        this.itemCount.text = item.itemCount.ToString();
        this.itemImage.sprite = item.itemProfileSO.sprite;
    }
}
