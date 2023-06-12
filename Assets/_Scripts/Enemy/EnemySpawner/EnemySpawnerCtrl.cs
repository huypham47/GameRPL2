using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerCtrl : _MonoBehaviour
{
    [SerializeField] protected EnemySpawner enemySpawner;
    public EnemySpawner EnemySpawner { get => enemySpawner; }

    [SerializeField] protected EnemySpawnPoints enemySpawnPoints;
    public EnemySpawnPoints EnemySpawnPoints { get => enemySpawnPoints; }

    [SerializeField] protected EnemySpawnerRandom enemySpawnerRandom;
    public EnemySpawnerRandom EnemySpawnerRandom { get => enemySpawnerRandom; }

    private static EnemySpawnerCtrl instance;
    public static EnemySpawnerCtrl Instance { get => instance; }

    public static string enemyOne = "Enemy_2";

    protected override void Awake()
    {
        base.Awake();
        if (EnemySpawnerCtrl.instance != null) return;
        EnemySpawnerCtrl.instance = this;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemySpawner();
        this.LoadSpawnPoints();
        this.LoadEnemySpawnerRandom();
    }

    protected virtual void LoadEnemySpawnerRandom()
    {
        if (this.enemySpawnerRandom != null) return;
        this.enemySpawnerRandom = GetComponent<EnemySpawnerRandom>();
    }

    protected virtual void LoadEnemySpawner()
    {
        if (this.enemySpawner != null) return;
        this.enemySpawner = GetComponent<EnemySpawner>();
    }

    protected virtual void LoadSpawnPoints()
    {
        if (this.enemySpawnPoints != null) return;
        this.enemySpawnPoints = Transform.FindObjectOfType<EnemySpawnPoints>();
    }
}
