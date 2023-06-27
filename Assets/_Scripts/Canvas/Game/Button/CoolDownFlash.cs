using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CoolDownFlash : BaseCoolDown
{
    public override void Update()
    {
        this.timer = Mathf.Round(AbilityCtrl.Instance.AbilityWarp.Timer);
        this.delay = AbilityCtrl.Instance.AbilityWarp.Delay;
        if (AbilityCtrl.Instance.AbilityWarp.IsReady) this.coolDown = "OK";
        else this.coolDown = this.timer + " / " + this.delay;
        base.Update();
    }
}
