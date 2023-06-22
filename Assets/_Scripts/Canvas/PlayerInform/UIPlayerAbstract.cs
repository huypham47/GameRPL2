using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIPlayerAbstract : _MonoBehaviour
{
    [SerializeField] protected UIPlayerCtrl uiPlayerCtrl;
    public UIPlayerCtrl UIPlayerCtrl => uiPlayerCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadUIPlayerCtrl();
    }
    protected virtual void LoadUIPlayerCtrl()
    {
        if (this.uiPlayerCtrl != null) return;
        this.uiPlayerCtrl = transform.parent.GetComponent<UIPlayerCtrl>();
    }
}
