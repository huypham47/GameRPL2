using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXSpawner : Spawner
{
    private static FXSpawner instance;
    public static FXSpawner Instance { get => instance; }
    public static string smokeOne = "Smoke_1";
    public static string impactOne = "Impact_1";
    public static string impactTrue = "Impact_2";

    protected override void Awake()
    {
        base.Awake();
        if (FXSpawner.instance != null) return;
        FXSpawner.instance = this;
    }
}
