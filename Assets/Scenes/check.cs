using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check : MonoBehaviour
{
    
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(-transform.forward * 100, transform.forward * 100, out hit))
        {
            Debug.Log(hit.collider);
        }

        Debug.Log(hit.collider);
        Debug.Log(transform.forward);
        Debug.DrawRay(-transform.forward*100, transform.forward*100);
    }
}
