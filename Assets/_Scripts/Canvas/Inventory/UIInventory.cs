using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : _MonoBehaviour
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
        this.Toggle();
    }

    private void Update()
    {
        Debug.Log("FixedUpdate");
        this.ShowItems();
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
        gameObject.SetActive(true);
    }

    public virtual void Close()
    {
        gameObject.SetActive(false);
    }

    protected virtual void ShowItems()
    {
        if (!isOpen) return;
        int itemCount = PlayerCtrl.Instance.Inventory.Items.Count;
        Debug.Log(itemCount);
    }
}
