using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScroll : _MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] protected List<RectTransform> transforms;
    [SerializeField] protected List<ItemDropRate> rewardList;

    protected virtual void LoadTranform()
    {
        if (transforms.Count > 0) return;
        foreach(RectTransform transform in transform)
        {
            this.transforms.Add(transform);
        }
    }

    //private void FixedUpdate()
    //{
    //    Debug.Log("Fixed");
    //    //this.HandleHorizontalScroll();
    //}
    private void Update()
    {
        this.HandleHorizontalScroll();
    }

    public virtual void StartCorou()
    {
        this.LoadTranform();
        StartCoroutine(Scroll());
    }

    IEnumerator Scroll()
    {
       // yield return new WaitForSeconds(0.5f);

        float t0 = 0f;
        while (t0 < 10f)
        {
            t0 += Time.fixedDeltaTime;
            this.Scroll(t0);
            yield return null;
        }
    }

    protected virtual void Scroll(float t0)
    {

        foreach (RectTransform transform in transforms)
        {
            Vector2 pos = transform.anchoredPosition;
            //Debug.Log("Time.deltaTime" + Time.deltaTime);
            //Debug.Log("first: " + pos);
            transform.anchoredPosition = Vector2.Lerp(pos, pos - new Vector2(50, 0), t0);
            //Debug.Log("last: " + pos);
        }
    }

    private void HandleHorizontalScroll()
    {
        int currItemIndex = 0;
        RectTransform currItem = transforms[currItemIndex];
        if (!ReachedThreshold(currItem))
        {
            Debug.Log(false);
            return;
        }

        int endItemIndex = transforms.Count - 1;
        RectTransform endItem = transforms[endItemIndex];
        Vector2 newPos = endItem.anchoredPosition;
        Debug.Log(newPos);
        newPos.x = endItem.anchoredPosition.x + 210;

        currItem.anchoredPosition = newPos;
        currItem.SetSiblingIndex(endItemIndex);
    }

    private bool ReachedThreshold(RectTransform item)
    {
        Debug.Log(item.anchoredPosition.x);
        //float negXThreshold = transform.position.x - 200 * 0.5f - 10;
        //return item.anchoredPosition.x + 200 * 0.5f < negXThreshold;
        return item.anchoredPosition.x <= -50;
    }
}
