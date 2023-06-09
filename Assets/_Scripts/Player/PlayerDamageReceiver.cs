using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamageReceiver : DamageReceiver
{
    [SerializeField] protected PlayerCtrl playerCtrl;
    [SerializeField] protected float timer = 0;
    [SerializeField] protected float delay = 12f;
    [SerializeField] protected int playerHP = 10;
    [SerializeField] protected bool canAdd = true;

    protected void FixedUpdate()
    {
        if (this.canAdd && this.hp < this.hpMax)
        {
            this.timer += Time.fixedDeltaTime;
            if (this.timer < this.delay) return;
            this.timer = 0;
            this.Add(1);
        }
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerCtrl();
    }


    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = transform.parent.GetComponent<PlayerCtrl>();
    }

    protected override void OnDead()
    {
        //UIManager.Instance.BtnGameOver.SetActive(true);
        this.OnDeadFX();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
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
        this.hpMax = this.playerHP;
        base.Reborn();
    }

    public override void Deduct(int add)
    {
        base.Deduct(add);
        this.canAdd = false;
        StartCoroutine(CanAdd());
        
    }

    IEnumerator CanAdd()
    {
        yield return new WaitForSeconds(4f);
        canAdd = true;
        this.timer = 0;
    }

    public override void Add(int add)
    {
        base.Add(add);
    }

    protected virtual string GetOnDeadFXName()
    {
        return FXSpawner.smokeOne;
    }

    public virtual void AddMaxHP()
    {
        this.hpMax++;
    }
}
