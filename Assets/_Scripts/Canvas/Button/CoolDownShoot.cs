using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CoolDownShoot : BaseCoolDown
{
    public override void Update()
    {
        this.timer = Mathf.Round(AbilityCtrl.Instance.AbilityShoot.Timer);
        this.delay = AbilityCtrl.Instance.AbilityShoot.Delay;
        if (AbilityCtrl.Instance.AbilityShoot.IsReady) this.coolDown = "OK";
        else this.coolDown = this.timer + " / " + this.delay;
        base.Update();
    }
}
