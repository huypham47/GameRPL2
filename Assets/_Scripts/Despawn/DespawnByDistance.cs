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
        if (transform.parent.name == "Health")
            Debug.Log(transform.parent.name + " " + transform.parent.position + " " + distance+ " " + disLitmit);
        if (this.distance > this.disLitmit)
        {
            if (transform.parent.name == "Health") Debug.Log("true");
            return true;
        }
        if (transform.parent.name == "Health")  Debug.Log("false");
        return false;
    }
}
