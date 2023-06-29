using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : AbilityObjectCtrl
{
    [SerializeField] protected AnimationEvents animationEvent;
    public AnimationEvents AnimationEvent => animationEvent;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAnimationEvent();
    }

    protected virtual void LoadAnimationEvent()
    {
        if (this.animationEvent != null) return;
        this.animationEvent = GetComponentInChildren<AnimationEvents>();
    }
}
