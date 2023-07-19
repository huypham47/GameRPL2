using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : _MonoBehaviour
{
    [SerializeField] protected float moveSpeed = 20f;
    public Vector3 direction = new Vector3(0, 0, 1);

    //[SerializeField] protected AllBulletCtrl allBulletCtrl;
    //public AllBulletCtrl AllBulletCtrl => allBulletCtrl;

    //protected override void LoadComponent()
    //{
    //    base.LoadComponent();
    //    this.LoadBulletCtrl();
    //}

    //protected virtual void LoadBulletCtrl()
    //{
    //    if (this.allBulletCtrl != null) return;
    //    this.allBulletCtrl = transform.parent.GetComponent<AllBulletCtrl>();
    //}

    private void Update()
    {
        transform.parent.Translate(this.moveSpeed * Time.deltaTime * this.direction);
    }
}
