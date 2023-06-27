using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnCloseInventory : BaseButton
{
    protected override void OnClick()
    {
        Debug.Log("on click");
        UIInventory.Instance.Toggle();
    }
}
