using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : _MonoBehaviour
{
    public PlayerCtrl playerCtrl;
    [SerializeField] protected float moveSpeed = 3.5f;
    [SerializeField] protected FixedJoystick fixedJoystick;

    protected override void LoadComponent()
    {
        base.LoadComponent();
    }
    
    private void FixedUpdate()
    {
        Vector2 direction = new Vector2(fixedJoystick.Horizontal, fixedJoystick.Vertical);
        direction.Normalize();
        this.playerCtrl.Rigidbody.velocity = new Vector3(direction.x * this.moveSpeed,
                                        0,
                                        direction.y * this.moveSpeed);

        if (fixedJoystick.Horizontal != 0 || fixedJoystick.Vertical != 0)
        {
            transform.parent.rotation = Quaternion.LookRotation(this.playerCtrl.Rigidbody.velocity);
            this.playerCtrl.Animator.SetBool("isWalk", true);
        }
        else
        {
            this.playerCtrl.Animator.SetBool("isWalk", false);
        }
    }
}
