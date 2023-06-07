using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class EnemyImpact : Impact
{
    [SerializeField] protected EnemyCtrl enemyCtrl;
    public EnemyCtrl EnemyCtrl => enemyCtrl;


    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyCtrl();
    }

    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if(other.name == "PlayerDamageReceiver")
        {
            base.OnTriggerEnter(other);
            this.enemyCtrl.EnemyDamageSender.Send(other.transform);
        }
    }
}
