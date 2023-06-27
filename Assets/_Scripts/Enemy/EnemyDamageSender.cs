using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageSender : DamageSender
{
    [SerializeField] protected EnemyCtrl enemyCtrl;

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

    private void OnEnable()
    {
        int currentLvel = MapLevel.Instance.LevelCurrent-1;
        this.damage = this.enemyCtrl.EnemySO.upgradeLevels[currentLvel].ememyDamage;
    }
}
