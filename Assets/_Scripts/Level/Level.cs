using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : _MonoBehaviour
{
    [SerializeField] protected int levelCurrent = 1;
    [SerializeField] protected int levelMax = 99;
    public int LevelCurrent => levelCurrent;
    public int LevelMax => levelMax;

    public virtual void LevelUp()
    {
        this.levelCurrent++;
        this.LimitLevel();
    }

    public virtual void LevelSet(int newLevel)
    {
        this.levelCurrent = newLevel;
        this.LimitLevel();
    }

    protected virtual void LimitLevel()
    {
        if (this.levelCurrent > this.levelMax) this.levelCurrent = this.levelMax;
        if (this.levelCurrent < 1) this.levelCurrent = 1;
    }
}
