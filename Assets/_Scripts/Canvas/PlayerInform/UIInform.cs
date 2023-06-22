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

    //protected override void Start()
    //{
    //    base.Start();
    //    this.Toggle();
    //}

    public virtual void Toggle()
    {
        Debug.Log("Toggle");
        this.isOpen = !this.isOpen;
        if (this.isOpen) Open();
        else this.Close();
    }

    public virtual void Open()
    {
        RectTransform rt = UIInventoryCtrl.Instance.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(700, 750);
        rt.anchoredPosition = new Vector3(700, 17, 0);
        this.uiPlayerCtrl.TextInformCtrl.SetText();
        this.uiPlayerCtrl.SetAlphaCanvas(1);
        //this.ShowItems();
    }

    public virtual void Close()
    {
        RectTransform rt = UIInventoryCtrl.Instance.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(1150, 750);
        rt.anchoredPosition = new Vector3(960, 17, 0);
        this.uiPlayerCtrl.SetAlphaCanvas(0);

    }
}
