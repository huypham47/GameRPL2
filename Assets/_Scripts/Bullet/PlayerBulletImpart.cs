using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerBulletImpart : Impact
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
        if (other.name == "PlayerDamageReceiver") return;
        base.OnTriggerEnter(other);
        this.bulletCtrl.BulletDamageSender.Send(other.transform);
    }
}
