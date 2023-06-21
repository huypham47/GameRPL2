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
    }

    protected virtual void LoadCanvasGroup()
    {
        if (this.canvasGroup != null) return;
        this.canvasGroup = GetComponent<CanvasGroup>();
    }

    public virtual void SetAlphaCanvas(int alpha)
    {
        this.canvasGroup.alpha = alpha;
        this.canvasGroup.interactable = Convert.ToBoolean(alpha);
    }
}
