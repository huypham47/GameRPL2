using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLevel : LevelByScore
{
    [SerializeField] private static MapLevel instance;
    public static MapLevel Instance => instance;

    [SerializeField] protected bool canSpawnBoss = true;

    protected override void Awake()
    {
        base.Start();
        if (MapLevel.instance != null) return;
        MapLevel.instance = this;
    }

    public override void LevelUp()
    {
        base.LevelUp();
        PlayerCtrl.Instance.PlayerDamageReceiver.AddMaxHP();
        PlayerCtrl.Instance.PlayerDamageReceiver.Add(1);
        
        BulletSO bullet_3 = Resources.Load<BulletSO>("bullet/bullet_3");
        bullet_3.DamageUpgrade(0.2f);
        this.canSpawnBoss = true;
    }

    public override void Leveling()
    {
        base.Leveling();
        if (!this.canSpawnBoss) return;
        if (TextScore.Instance.Score % 15 == 14)
        {
            EnemySpawnerCtrl.Instance.EnemySpawnerRandom.randomLimit = 0;

            Vector3 pos = PlayerCtrl.Instance.transform.position;
            pos.z += 10;
            EnemySpawnerCtrl.Instance.EnemySpawner.Spawn("Boss", pos, transform.rotation);
            TextScore.Instance.canUpgradeScore = false;
            this.canSpawnBoss = false;
        }
    }

    public virtual void SetCurrentLevel(int level)
    {
        this.levelCurrent = level;
    }
}
