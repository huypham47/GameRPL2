using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerRandom : _MonoBehaviour
{
    [SerializeField] protected EnemySpawnerCtrl enemySpawnerCtrl;
    public EnemySpawnerCtrl EnemyCtrl { get => enemySpawnerCtrl; }

    [SerializeField] protected float randomDelay = 3f;
    [SerializeField] protected float randomTimer = 0f;
    [SerializeField] protected int randomLimit = 1;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemySpawnerCtrl();
    }

    protected virtual void LoadEnemySpawnerCtrl()
    {
        if (this.enemySpawnerCtrl != null) return;
        this.enemySpawnerCtrl = GetComponent<EnemySpawnerCtrl>();
    }

    private void FixedUpdate()
    {
        this.EnemySpawning();

    }

    protected virtual void EnemySpawning()
    {
        if (this.RandomReachLimit()) return;

        this.randomTimer += Time.fixedDeltaTime;
        if (this.randomTimer < this.randomDelay) return;
        this.randomTimer = 0;

        Transform randPoint = this.enemySpawnerCtrl.EnemySpawnPoints.GetRandom();
        Vector3 pos = randPoint.position;
        Quaternion rot = transform.rotation;

        Transform prefab = this.enemySpawnerCtrl.EnemySpawner.RandomPrefab();
        Transform newEnemy = this.enemySpawnerCtrl.EnemySpawner.Spawn(prefab, pos, rot);
        newEnemy.gameObject.SetActive(true);
    }

    protected virtual bool RandomReachLimit()
    {
        int currentEnemy = this.enemySpawnerCtrl.EnemySpawner.SpawnedCount;
        return currentEnemy >= this.randomLimit;
    }
}
