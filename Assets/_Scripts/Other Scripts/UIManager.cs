using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : _MonoBehaviour
{
    [SerializeField] protected GameObject btnGameOver;
    public GameObject BtnGameOver => btnGameOver;

    [SerializeField] protected static UIManager instance;
    public static UIManager Instance => instance;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBtnGameOver();
    }

    protected override void Awake()
    {
        if (UIManager.instance != null) return;
        UIManager.instance = this;
    }

    protected virtual void LoadBtnGameOver()
    {
        this.btnGameOver = GameObject.Find("BtnGameOver");
        this.btnGameOver.SetActive(false);
    }
}
