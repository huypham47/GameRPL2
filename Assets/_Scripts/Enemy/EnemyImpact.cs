using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class EnemyImpact : Impact
{
    public EnemyCtrl enemyCtrl;

    protected override void OnTriggerEnter(Collider other)
    {
        if(other.name == "PlayerDamageReceiver")
        {
            base.OnTriggerEnter(other);
            this.enemyCtrl.EnemyDamageSender.Send(other.transform);
        }
    }
}
