using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : _MonoBehaviour
{
    [SerializeField] protected Rigidbody _rigidbody;
    [SerializeField] protected Animator animator;
    [SerializeField] protected float moveSpeed;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.moveSpeed = 2f;
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(InputManager.Instance.JoystickPos.x * this.moveSpeed,
                                        0,
                                        InputManager.Instance.JoystickPos.y * this.moveSpeed);

        if (InputManager.Instance.JoystickPos.x != 0 || InputManager.Instance.JoystickPos.y != 0)
        {
            transform.parent.rotation = Quaternion.LookRotation(_rigidbody.velocity);
        }
    }


}
