using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;

public class GameCtrl : _MonoBehaviour
{
    private static GameCtrl instance;
    public static GameCtrl Instance => instance;

    [SerializeField] protected Camera mainCamera;
    public Camera MainCamera => mainCamera;

    [SerializeField] protected Transform player;
    public Transform Player => player;

    protected override void Awake()
    {
        base.Awake();
        if (GameCtrl.instance != null) return;
        GameCtrl.instance = this;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayer();
        this.LoadCamera();
    }

    protected virtual void LoadCamera()
    {
        if (this.mainCamera != null) return;
        this.mainCamera = GameObject.FindObjectOfType<Camera>();
    }

    protected virtual void LoadPlayer()
    {
        if (this.player != null) return;
        this.player = GameObject.Find("Player").transform;
    }
}
