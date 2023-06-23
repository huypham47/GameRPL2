using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangFly : _MonoBehaviour
{
    [SerializeField] protected bool go = true;
    [SerializeField] protected Vector3 currentTarget;
    [SerializeField] protected AllBulletCtrl allBulletCtrl;
    public AllBulletCtrl AllBulletCtrl => allBulletCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBulletCtrl();
    }

    protected virtual void LoadBulletCtrl()
    {
        if (this.allBulletCtrl != null) return;
        this.allBulletCtrl = transform.parent.GetComponent<AllBulletCtrl>();
    }

    private void OnEnable()
    {
        this.currentTarget = PlayerCtrl.Instance.transform.forward;
        this.timer = 0;
        this.go = true;
        this.allBulletCtrl.Despawn.canDespawn = false;
        StartCoroutine(BoomerangReturn());
    }

    public float timer = 0;

    IEnumerator BoomerangReturn()
    {
        yield return new WaitForSeconds(1.5f);
        this.go = !go;
    }

    void Update()
    {
        timer += Time.deltaTime;
        transform.parent.Rotate(0, Time.deltaTime * 500, 0);

        if (go)
        {
            transform.parent.position = Vector3.MoveTowards(transform.parent.position, transform.position + currentTarget * 5f, Time.deltaTime * 4);
        }
        if (!go)
        {
            this.MoveReturn();
            if (timer >= 1f && transform.parent.position == PlayerCtrl.Instance.transform.position) this.allBulletCtrl.Despawn.canDespawn = true;
        }
    }

    void MoveReturn()
    {
        transform.parent.position = Vector3.MoveTowards(transform.parent.position, PlayerCtrl.Instance.transform.position, Time.deltaTime * 4);
    }
}
