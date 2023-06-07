using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : HealthBar
{
    public bool canAdd = false;
    private void OnEnable()
    {
        StartCoroutine(DisableHealthBar());
    }

    IEnumerator DisableHealthBar()
    {
        yield return new WaitForSeconds(3f);
        transform.gameObject.SetActive(false);
        canAdd = true;
    }
}
