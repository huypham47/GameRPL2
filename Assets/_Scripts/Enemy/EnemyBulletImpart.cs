using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletImpart : Impact
{
    [SerializeField] protected AllBulletCtrl allBulletCtrl;
    public AllBulletCtrl AllBulletCtrl => allBulletCtrl;


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

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.name == "Enemy_2" || other.name == "Enemy_1") return;
        base.OnTriggerEnter(other);
        this.allBulletCtrl.DamageSender.Send(other.transform);
    } 
}
