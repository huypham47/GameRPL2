using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelByScore : Level
{

    public virtual void Leveling()
    {
        if(TextScore.Instance.Score % 15 == 0)
            this.LevelUp();
    }
}