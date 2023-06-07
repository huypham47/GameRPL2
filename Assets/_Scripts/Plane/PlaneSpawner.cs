using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSpawner : _MonoBehaviour
{
    [SerializeField] protected List<Transform> planes;
    protected float minDistance = 10000f;
    [SerializeField] protected float disPlane = 10000f;
    protected int index = 0;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlane();
    }

    protected virtual void LoadPlane()
    {
        if (planes.Count > 0) return;
        foreach(Transform plane in transform)
        {
            planes.Add(plane);
        }
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < 4; i++)
        {
            disPlane = Vector3.Distance(PlayerCtrl.Instance.transform.position, planes[i].position);
            if (this.minDistance > disPlane)
            {
                this.minDistance = disPlane;
                index = i;
            }
        }

        if (index != 0)
        {
            (planes[0], planes[index]) = (planes[index], planes[0]);
        }

        if (minDistance > 200)
        {
            Vector3 transformForward = PlayerCtrl.Instance.transform.position - planes[0].position;
            transformForward = new Vector3(transformForward.x / Mathf.Abs(transformForward.x), 0, transformForward.z / Mathf.Abs(transformForward.z));
            Vector3 newPos = this.planes[0].position;
            this.planes[1].position = new Vector3(newPos.x + transformForward.x * 5000,
                                                  0,
                                                  newPos.z + transformForward.z * 5000);
            this.planes[2].position = new Vector3(newPos.x + transformForward.x * 5000,
                                                  0,
                                                  newPos.z);
            this.planes[3].position = new Vector3(newPos.x,
                                                  0,
                                                  newPos.z + transformForward.z * 5000);
        }

        
        this.minDistance = 10000f;
    }

    
}
