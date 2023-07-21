using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    private static EnemySpawner instance;
    public static EnemySpawner Instance { get => instance; }

    [SerializeField] protected SpawnPoints enemySpawnPoints;
    public SpawnPoints EnemySpawnPoints { get => enemySpawnPoints; }

    [SerializeField] protected float randomDelay = 3f;
    [SerializeField] protected float randomTimer = 0f;
    public int randomLimit = 1;

    public static string enemyOne = "Enemy_2";

    protected override void Awake()
    {
        base.Awake();
        if (EnemySpawner.instance == null) EnemySpawner.instance = this;
        
        this.SetUp();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSpawnPoints();
    }

    private void FixedUpdate()
    {
        this.EnemySpawning();
        this.DespawnEnemy();
    }

    protected virtual void SetUp()
    {
        foreach(var prefab in prefabs)
        {
            var enemy = prefab.GetComponent<EnemyCtrl>();
            enemy.enemySpawner = this;
            enemy.SetUp();
        }
    }

    protected virtual void LoadSpawnPoints()
    {
        if (this.enemySpawnPoints != null) return;
        this.enemySpawnPoints = Transform.FindObjectOfType<SpawnPoints>();
    }

    protected virtual void EnemySpawning()
    {
        if (this.RandomReachLimit()) return;

        this.randomTimer += Time.fixedDeltaTime;
        if (this.randomTimer < this.randomDelay) return;
        this.randomTimer = 0;

        Transform randPoint = this.enemySpawnPoints.GetRandom();
        Vector3 pos = randPoint.position;
        Quaternion rot = transform.rotation;

        string prefab = this.RandomPrefab().name;
        this.Spawn(prefab, pos, rot);
    }

    protected virtual bool RandomReachLimit()
    {
        int currentEnemy = this.SpawnedCount;
        return currentEnemy >= this.randomLimit;
    }

    protected virtual void DespawnEnemy()
    {
        foreach (Transform enemy in holder)
        {
            if (!enemy.gameObject.activeSelf) continue;
            if (Vector3.Distance(PlayerCtrl.Instance.transform.position, enemy.position) >= 30f)
            {
                Despawn(enemy.transform);
            }
        }
    }
}
