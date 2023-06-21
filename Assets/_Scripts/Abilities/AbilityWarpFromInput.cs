using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityWarpFromInput : AbilityWarp
{
    
    protected override void Update()
    {
        base.Update();
        this.UpdateKey();
    }

    protected virtual void UpdateKey()
    {
        this.pressed = InputManager.Instance.Pressed;
        InputManager.Instance.ResetPressed();
    }
}
