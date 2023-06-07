using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : _MonoBehaviour
{
    [SerializeField] protected Vector3 targetPosition;
    [SerializeField] protected float speed = 0.005f;
    [SerializeField] protected float distance = 0f;
    [SerializeField] protected float minDistance = 300f;
    [SerializeField] protected EnemyCtrl enemyCtrl;
    public EnemyCtrl EnemyCtrl => enemyCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyCtrl();
    }

    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
    }

    protected virtual void FixedUpdate()
    {
        this.GetTargetPosition();
        this.LookAtTarget();
        this.Moving();
    }

    protected virtual void GetTargetPosition()
    {
        this.targetPosition = PlayerCtrl.Instance.transform.position;
    }

    protected virtual void LookAtTarget()
    {
        transform.parent.LookAt(targetPosition, Vector3.up);
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


