using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : Shooter
{
    
    [SerializeField] protected static PlayerShooting instance;
    public static PlayerShooting Instance => instance;


    protected override void Awake()
    {
        base.Awake();
        if (PlayerShooting.instance != null) return;
        PlayerShooting.instance = this;
    }

    protected override void SpawnBullet(Vector3 spawnPos, Quaternion rotation)
    {
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.bullet, spawnPos, rotation);
    }
}
