using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseScroll : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    private float speed;
    private bool isScrolling;

    private List<CaseCell> cells = new List<CaseCell>();

    public void Scroll()
    {
        if (isScrolling) return;

        GetComponent<RectTransform>().localPosition = new Vector2(1080, 0);

        speed = Random.Range(4, 5);
        isScrolling = true;

        if(cells.Count == 0)
            for(int i = 0; i < 50; i++)
            {
                cells.Add(Instantiate(prefab, transform).GetComponentInChildren<CaseCell>());
            }

        foreach(var cell in cells)
        {
            cell.SetUp();
        }
        StartCoroutine(MoveObject(3f));
    }

    IEnumerator MoveObject(float overTime)
    {
        float startTime = Time.time;
        while (Time.time < startTime + overTime)
        {
            //transform.position = Vector3.Lerp(source, target, (Time.time - startTime) / overTime);
            transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.left * 100, speed * (Time.time - startTime));
            yield return null;
        }
        isScrolling = false;
        this.GetReward();
    }

    protected virtual void GetReward()
    {
        int count = this.cells.Count - 1;
        foreach(RectTransform transform in transform)
        {
            Debug.Log(transform.position);
        }
    }
}
