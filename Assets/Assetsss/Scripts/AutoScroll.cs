using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AutoScroll : _MonoBehaviour
{
    [SerializeField] protected List<RectTransform> transforms;
    [SerializeField] protected List<ItemDropRate> rewardList;
    public ItemInventory itemInventory;


    protected virtual void LoadTranform()
    {
        if (transforms.Count > 0) return;
        foreach(RectTransform transform in transform)
        {
            this.transforms.Add(transform);
        }
    }
    //protected override void Start()
    //{
    //    this.StartCorou();
    //}

    //private void Update()
    //{
    //    this.HandleHorizontalScroll();
    //}

    public virtual void StartCorou()
    {
        this.LoadTranform();
        StartCoroutine(Scroll());
    }

    IEnumerator Scroll()
    {
        yield return new WaitForSeconds(0.5f);
        float t0 = 0f;
        while (t0 < 1f)
        {
            t0 += Time.fixedDeltaTime/20f;
            this.Scroll(t0);
            this.HandleHorizontalScroll();
            yield return null;
        }
        UIItemInventory uIItemInventory;
        if (transform.GetChild(1).localPosition.x >= 290)
        {
            uIItemInventory = transform.GetChild(1).GetComponent<UIItemInventory>();
        } else uIItemInventory = transform.GetChild(2).GetComponent<UIItemInventory>();

        itemInventory.itemProfileSO = ItemProfileSO.FindByItemName(uIItemInventory.ItemName.text.ToString());
        itemInventory.itemCount = Int32.Parse(uIItemInventory.ItemCount.text);
        Debug.Log(itemInventory.itemCount);

        PlayerCtrl.Instance.Inventory.AddItem(itemInventory);
        yield return new WaitForSeconds(2.5f);
        UIReward.Instance.Toggle();
    }

    protected virtual void Scroll(float t0)
    {

        foreach (RectTransform transform in transforms)
        {
            Vector2 pos = transform.anchoredPosition;
            transform.anchoredPosition = Vector2.Lerp(pos, pos - new Vector2(50, 0), t0);
        }
    }

    private void HandleHorizontalScroll()
    {
        int currItemIndex = 0;
        var currItem = transform.GetChild(currItemIndex);
        if (!ReachedThreshold(currItem))
        {
            return;
        }

        int endItemIndex = transform.childCount - 1;
        Transform endItem = transform.GetChild(endItemIndex);
        Vector2 newPos = endItem.localPosition;
        newPos.x += 200 + 10;

        currItem.localPosition = newPos;
        currItem.SetSiblingIndex(endItemIndex);
    }

    private bool ReachedThreshold(Transform item)
    {
        return item.localPosition.x < -50;
    }
}
