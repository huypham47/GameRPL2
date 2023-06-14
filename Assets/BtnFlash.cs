using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnFlash : BaseButton
{
    protected override void OnClick()
    {
        InputManager.Instance.SetPress();
    }
}
