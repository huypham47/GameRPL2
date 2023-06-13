using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityCtrl : _MonoBehaviour
{
    [SerializeField] protected BaseAbility baseAbility;
    public BaseAbility BaseAbility => baseAbility;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBaseAbility();
    }

    protected virtual void LoadBaseAbility()
    {
        if (this.baseAbility != null) return;
        this.baseAbility = GetComponentInChildren<BaseAbility>();
    }
}
