using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoScoll : MonoBehaviour
{
    //public GameObject scroll;
    public ScrollRect scrollR;

    IEnumerator AutoSc()
    {
        yield return new WaitForSeconds(0.5f);
        float t0 = 0f;
        while (t0 < 2f)
        {
            t0 += Time.deltaTime;
            this.scrollR.horizontalNormalizedPosition = Mathf.Lerp(0, 1, t0);
            InfiniteScroll.Instance.HandleHorizontalScroll();
            
            yield return null;
        }
    }

    public void ButtonScroll()
    {
        //scroll.SetActive(true);
        StartCoroutine(AutoSc());
    }
}
