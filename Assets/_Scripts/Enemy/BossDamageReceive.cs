using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossDamageReceive : EnemyDamageReceive
{
    protected override void OnDead()
    {
        EnemySpawner.Instance.ClearEnemyFromBoss();
        EnemySpawnerCtrl.Instance.EnemySpawnerRandom.randomLimit = 1;
        TextScore.Instance.canUpgradeScore = true;
        base.OnDead();
    }

}
