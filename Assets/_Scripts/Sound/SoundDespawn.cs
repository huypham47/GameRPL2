using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDespawn : DespawnByTime
{
    public override void DespawnObject()
    {
        SoundSpawner.Instance.Despawn(transform.parent);
    }
}
