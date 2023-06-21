using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnClosePlayerInform : BaseButton
{
    protected override void OnClick()
    {
        UIInform.Instance.Toggle();
    }
}
