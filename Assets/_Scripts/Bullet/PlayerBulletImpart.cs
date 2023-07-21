using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerBulletImpart : BulletImpact
{
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.name == "PlayerDamageReceiver") return;
        base.OnTriggerEnter(other);
        this.allBulletCtrl.DamageSender.Send(other.transform);
    }
}
