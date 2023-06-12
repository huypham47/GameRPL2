using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : _MonoBehaviour
{
    [SerializeField] protected AbilityObjectCtrl abilityObjectCtrl;
    public AbilityObjectCtrl AbilityObjectCtrl => abilityObjectCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAbilityObjectCtrl();
    }

    protected virtual void LoadAbilityObjectCtrl()
    {
        if (this.abilityObjectCtrl != null) return;
        this.abilityObjectCtrl = transform.parent.GetComponent<AbilityObjectCtrl>();
    }
}
