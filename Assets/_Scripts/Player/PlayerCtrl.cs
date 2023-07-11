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

    [SerializeField] protected PlayerSO playerSO;
    public PlayerSO PlayerSO => playerSO;

    [SerializeField] protected AnimationEvents animationEvent;
    public AnimationEvents AnimationEvent => animationEvent;

    [SerializeField] protected SkinnedMeshRenderer meshCharacter;
    public SkinnedMeshRenderer MeshCharacter => meshCharacter;

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
        this.LoadPlayerSO();
        this.LoadAnimationEvent();
        this.LoadMeshCharacter();
    }

    protected virtual void LoadMeshCharacter()
    {
        if (this.meshCharacter != null) return;
        this.meshCharacter = GameObject.Find("CharacterSkin").GetComponentInChildren<SkinnedMeshRenderer>();
    }

    protected virtual void LoadPlayerDamageReceiver()
    {
        if (this.playerDamageReceiver != null) return;
        this.playerDamageReceiver = GetComponentInChildren<PlayerDamageReceiver>();
    }

    protected virtual void LoadAnimationEvent()
    {
        if (this.animationEvent != null) return;
        this.animationEvent = GetComponentInChildren<AnimationEvents>();
    }

    protected virtual void LoadPlayerSO()
    {
        if (this.playerSO != null) return;
        string resPath = "Player/" + transform.name;
        this.playerSO = Resources.Load<PlayerSO>(resPath);
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

    protected override void Start()
    {
        string character = PlayerPrefs.GetString("Character");
        ItemProfileSO item = ItemProfileSO.FindByItemName(character);
        Debug.Log(item);
        this.meshCharacter.sharedMesh = item.mesh;
        Debug.Log(item.mesh);
    }
}
