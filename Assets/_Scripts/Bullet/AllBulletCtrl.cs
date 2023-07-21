using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllBulletCtrl : _MonoBehaviour
{
    [SerializeField] protected AllBulletDamageSender damageSender;
    public AllBulletDamageSender DamageSender => damageSender;

    [SerializeField] protected BulletSO bulletSO;
    public BulletSO BulletSO => bulletSO;

    [SerializeField] protected BulletImpact impact;

    public BulletSpawner bulletSpawner;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadDamageSender();
        this.LoadBulletSO();
        this.LoadImpact();
    }

    public void SetUp()
    {
        this.impact.allBulletCtrl = this;
        this.damageSender.allBulletCtrl = this;
    }

    protected virtual void LoadImpact()
    {
        if (this.impact != null) return;
        this.impact = GetComponentInChildren<BulletImpact>();
    }

    protected virtual void LoadBulletSO()
    {
        if (this.bulletSO != null) return;
        string resPath = "bullet/" + transform.name;
        this.bulletSO = Resources.Load<BulletSO>(resPath);
        
    }

    protected override void Start()
    {
        base.Start();
        if (transform.name == "Boomerang")
            this.bulletSO.SetDamage(3);
        this.bulletSO.SetDamage(1);
    }

    protected virtual void LoadDamageSender()
    {
        if (this.damageSender != null) return;
        this.damageSender = GetComponentInChildren<AllBulletDamageSender>();
    }
}
