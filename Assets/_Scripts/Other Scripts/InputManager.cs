using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : _MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance => instance;

    [SerializeField] protected Vector2 joystickPos;
    public Vector2 JoystickPos => joystickPos;

    [SerializeField] protected Button btnFlash;

    [SerializeField] protected bool pressed = false;
    public bool Pressed => pressed;

    [SerializeField] protected FixedJoystick fixedJoystick;

    protected override void Awake()
    {
        base.Awake();
        InputManager.instance = this;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadJoystick();
        this.LoadBtnFlash();
    }

    
    private void FixedUpdate()
    {
        this.GetJoystickPos();
    }

    protected virtual void LoadJoystick()
    {
        if (fixedJoystick != null) return;
        this.fixedJoystick = FindObjectOfType<FixedJoystick>();
    }

    protected virtual void LoadBtnFlash()
    {
        if (btnFlash != null) return;
        GameObject buttonflash = GameObject.Find("BtnFlash");
        this.btnFlash = buttonflash.GetComponent<Button>();
        btnFlash.onClick.AddListener(TaskOnClick);
    }

    protected virtual void GetJoystickPos()
    {
        this.joystickPos = new Vector2(fixedJoystick.Horizontal, fixedJoystick.Vertical);
    }

    public virtual void TaskOnClick()
    {
        this.pressed = true;
    }

    public virtual void ResetPressed()
    {
        this.pressed = false;
    }
}