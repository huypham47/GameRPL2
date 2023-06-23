using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerBulletImpart : Impact
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
        if (other.name == "PlayerDamageReceiver") return;
        Debug.Log("Impart" + transform.parent);
        base.OnTriggerEnter(other);
        this.allBulletCtrl.DamageSender.Send(other.transform);
    }
}
