using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camtarget : _MonoBehaviour
{
    private void LateUpdate()
    {
        transform.LookAt(transform.position + GameCtrl.Instance.MainCamera.transform.forward);
    }
}
