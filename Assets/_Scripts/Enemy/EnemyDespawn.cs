using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDespawn : DespawnByDistance
{
    public override void DespawnObject()
    {
        EnemySpawnerCtrl.Instance.EnemySpawner.Despawn(transform.parent);
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.disLitmit = 2000f;
    }
}
