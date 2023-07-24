using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIReward : _MonoBehaviour
{
    private static UIReward instance;
    public static UIReward Instance => instance;

    [SerializeField] protected UIRewradCtrl rewardCtrl;

    [SerializeField] protected bool isOpen = true;
    public bool IsOpen => isOpen;

    protected override void Awake()
    {
        base.Awake();
        if (UIReward.instance != null) return;
        UIReward.instance = this;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        if (this.rewardCtrl != null) return;
        this.rewardCtrl = transform.parent.GetComponent<UIRewradCtrl>();
    }

    protected override void Start()
    {
        base.Start();
        //this.rewardCtrl.AutoScroll.StartCorou();
        this.Toggle();
        //this.Toggle();
    }

    public virtual void Toggle()
    {
        this.isOpen = !this.isOpen;
        if (this.isOpen) Open();
        else this.Close();
    }

    public virtual void Open()
    {
        this.rewardCtrl.SetAlphaCanvas(1);
        this.rewardCtrl.ScrollContent.ResizeContent();
        this.rewardCtrl.AutoScroll.StartCorou();
    }

    public virtual void Close()
    {
        this.rewardCtrl.SetAlphaCanvas(0);
    }

    public virtual void ShowReward(EnemyCtrl enemyCtrl)
    {
        List<ItemDropRate> items = enemyCtrl.EnemySO.upgradeLevels[MapLevel.Instance.LevelCurrent-1].dropList;
        Debug.Log(items.Count + " " + MapLevel.Instance.LevelCurrent);
        RewardSpawner spawner = this.rewardCtrl.RewardSpawner;
        if (items.Count < 1) return;
        for (int i = 0; i < items.Count; i++)
        {
            spawner.SpawnItem(items[i]);
        }
    }
}
