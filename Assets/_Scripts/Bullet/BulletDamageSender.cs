using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageSender : DamageSender
{
    [SerializeField] protected AllBulletCtrl allBulletCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBulletCtrl();
    }

    protected virtual void LoadBulletCtrl()
    {
        if (this.allBulletCtrl != null) return;
        this.allBulletCtrl = transform.parent.GetComponent<AllBulletCtrl>();
    }

    private void OnEnable()
    {
        this.damage = this.allBulletCtrl.BulletSO.damage;
    }

    public override void Send(DamageReceiver damageReceiver)
    {
        base.Send(damageReceiver);
        this.DestroyBullet();
    }

    protected virtual void DestroyBullet()
    {
        Debug.Log("DestroyBullet" + transform.parent.name);
        this.allBulletCtrl.Despawn.DespawnObject();
    }
}
