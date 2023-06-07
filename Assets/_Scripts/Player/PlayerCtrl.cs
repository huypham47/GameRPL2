using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : _MonoBehaviour
{
    private static PlayerCtrl instance;
    public static PlayerCtrl Instance => instance;

    [SerializeField] protected PlayerDamageReceiver playerDamageReceiver;
    public PlayerDamageReceiver PlayerDamageReceiver => playerDamageReceiver;

    protected override void Awake()
    {
        base.Awake();
        if (PlayerCtrl.instance != null) return;
        PlayerCtrl.instance = this;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerDamageReceiver();
    }

    protected virtual void LoadPlayerDamageReceiver()
    {
        if (this.playerDamageReceiver != null) return;
        this.playerDamageReceiver = GetComponentInChildren<PlayerDamageReceiver>();
    }
}
