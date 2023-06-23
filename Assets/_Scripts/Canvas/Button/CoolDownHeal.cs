using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CoolDownHeal : BaseCoolDown
{
    public override void Update()
    {
        this.timer = Mathf.Round(AbilityCtrl.Instance.AbilityHeal.Timer);
        this.delay = AbilityCtrl.Instance.AbilityHeal.Delay;
        if (AbilityCtrl.Instance.AbilityHeal.IsReady) this.coolDown = "OK";
        else this.coolDown = this.timer + " / " + this.delay;
        base.Update();
    }
}
