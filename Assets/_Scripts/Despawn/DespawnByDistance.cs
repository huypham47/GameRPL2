using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDistance : Despawn
{
    [SerializeField] protected float disLitmit = 1000f;
    [SerializeField] protected float distance = 0f;

    protected override void LoadComponent()
    {
        base.LoadComponent();
    }

    protected override bool CanDespawn()
    {
        this.distance = Vector3.Distance(transform.parent.position, PlayerCtrl.Instance.transform.position);
        if (this.distance > this.disLitmit) return true;
        return false;
    }
}
