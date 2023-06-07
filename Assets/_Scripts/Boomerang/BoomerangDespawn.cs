using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangDespawn : Despawn
{
    [SerializeField] public bool canDespawn = false;

    public override void DespawnObject()
    {
        BulletSpawner.Instance.Despawn(transform.parent);
    }

    protected override bool CanDespawn()
    {
        return this.canDespawn;
    }
}
