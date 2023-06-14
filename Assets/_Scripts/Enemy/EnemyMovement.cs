using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : EnemyMovementAbstract
{
    [SerializeField] protected float speed = 0.005f;
    [SerializeField] protected float distance = 0f;
    [SerializeField] protected float minDistance = 300f;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.Moving();
    }

    protected virtual void Moving()
    {
        this.distance = Vector3.Distance(transform.parent.position, targetPosition);
        if (this.distance < this.minDistance)
        {
            this.enemyCtrl.EnemyShooting.isShoot = true;
            return;
        }
        this.enemyCtrl.EnemyShooting.isShoot = false;
        Vector3 newPos = Vector3.Lerp(transform.parent.position, targetPosition, speed);
        transform.parent.position = newPos;
    }
}
