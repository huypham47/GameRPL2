using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : _MonoBehaviour
{
    [SerializeField] protected float damage = 1;

    public virtual void Send(Transform obj)
    {
        DamageReceiver damageReceiver = obj.GetComponentInChildren<DamageReceiver>();
        if (damageReceiver == null) return;
        this.CreateImpactFX();
        this.Send(damageReceiver);
    }

protected virtual void CreateImpactFX()
{

    string fxName = this.GetImpactFXName();

    Transform fxImpact = FXSpawner.Instance.Spawn(fxName, transform.position, transform.rotation);
    fxImpact.gameObject.SetActive(true);
}

protected virtual string GetImpactFXName()
{
    return FXSpawner.impactOne;
}

public virtual void Send(DamageReceiver damageReceiver)
    {
        damageReceiver.Deduct(this.damage);
    }

}
