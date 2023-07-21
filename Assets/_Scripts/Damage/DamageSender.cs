using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : _MonoBehaviour
{
    [SerializeField] protected float damage = 1;
    [SerializeField] protected float damageCrit;

    public virtual void Send(Transform obj)
    {
        DamageReceiver damageReceiver = obj.GetComponentInChildren<DamageReceiver>();
        if (damageReceiver == null) return;
        this.CreateImpactFX(FXSpawner.impactOne, obj.transform.position + obj.forward);
        this.CreateDamageFX(FXSpawner.impactThree, obj.position, -obj.forward);
        this.Send(damageReceiver);
    }

    protected virtual void CreateImpactFX(string fxName, Vector3 pos)
    {
        Transform fxImpact = FXSpawner.Instance.SpawnFx(fxName, pos, transform.rotation);
    }

    protected void CreateDamageFX(string fxName, Vector3 pos, Vector3 direction)
    {
        Transform fxDamage = FXSpawner.Instance.SpawnFx(fxName, pos, transform.rotation);
        fxDamage.gameObject.SetActive(true);
        float rand = Random.Range(0, 100);
        bool isCrit = false;
        this.damageCrit = this.damage;
        if (rand <= 50)
        {
            this.damageCrit = this.damageCrit * 1.5f;
            isCrit = true;
        }
        damageCtrl damageCtrl = fxDamage.GetComponent<damageCtrl>();
        damageCtrl.SetUp(isCrit, this.damageCrit, direction);
    }

    //protected virtual string GetImpactFXName()
    //{
    //    return FXSpawner.impactOne;
    //}

    public virtual void Send(DamageReceiver damageReceiver)
    {
        damageReceiver.Deduct(this.damageCrit);
    }

}
