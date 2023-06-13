using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : _MonoBehaviour
{
    private static PlayerCtrl instance;
    public static PlayerCtrl Instance => instance;

    [SerializeField] protected PlayerDamageReceiver playerDamageReceiver;
    public PlayerDamageReceiver PlayerDamageReceiver => playerDamageReceiver;

    [SerializeField] protected AbilityCtrl abilityCtrl;
    public AbilityCtrl AbilityCtrl => abilityCtrl;

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
        this.LoadAbilities();
    }

    protected virtual void LoadPlayerDamageReceiver()
    {
        if (this.playerDamageReceiver != null) return;
        this.playerDamageReceiver = GetComponentInChildren<PlayerDamageReceiver>();
    }

    protected virtual void LoadAbilities()
    {
        if (this.abilityCtrl != null) return;
        this.abilityCtrl = GetComponentInChildren<AbilityCtrl>();
    }
}
