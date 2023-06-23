using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawn : DespawnByDistance
{
    public override void DespawnObject()
    {
        Debug.Log("Bullet despawn" + transform.parent.name);
        BulletSpawner.Instance.Despawn(transform.parent);
    }
}
