using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletImpart : Impact
{
    [SerializeField] protected BulletCtrl bulletCtrl;
    public BulletCtrl BulletCtrl => bulletCtrl;


    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBulletCtrl();
    }

    protected virtual void LoadBulletCtrl()
    {
        if (this.bulletCtrl != null) return;
        this.bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.name == "Enemy_2" || other.name == "Enemy_1") return;
        base.OnTriggerEnter(other);
        this.bulletCtrl.BulletDamageSender.Send(other.transform);
    } 
}
