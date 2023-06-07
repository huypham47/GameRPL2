using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawn : _MonoBehaviour
{
    protected virtual void FixedUpdate()
    {
        this.Despawning();
    }

    protected virtual void Despawning()
    {
        if (transform.parent.name == "Health")  Debug.Log("Despawn: "+ !this.CanDespawn());
        if (!this.CanDespawn()) return;
        if (transform.parent.name == "Health")  Debug.Log("despawn");
        this.DespawnObject();
    }

    public virtual void DespawnObject()
    {
        Destroy(transform.parent.gameObject);
    }

    protected abstract bool CanDespawn();
}
