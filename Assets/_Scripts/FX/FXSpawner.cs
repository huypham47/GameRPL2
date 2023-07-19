using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FXSpawner : Spawner
{
    private static FXSpawner instance;
    public static FXSpawner Instance { get => instance; }
    public static string smokeOne = "Smoke_1";
    public static string impactOne = "Impact_1";
    public static string impactTrue = "Impact_2";
    public static string impactThree = "Impact_3";

    protected override void Awake()
    {
        base.Awake();
        if (FXSpawner.instance != null) return;
        FXSpawner.instance = this;
    }

    public void SpawnDamage(bool isCrit, float damage, Vector3 diretion)
    {
        Transform prefab = Spawn(impactThree, transform.position, transform.rotation);
        damageCtrl damageCtrl = prefab.GetComponent<damageCtrl>();
        damageCtrl.SetUp(isCrit, damage, diretion);

        //if (isCrit) textMeshPro.color = Color.red;
        //else textMeshPro.color = Color.yellow;
        //textMeshPro.text = damage.ToString();
    }
}
