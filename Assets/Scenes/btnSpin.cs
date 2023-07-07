using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnSpin : BaseButton
{
    [SerializeField] protected PickerWheel pickerWheel;
    protected override void OnClick()
    {
        pickerWheel.Spin();
        pickerWheel.OnSpinStart(() => Debug.Log("Spin start"));
    }
}
