using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityObjectCtrl : ShootableObjectCtrl

{
    [SerializeField] protected SpawnPoints spawnPoints;
    public SpawnPoints SpawnPoints => spawnPoints;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSpawnPoint();
    }

    protected virtual void LoadSpawnPoint()
    {
        if (this.spawnPoints != null) return;
        this.spawnPoints = GetComponentInChildren<SpawnPoints>();
    }
}
