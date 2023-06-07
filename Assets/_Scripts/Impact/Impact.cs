using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impact : _MonoBehaviour
{
    
    [SerializeField] protected BoxCollider boxCollider;
    [SerializeField] protected Rigidbody _rigibody;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCollider();
        this.LoadRigibody();
    }

    protected virtual void LoadCollider()
    {
        if (this.boxCollider != null) return;
        this.boxCollider = GetComponent<BoxCollider>();
    }

    protected virtual void LoadRigibody()
    {
        if (this._rigibody != null) return;
        this._rigibody = GetComponent<Rigidbody>();
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
    }

}
