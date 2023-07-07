using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLine : MonoBehaviour
{
    public Transform transform1;
    public void Update()
    {
        Debug.Log(transform.position);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform1.position);
        Debug.DrawRay(transform.position, transform1.position, Color.red);
        if (hit.collider != null)
        {
            Debug.Log(hit.collider);
        }
    }
}
