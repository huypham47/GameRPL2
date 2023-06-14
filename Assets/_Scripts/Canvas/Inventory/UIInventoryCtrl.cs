using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryCtrl : _MonoBehaviour
{
    [SerializeField] protected InvItemSpawner invItemSpawner;
    public InvItemSpawner InvItemSpawner => invItemSpawner;

    [SerializeField] protected Transform content;
    public Transform Content => content;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadInvItemSpawner();
        this.LoadContent();
    }

    protected override void Start()
    {
        base.Start();
        for (int i = 1; i < 70; i++)
        {
            this.SpawnItem(i);
        }
    }

    protected virtual void SpawnItem(int i)
    {
        Transform uiItem = this.invItemSpawner.Spawn("UIInvItem", this.content.position, this.content.rotation);
        uiItem.localScale = new Vector3(1, 1, 1);
        uiItem.name = "item: " + i;
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
