using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangFly : _MonoBehaviour
{
    bool go = true;
    Vector3 currentTarget;
    [SerializeField] protected BoomerangCtrl boomerangCtrl;
    public BoomerangCtrl BoomerangCtrl => boomerangCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBulletCtrl();
    }

    protected virtual void LoadBulletCtrl()
    {
        if (this.boomerangCtrl != null) return;
        this.boomerangCtrl = transform.parent.GetComponent<BoomerangCtrl>();
    }

    private void OnEnable()
    {
        this.currentTarget = PlayerCtrl.Instance.transform.forward;
        this.timer = 0;
        this.go = true;
        this.boomerangCtrl.BoomerangDespawn.canDespawn = false;
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
            transform.parent.position = Vector3.MoveTowards(transform.parent.position, transform.position + currentTarget * 40f, Time.deltaTime * 400);
        }
        if (!go)
        {
            this.MoveReturn();
            if (timer >= 1f && transform.parent.position == PlayerCtrl.Instance.transform.position) this.boomerangCtrl.BoomerangDespawn.canDespawn = true;
        }
    }

    void MoveReturn()
    {
        transform.parent.position = Vector3.MoveTowards(transform.parent.position, PlayerCtrl.Instance.transform.position, Time.deltaTime * 200);
    }
}
