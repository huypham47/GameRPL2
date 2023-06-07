using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangDamageSender : DamageSender
{
    [SerializeField] protected AllBulletCtrl allBulletCtrl;
    public AllBulletCtrl AllBulletCtrl => allBulletCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBoomerangCrl();
    }

    protected virtual void LoadBoomerangCrl()
    {
        if (this.allBulletCtrl != null) return;
        this.allBulletCtrl = transform.parent.GetComponent<AllBulletCtrl>();
    }

    private void OnEnable()
    {
        this.damage = this.allBulletCtrl.BulletSO.damage;
    }
}
