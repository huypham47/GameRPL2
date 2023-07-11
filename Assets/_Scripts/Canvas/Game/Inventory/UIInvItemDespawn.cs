using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class UIInvItemDespawn : Despawn
{
    public bool isDespawn = false;
    protected override bool CanDespawn()
    {
        return isDespawn;
    }
}
