using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class damageCtrl : _MonoBehaviour
{
    private const float DISAPPEAR_TIMER_MAX = .5f;

    public Vector3 direction;

    [SerializeField] protected TextMeshPro textMeshPro;

    [SerializeField] protected float disappearTimer;
    [SerializeField] protected Color color;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        if (this.textMeshPro != null) return;
        this.textMeshPro = GetComponentInChildren<TextMeshPro>();
    }

    

    public void SetUp(bool isCrit, float damage, Vector3 direction)
    {
        textMeshPro.SetText(damage.ToString());
        if (isCrit)
        {
            textMeshPro.fontSize = 2;
            color = Color.red;
        }
        else
        {
            textMeshPro.fontSize = 1.5f;
            color = Color.yellow;
        }
        textMeshPro.color = color;
        disappearTimer = DISAPPEAR_TIMER_MAX;
        this.direction = direction;
        transform.localScale = new Vector3(.5f, .5f, .5f);
        transform.DOScale(new Vector3(1f, 1f, 1f), .2f);
        //transform.localScale -= Vector3.one * Time.deltaTime;
    }

    private void Update()
    {
        transform.position += this.direction * Time.deltaTime * 4f;
        disappearTimer -= Time.deltaTime;

        if (disappearTimer < 0)
        {
            float disappearSpeed = 3f;
            this.color.a -= disappearSpeed * Time.deltaTime;
            textMeshPro.color = color;
            if(color.a < 0)
            {
                FXSpawner.Instance.Despawn(transform);
            }
        }
    }
}
