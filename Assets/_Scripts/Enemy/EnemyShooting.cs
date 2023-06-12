using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : Shooting
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

    protected override void ResetValue()
    {
        base.ResetValue();
        this.delay = 2.5f;
    }

    protected virtual void OnEnable()
    {
        int currentLvel = MapLevel.Instace.LevelCurrent;
        this.delay = this.enemyCtrl.EnemySO.upgradeLevels[currentLvel].ememySpeed;
    }

    protected override void SpawnBullet(Vector3 spawnPos, Quaternion rotation)
    {
        Transform newBullet = BulletSpawner.Instance.Spawn("Bullet_3", spawnPos, rotation);
    }
}
