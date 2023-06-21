using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CoolDownFlash : _MonoBehaviour
{
    [SerializeField] protected float timer;
    [SerializeField] protected float delay;

    [SerializeField] protected TMP_Text txtCoolDown;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadTextScore();
    }

    protected virtual void LoadTextScore()
    {
        if (this.txtCoolDown != null) return;
        this.txtCoolDown = GetComponent<TMP_Text>();
    }

    public virtual void Update()
    {
        string coolDown;
        this.timer = Mathf.Round(BaseAbility.Instance.Timer);
        this.delay = BaseAbility.Instance.Delay;
        if (BaseAbility.Instance.IsReady) coolDown = "OK";
        else coolDown = this.timer + " / " + this.delay;
        txtCoolDown.text = coolDown;
    }
}
