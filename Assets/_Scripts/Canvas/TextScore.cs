using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextScore : _MonoBehaviour
{
    [SerializeField] protected int score = 0;
    public int Score => score;

    [SerializeField] protected TMP_Text textScore;

    private static TextScore instance;
    public static TextScore Instance => instance;

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
        this.textScore = GetComponent<TMP_Text>();
    }

    public virtual void UpdateScore()
    {
        if (!canUpgradeScore) return;
        this.score++;
        this.textScore.text = score.ToString();
    }

}
