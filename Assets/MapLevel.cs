using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLevel : LevelByScore
{
    [SerializeField] private static MapLevel instace;
    public static MapLevel Instace => instace;

    protected override void Start()
    {
        base.Start();
        if (MapLevel.instace != null) return;
        MapLevel.instace = this;
    }

    public override void LevelUp()
    {
        base.LevelUp();
        PlayerCtrl.Instance.PlayerDamageReceiver.AddMaxHP();
        PlayerCtrl.Instance.PlayerDamageReceiver.Add(1);
    }
}
