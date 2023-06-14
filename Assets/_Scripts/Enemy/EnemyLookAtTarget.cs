using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLookAtTarget : EnemyMovementAbstract
{
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.LookAtTarget();
    }

    protected virtual void LookAtTarget()
    {
        transform.parent.LookAt(targetPosition, Vector3.up);
    }
}
