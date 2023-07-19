using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : PlayerAbstract
{
    [SerializeField] protected Rigidbody _rigidbody;
    [SerializeField] protected float moveSpeed = 4f;

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
        _rigidbody.velocity = new Vector3(InputManager.Instance.JoystickPos.x * this.moveSpeed,
                                        0,
                                        InputManager.Instance.JoystickPos.y * this.moveSpeed);

        if (InputManager.Instance.JoystickPos.x != 0 || InputManager.Instance.JoystickPos.y != 0)
        {
            transform.parent.rotation = Quaternion.LookRotation(_rigidbody.velocity);
            this.playerCtrl.Animator.SetBool("isWalk", true);
        }
        else this.playerCtrl.Animator.SetBool("isWalk", false);
    }
}
