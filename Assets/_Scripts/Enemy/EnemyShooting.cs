using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : Shooting
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.delay = 2.5f;
    }

    protected override void SpawnBullet(Vector3 spawnPos, Quaternion rotation)
    {
        Transform newBullet = BulletSpawner.Instance.Spawn("Bullet_3", spawnPos, rotation);
    }
}
