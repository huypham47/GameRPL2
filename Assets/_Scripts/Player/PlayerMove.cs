using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : _MonoBehaviour
{
    public PlayerCtrl playerCtrl;
    [SerializeField] protected Rigidbody _rigidbody;
    [SerializeField] protected float moveSpeed = 3.5f;
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
    public float t;
    private void FixedUpdate()
    {
        Vector2 direction = new Vector2(fixedJoystick.Horizontal, fixedJoystick.Vertical);
        direction.Normalize();
        _rigidbody.velocity = new Vector3(direction.x * this.moveSpeed,
                                        0,
                                        direction.y * this.moveSpeed);

        if (fixedJoystick.Horizontal != 0 || fixedJoystick.Vertical != 0)
        {
            t += Time.fixedDeltaTime;
            transform.parent.rotation = Quaternion.LookRotation(_rigidbody.velocity);
            this.playerCtrl.Animator.SetBool("isWalk", true);
        }
        else
        {
            this.playerCtrl.Animator.SetBool("isWalk", false);
        }
    }
}
