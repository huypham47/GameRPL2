using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : _MonoBehaviour
{
    private static DropManager instance;
    public static DropManager Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (DropManager.instance != null) return;
        DropManager.instance = this;
    }

    public virtual void Drop(DropRate dropRate)
    {
        Debug.Log(dropRate.itemSO.itemName);
    }
}
