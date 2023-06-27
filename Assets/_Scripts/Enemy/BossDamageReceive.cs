using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossDamageReceive : EnemyDamageReceive
{
    [SerializeField] protected WormHole wormHole;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.wormHole = GameObject.Find("WormHole").GetComponent<WormHole>();
    }

    protected override void OnDead()
    {
        EnemySpawner.Instance.ClearEnemyFromBoss();
        TextScore.Instance.canUpgradeScore = true;
        this.wormHole.transform.position = transform.position;
        base.OnDead();
    }

}
