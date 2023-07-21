using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDamageReceive : DamageReceiver
{
    public EnemyCtrl enemyCtrl;
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

    protected override void OnDead()
    {
        this.enemyCtrl.enemySpawner.Despawn(transform.parent);
        this.OnDeadFX();
        TextScore.Instance.UpdateScore();
        MapLevel.Instance.Leveling();
        //DropItem
        this.OnDeadDropItem();
    }

    protected virtual void OnDeadDropItem()
    {
        int currentLvel = MapLevel.Instance.LevelCurrent - 1;
        Vector3 dropPos = transform.position;
        Quaternion dropRot = transform.rotation;
        ItemDropSpawner.Instance.Drop(this.enemyCtrl.EnemySO.upgradeLevels[currentLvel].dropList, dropPos, dropRot);
    }

    protected virtual void OnDeadFX()
    {
        string fxName = this.GetOnDeadFXName();
        Vector3 spawnPos = transform.position;
        Transform fxOnDead = FXSpawner.Instance.SpawnFx(fxName, spawnPos, transform.rotation);
        //fxOnDead.gameObject.SetActive(true);
    }

    public override void Reborn()
    {
        this.enemyCtrl.CanvasHealth.HealthBar.gameObject.SetActive(false);

        int currentLvel = MapLevel.Instance.LevelCurrent-1;
        this.hpMax = this.enemyCtrl.EnemySO.upgradeLevels[currentLvel].enemyHp;
        this.enemyCtrl.CanvasHealth.HealthBar.SetMaxHealth(this.hpMax);
        base.Reborn();
    }

    public override void Deduct(float add)
    {
        base.Deduct(add);
        if (this.isDead) return;
        this.enemyCtrl.Animator.SetBool("isHit", false);
        this.enemyCtrl.CanvasHealth.HealthBar.gameObject.SetActive(true);
        this.enemyCtrl.CanvasHealth.HealthBar.SetHealth(this.hp);
        this.enemyCtrl.CanvasHealth.HealthBar.canAdd = false;
        this.timer = 0;
        this.enemyCtrl.Animator.SetBool("isHit", true);
        StopCoroutine(this.StopAnimation());
        StartCoroutine(this.StopAnimation());
    }

    IEnumerator StopAnimation()
    {
        yield return new WaitForSeconds(.4f);

        this.enemyCtrl.Animator.SetBool("isHit", false);
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
