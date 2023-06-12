using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySummon : BaseAbility
{
    [Header("Ability Summon")]

    [SerializeField] protected Spawner spawner;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemySpawner();
    }

    protected virtual void LoadEnemySpawner()
    {
        if (this.spawner != null) return;
        GameObject enemySpawner = GameObject.Find("EnemySpawner");
        this.spawner = enemySpawner.GetComponent<EnemySpawner>();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.Summoning();
    }

    protected virtual void Summoning()
    {
        if (!this.isReady) return;
        this.Summon();
    }

    protected virtual void Summon()
    {
        Transform spawnPos = this.abilities.AbilityObjectCtrl.SpawnPoints.GetRandom();

        Transform prefab = this.spawner.RandomPrefab();
        this.spawner.Spawn(prefab, spawnPos.position, spawnPos.rotation);
        this.Active();
    }
}
