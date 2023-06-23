using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class BaseCoolDown : _MonoBehaviour
{
    [SerializeField] protected float timer;
    [SerializeField] protected float delay;
    [SerializeField] protected string coolDown;

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
        txtCoolDown.text = this.coolDown;
    }
}
