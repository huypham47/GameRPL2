using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangDamageSender : DamageSender
{
    [SerializeField] protected BoomerangCtrl boomerangCtrl;
    public BoomerangCtrl BoomerangCtrl => boomerangCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBoomerangCrl();
    }

    protected virtual void LoadBoomerangCrl()
    {
        if (this.boomerangCtrl != null) return;
        this.boomerangCtrl = transform.parent.GetComponent<BoomerangCtrl>();
    }

    private void OnEnable()
    {
        this.damage = this.boomerangCtrl.BulletSO.damage;
    }
}
