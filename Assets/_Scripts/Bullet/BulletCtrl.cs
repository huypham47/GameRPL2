using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : AllBulletCtrl
{
    //[SerializeField] protected BulletDamageSender bulletDamageSender;
    //public BulletDamageSender BulletDamageSender => bulletDamageSender;

    //[SerializeField] protected BulletDespawn bulletDespawn;
    //public BulletDespawn BulletDespawn => bulletDespawn;

    //[SerializeField] protected BulletSO bulletSO;
    //public BulletSO BulletSO => bulletSO;

    ////[SerializeField] protected Transform shooter;
    ////public Transform Shooter => shooter;

    //protected override void LoadComponent()
    //{
    //    base.LoadComponent();
    //    this.LoadDamageSender();
    //    this.LoadBulletDespawn();
    //    this.LoadBulletSO();
    //}

    //protected virtual void LoadDamageSender()
    //{
    //    if (this.bulletDamageSender != null) return;
    //    this.bulletDamageSender = GetComponentInChildren<BulletDamageSender>();
    //}

    //protected virtual void LoadBulletDespawn()
    //{
    //    if (this.bulletDespawn != null) return;
    //    this.bulletDespawn = GetComponentInChildren<BulletDespawn>();
    //}

    //protected virtual void LoadBulletSO()
    //{
    //    if (this.bulletSO != null) return;
    //    string resPath = "bullet/" + transform.name;
    //    this.bulletSO = Resources.Load<BulletSO>(resPath);
    //}

    //protected virtual void SetShooter(Transform shooter)
    //{
    //    this.shooter = shooter;
    //}
}
