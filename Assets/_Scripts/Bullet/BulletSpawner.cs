using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
    private static BulletSpawner instance;
    public static BulletSpawner Instance { get => instance; }
    public static string bullet = "Bullet_1";
    public static float speed = 0;

    public virtual void SetBullet()
    {
        BulletSpawner.bullet = "Bullet_1";
        PlayerShooting.Instance.delay = 0.4f;
    }

    public virtual void SetBoomerang()
    {
        BulletSpawner.bullet = "Boomerang";
        PlayerShooting.Instance.delay = 3f;
    }

    protected override void Awake()
    {
        base.Awake();
        if (BulletSpawner.instance != null) return;
        BulletSpawner.instance = this;
    }
}
