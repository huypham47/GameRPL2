using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : _MonoBehaviour
{
    [SerializeField] protected float timer = 0;
    public float delay = 0.4f;
    public bool isShoot = true;

    private void FixedUpdate()
    {
        this.IsShooting();
    }

    protected virtual void IsShooting()
    {
        if (!isShoot) return;
        timer += Time.fixedDeltaTime;
        if (timer < delay) return;
        timer = 0;

        Vector3 spawnPos = transform.position;
        Quaternion rotation = transform.parent.rotation;
        this.SpawnBullet(spawnPos, rotation);
    }

    protected virtual void SpawnBullet(Vector3 spawnPos, Quaternion rotation)
    {
        //Override
    }
}
