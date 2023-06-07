using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : _MonoBehaviour
{
    [SerializeField] protected float moveSpeed = 1f;
    public Vector3 direction = new Vector3(0, 0, 1);

    [SerializeField] protected BulletCtrl bulletCtrl;
    public BulletCtrl BulletCtrl => bulletCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBulletCtrl();
    }

    protected virtual void LoadBulletCtrl()
    {
        if (this.bulletCtrl != null) return;
        this.bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.moveSpeed = this.bulletCtrl.BulletSO.speed;
    }

    private void Update()
    {

        transform.parent.Translate(this.direction * this.moveSpeed * Time.deltaTime);
    }
}
