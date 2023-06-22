using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlayerCtrl : _MonoBehaviour
{
    private static UIPlayerCtrl instance;
    public static UIPlayerCtrl Instance { get => instance; }

    [SerializeField] protected CanvasGroup canvasGroup;
    public CanvasGroup CanvasGroup => canvasGroup;

    [SerializeField] protected TextInformCtrl textInformCtrl;
    public TextInformCtrl TextInformCtrl => textInformCtrl;

    protected override void Awake()
    {
        base.Awake();
        if (UIPlayerCtrl.instance != null) return;
        UIPlayerCtrl.instance = this;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCanvasGroup();
        this.LoadTextInformCtrl();
    }

    protected virtual void LoadCanvasGroup()
    {
        if (this.canvasGroup != null) return;
        this.canvasGroup = GetComponent<CanvasGroup>();
    }

    protected virtual void LoadTextInformCtrl()
    {
        if (this.textInformCtrl != null) return;
        this.textInformCtrl = GetComponentInChildren<TextInformCtrl>();
    }

    public virtual void SetAlphaCanvas(int alpha)
    {
        this.canvasGroup.alpha = alpha;
        this.canvasGroup.interactable = Convert.ToBoolean(alpha);
    }
}
