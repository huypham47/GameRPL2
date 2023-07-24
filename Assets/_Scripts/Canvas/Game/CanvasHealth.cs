using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasHealth : _MonoBehaviour
{
    //[SerializeField] protected HealthBar enemyHealthBar;
    //public HealthBar HealthBar => enemyHealthBar;

    //protected override void LoadComponent()
    //{
    //    base.LoadComponent();
    //    this.LoadEnemyHealthBar();
    //}

    //protected virtual void LoadEnemyHealthBar()
    //{
    //    if (this.enemyHealthBar != null) return;
    //    this.enemyHealthBar = GetComponentInChildren<HealthBar>();
    //    Debug.Log(transform.parent.name);
    //    if (transform.parent.name == "Boss") this.enemyHealthBar.gameObject.SetActive(true);
    //    this.enemyHealthBar.gameObject.SetActive(false);
    //}

    [SerializeField] protected PlayerDame dame;
    public PlayerDame Dame => dame;


    private void LateUpdate()
    {
        transform.LookAt(transform.position + GameCtrl.Instance.MainCamera.transform.forward);
    }
}