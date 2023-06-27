using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : _MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance => instance;
    [SerializeField] protected bool isPause = true;

    protected override void Awake()
    {
        base.Awake();
        GameManager.instance = this;
    }

    public virtual void TogglePause()
    {
        this.isPause = !this.isPause;
        if (this.isPause) Pause();
        else this.Continue();
    }

    public virtual void Pause()
    {
        Time.timeScale = 0;

    }

    public virtual void Continue()
    {
        Time.timeScale = 1;
    }
}
