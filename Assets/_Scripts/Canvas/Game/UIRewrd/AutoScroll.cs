using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScroll : _MonoBehaviour
{
    public ItemInventory itemInventory;

    public virtual void StartCorou()
    {
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
        this.AddReward();
        yield return new WaitForSeconds(2f);
        RewardSpawner.Instance.ClearItems();
        UIReward.Instance.Toggle();
    }

    protected virtual void AddReward()
    {
        UIItemInventory uIItemInventory;
        if (transform.GetChild(1).localPosition.x >= 290)
        {
            uIItemInventory = transform.GetChild(1).GetComponent<UIItemInventory>();
        }
        else uIItemInventory = transform.GetChild(2).GetComponent<UIItemInventory>();

        itemInventory.itemProfileSO = ItemProfileSO.FindByItemName(uIItemInventory.ItemName.text.ToString());
        if(itemInventory.itemProfileSO.itemType == ItemType.Clothing)
        {

        }
        itemInventory.itemCount = Int32.Parse(uIItemInventory.ItemCount.text);
        PlayerCtrl.Instance.Inventory.AddItem(itemInventory);
    }

    protected virtual void Scroll(float t0)
    {
        float  rand = UnityEngine.Random.Range(40, 60);
        foreach (RectTransform transform in transform)
        {
            Vector2 pos = transform.anchoredPosition;
            transform.anchoredPosition = Vector2.Lerp(pos, pos - new Vector2(rand, 0), t0);
        }
    }

    private void HandleHorizontalScroll()
    {
        if (transform.childCount < 1) return;
        int currItemIndex = 0;
        var currItem = transform.GetChild(currItemIndex);
        if (!ReachedThreshold(currItem)) return;

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
