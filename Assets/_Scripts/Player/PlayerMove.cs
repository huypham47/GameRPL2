using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : _MonoBehaviour
{
    public PlayerCtrl playerCtrl;
    [SerializeField] protected Rigidbody _rigidbody;
    [SerializeField] protected float moveSpeed = 4f;
    [SerializeField] protected FixedJoystick fixedJoystick;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadRigidbody();
    }

    protected virtual void LoadRigidbody()
    {
        if (this._rigidbody != null) return;
        this._rigidbody = this.playerCtrl.transform.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float rate = Mathf.Sqrt(Mathf.Pow(fixedJoystick.Horizontal, 2) + Mathf.Pow(fixedJoystick.Vertical, 2));
        if (rate == 0) rate = 1;
        _rigidbody.velocity = new Vector3(fixedJoystick.Horizontal / rate * this.moveSpeed,
                                        0,
                                        fixedJoystick.Vertical /rate * this.moveSpeed);

        if (fixedJoystick.Horizontal != 0 || fixedJoystick.Vertical != 0)
        {
            transform.parent.rotation = Quaternion.LookRotation(_rigidbody.velocity);
            this.playerCtrl.Animator.SetBool("isWalk", true);
        }
        else this.playerCtrl.Animator.SetBool("isWalk", false);
    }
}
