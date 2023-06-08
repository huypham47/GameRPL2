using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelByScore : Level
{
    protected virtual void FixedUpdate()
    {
        this.Leveling();
    }

    protected override void Start()
    {
        base.Start();
        Debug.Log((int)0 / 15);
        Debug.Log((int)5 / 15);
        Debug.Log((int)14 / 15);
        Debug.Log((int)15 / 15);
    }

    protected virtual void Leveling()
    {
        int newLevel = TextScore.Instance.Score / 15 + 1;
        this.LevelSet(newLevel);
    }
}