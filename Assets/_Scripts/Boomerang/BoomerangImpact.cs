using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangImpact : Impact
{
    [SerializeField] protected AllBulletCtrl allBulletCtrl;
    public AllBulletCtrl AllBulletCtrl => allBulletCtrl;


    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBoomerangCtrl();
    }

    protected virtual void LoadBoomerangCtrl()
    {
        if (this.allBulletCtrl != null) return;
        this.allBulletCtrl = transform.parent.GetComponent<AllBulletCtrl>();
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.name == "EnemyDamageReceiver")
        {
            base.OnTriggerEnter(other);
            this.allBulletCtrl.DamageSender.Send(other.transform);
        }
    }
}
