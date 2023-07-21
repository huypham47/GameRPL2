using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySummon : BaseAbility
{
    [Header("Ability Summon")]

    [SerializeField] protected List<Transform> enemies;
    [SerializeField] protected int enemyLimit = 3;

    protected override void Start()
    {
        base.Start();
        this.enemies = new List<Transform>();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.Summoning();
        this.ClearDeadMinion();
    }

    protected virtual void Summoning()
    {
        if (this.enemies.Count >= this.enemyLimit)
        {
            this.timer = 0;
            return;
        }
        if (!this.isReady) return;
        this.Summon();
    }

    protected virtual void ClearDeadMinion()
    {
        foreach(Transform enemy in this.enemies)
        {
            if(enemy.gameObject.activeSelf == false)
            {
                this.enemies.Remove(enemy);
                return;
            }
        }
    }

    protected virtual void Summon()
    {
        Transform spawnPos = this.abilities.enemyCtrl.SpawnPoints.GetRandom();
        Transform enemyPrefab = this.abilities.enemyCtrl.enemySpawner.RandomPrefab();
        Transform enemy = this.abilities.enemyCtrl.enemySpawner.Spawn(enemyPrefab, spawnPos.position, spawnPos.rotation);
        enemy.parent = this.abilities.enemyCtrl.transform;
        this.enemies.Add(enemy);
        StartCoroutine(ChangeParent(enemy));
        this.Active();
    }

    IEnumerator ChangeParent(Transform enemy)
    {
        yield return new WaitForSeconds(0.1f);
        enemy.parent = EnemySpawner.Instance.Holder;
    }
}
