using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementAbstract : _MonoBehaviour
{
    [SerializeField] protected Vector3 targetPosition;
    
    public EnemyCtrl enemyCtrl;

    protected virtual void FixedUpdate()
    {
        this.GetTargetPosition();
    }

    protected virtual void GetTargetPosition()
    {
        this.targetPosition = PlayerCtrl.Instance.transform.position;
    }
}
