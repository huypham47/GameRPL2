using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamageReceiver : DamageReceiver
{
    [SerializeField] protected PlayerCtrl playerCtrl;
    [SerializeField] protected float timer = 0;
    [SerializeField] protected float delay = 12f;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerCtrl();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.hpMax = 100;
        this.hp = 100;
    }

    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = transform.parent.GetComponent<PlayerCtrl>();
    }

    protected override void OnDead()
    {
        this.OnDeadFX();
        SaveManager.Instance.SaveGame();
        SceneManager.LoadScene("Menu");
    }

    protected virtual void OnDeadFX()
    {
        string fxName = this.GetOnDeadFXName();
        Vector3 spawnPos = transform.position;
        spawnPos.y = 20;
        Transform fxOnDead = FXSpawner.Instance.Spawn(fxName, spawnPos, transform.rotation);
        //fxOnDead.gameObject.SetActive(true);
    }

    public override void Deduct(float add)
    {
        base.Deduct(add);
    }

    public override void Add(float add)
    {
        base.Add(add);
       
        Transform fxOnDead = FXSpawner.Instance.Spawn(FXSpawner.impactTrue, transform.position, transform.rotation);
    }

    protected virtual string GetOnDeadFXName()
    {
        return FXSpawner.smokeOne;
    }

    public virtual void AddMaxHP()
    {
        this.hpMax++;
    }

    public virtual void SetHP(float hp, float hpMax)
    {
        this.hp = hp;
        this.hpMax = hpMax;
    }
}
