using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScore : _MonoBehaviour
{
    
    private static TextScore instance;
    public static TextScore Instance => instance;

    [SerializeField] protected int score = 13;
    public int Score => score;

    [SerializeField] protected Text textScore;

    public bool canUpgradeScore = true;

    protected override void Awake()
    {
        base.Awake();
        if (TextScore.instance != null) return;
        TextScore.instance = this;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadTextScore();
    }

    protected virtual void LoadTextScore()
    {
        if (this.textScore != null) return;
        this.textScore = GetComponent<Text>();
    }

    public virtual void UpdateScore()
    {
        if (!canUpgradeScore) return;
        this.score++;
        this.textScore.text = score.ToString();
    }

    public virtual void SetScore(int score)
    {
        this.score = score;
        this.textScore.text = score.ToString();
    }
}
