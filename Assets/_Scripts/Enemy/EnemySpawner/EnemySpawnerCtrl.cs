using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerCtrl : _MonoBehaviour
{
    [SerializeField] protected EnemySpawner enemySpawner;
    public EnemySpawner EnemySpawner { get => enemySpawner; }

    [SerializeField] protected EnemySpawnPoints enemySpawnPoints;
    public EnemySpawnPoints EnemySpawnPoints { get => enemySpawnPoints; }


    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemySpawner();
        this.LoadSpawnPoints();
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
