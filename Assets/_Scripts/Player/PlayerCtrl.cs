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

    [SerializeField] protected Inventory inventory;
    public Inventory Inventory => inventory;

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
        this.LoadInventory();
    }

    protected virtual void LoadPlayerDamageReceiver()
    {
        if (this.playerDamageReceiver != null) return;
        this.playerDamageReceiver = GetComponentInChildren<PlayerDamageReceiver>();
    }

    protected virtual void LoadInventory()
    {
        if (this.inventory != null) return;
        this.inventory = GetComponentInChildren<Inventory>();
    }

    protected virtual void LoadAbilities()
    {
        if (this.abilityCtrl != null) return;
        this.abilityCtrl = GetComponentInChildren<AbilityCtrl>();
    }
}
