using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangImpact : Impact
{
    [SerializeField] protected BoomerangCtrl boomerangCtrl;
    public BoomerangCtrl BoomerangCtrl => boomerangCtrl;


    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBoomerangCtrl();
    }

    protected virtual void LoadBoomerangCtrl()
    {
        if (this.boomerangCtrl != null) return;
        this.boomerangCtrl = transform.parent.GetComponent<BoomerangCtrl>();
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.name == "EnemyDamageReceiver")
        {
            base.OnTriggerEnter(other);
            this.boomerangCtrl.BoomerangDamageSender.Send(other.transform);
        }
    }
}
