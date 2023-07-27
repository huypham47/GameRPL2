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
        UIReward.Instance.ShowReward(this.enemyCtrl);
        TextScore.Instance.canUpgradeScore = true;
        this.wormHole.transform.position = PlayerCtrl.Instance.transform.position + new Vector3 (0,0,5);
        UIReward.Instance.Toggle();
        base.OnDead();
    }

    public override void Reborn()
    {
        base.Reborn();
        this.enemyCtrl.Animator.SetFloat("speed", 0f);
    }
}
