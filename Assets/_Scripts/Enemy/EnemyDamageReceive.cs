using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDamageReceive : DamageReceiver
{
    [SerializeField] protected EnemyCtrl enemyCtrl;
    [SerializeField] protected float timer = 0;
    [SerializeField] protected float delay = 3f;

    protected void FixedUpdate()
    {
        if (this.enemyCtrl.CanvasHealth.HealthBar.canAdd)
        {
            this.timer += Time.fixedDeltaTime;
            if (this.timer < this.delay) return;
            this.timer = 0;
            this.Add(1);
        }
    }

    protected virtual void CanAdd()
    {
        this.Add(1);
    }

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

    protected override void OnDead()
    {
        this.enemyCtrl.EnemyDespawn.DespawnObject();
        this.OnDeadFX();
        TextScore.Instance.UpdateScore();
        MapLevel.Instace.Leveling();
        //DropItem
        this.OnDeadDropItem();
    }

    protected virtual void OnDeadDropItem()
    {
        Vector3 dropPos = transform.position;
        Quaternion dropRot = transform.rotation;
        ItemDropSpawner.Instance.Drop(this.enemyCtrl.EnemySO.dropList, dropPos, dropRot);
    }

    protected virtual void OnDeadFX()
    {
        string fxName = this.GetOnDeadFXName();
        Vector3 spawnPos = transform.position;
        spawnPos.y = 20;
        Transform fxOnDead = FXSpawner.Instance.Spawn(fxName, spawnPos, transform.rotation);
        fxOnDead.gameObject.SetActive(true);
    }

    public override void Reborn()
    {
        int currentLvel = MapLevel.Instace.LevelCurrent;
        this.hpMax = this.enemyCtrl.EnemySO.upgradeLevels[currentLvel].enemyHp;
        this.enemyCtrl.CanvasHealth.HealthBar.SetMaxHealth(this.hpMax);
        base.Reborn();
    }

    public override void Deduct(float add)
    {
        base.Deduct(add);
        this.enemyCtrl.CanvasHealth.HealthBar.gameObject.SetActive(true);
        this.enemyCtrl.CanvasHealth.HealthBar.SetHealth(this.hp);
        this.enemyCtrl.CanvasHealth.HealthBar.canAdd = false;
        this.timer = 0;
    }

    public override void Add(float add)
    {
        base.Add(add);
        this.enemyCtrl.CanvasHealth.HealthBar.SetHealth(this.hp);
    }

    protected virtual string GetOnDeadFXName()
    {
        return FXSpawner.smokeOne;
    }
}
