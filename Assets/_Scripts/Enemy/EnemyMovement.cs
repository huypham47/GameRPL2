using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : EnemyMovementAbstract
{
    [SerializeField] protected float speed = 0.009f;
    [SerializeField] protected float distance = 0f;
    [SerializeField] protected float minDistance = 4f;
    [SerializeField] protected float minDistanceShoot = 7.5f;

    protected override void LoadComponent()
    {
        base.LoadComponent();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.Moving();
    }

    protected virtual void Moving()
    {
        this.distance = Vector3.Distance(transform.parent.position, targetPosition);
        if(this.distance < this.minDistanceShoot)
            this.enemyCtrl.EnemyShooting.isShoot = true;
        else
            this.enemyCtrl.EnemyShooting.isShoot = false;
        if (this.distance < this.minDistance)
        {
            this.enemyCtrl.Animator.SetBool("isWalk", false);
            return;
        }
        this.enemyCtrl.Animator.SetBool("isWalk", true);
        Vector3 newPos = Vector3.Lerp(transform.parent.position, targetPosition, speed);
        transform.parent.position = newPos;
    }
}
