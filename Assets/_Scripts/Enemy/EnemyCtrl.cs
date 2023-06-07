using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : _MonoBehaviour
{
    [SerializeField] protected EnemyDespawn enemyDespawn;
    public EnemyDespawn EnemyDespawn => enemyDespawn;

    [SerializeField] protected EnemySO enemySO;
    public EnemySO EnemySO => enemySO;

    [SerializeField] protected CanvasHealth canvasHealth;
    public CanvasHealth CanvasHealth => canvasHealth;

    [SerializeField] protected EnemyDamageSender enemyDamageSender;
    public EnemyDamageSender EnemyDamageSender => enemyDamageSender;

    [SerializeField] protected EnemyShooting enemyShooting;
    public EnemyShooting EnemyShooting => enemyShooting;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyDespawn();
        this.LoadEnemySO();
        this.LoadHealthBar();
        this.LoadEnemyDamageSender();
        this.LoadEnemyShooting();
    }

    protected virtual void LoadEnemyShooting()
    {
        if (this.enemyShooting != null) return;
        this.enemyShooting = GetComponentInChildren<EnemyShooting>();
    }

    protected virtual void LoadEnemyDamageSender()
    {
        if (this.enemyDamageSender != null) return;
        this.enemyDamageSender = GetComponentInChildren<EnemyDamageSender>();
    }

    private void OnEnable()
    {
        this.canvasHealth.HealthBar.gameObject.SetActive(false);
    }

    protected virtual void LoadEnemyDespawn()
    {
        if (this.enemyDespawn != null) return;
        this.enemyDespawn = GetComponentInChildren<EnemyDespawn>();
    }

    protected virtual void LoadEnemySO()
    {
        if (this.enemySO != null) return;
        string resPath = "Enemy/" + transform.name;
        this.enemySO = Resources.Load<EnemySO>(resPath);
    }

    protected virtual void LoadHealthBar()
    {
        if (this.canvasHealth != null) return;
        this.canvasHealth = GetComponentInChildren<CanvasHealth>();
    }

}
