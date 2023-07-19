using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : AbilityObjectCtrl
{
    [SerializeField] protected AnimationEvents animationEvent;
    public AnimationEvents AnimationEvent => animationEvent;

    [SerializeField] protected Animator animator;
    public Animator Animator => animator;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAnimationEvent();
        this.LoadAnimator();
    }

    protected virtual void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = GetComponentInChildren<Animator>();
    }

    protected virtual void LoadAnimationEvent()
    {
        if (this.animationEvent != null) return;
        this.animationEvent = GetComponentInChildren<AnimationEvents>();
    }
}
