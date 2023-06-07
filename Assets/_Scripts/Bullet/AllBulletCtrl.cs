using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllBulletCtrl : _MonoBehaviour
{
    [SerializeField] protected DamageSender damageSender;
    public DamageSender DamageSender => damageSender;

    [SerializeField] protected Despawn despawn;
    public Despawn Despawn => despawn;

    [SerializeField] protected BulletSO bulletSO;
    public BulletSO BulletSO => bulletSO;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadDamageSender();
        this.LoadDespawn();
        this.LoadBulletSO();
    }

    protected virtual void LoadDespawn()
    {
        if (this.despawn != null) return;
        this.despawn = GetComponentInChildren<Despawn>();
    }


    protected virtual void LoadBulletSO()
    {
        if (this.bulletSO != null) return;
        string resPath = "bullet/" + transform.name;
        this.bulletSO = Resources.Load<BulletSO>(resPath);
    }

    protected virtual void LoadDamageSender()
    {
        if (this.damageSender != null) return;
        this.damageSender = GetComponentInChildren<DamageSender>();
    }
}
