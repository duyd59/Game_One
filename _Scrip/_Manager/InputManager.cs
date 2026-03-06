using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.Animations;

public class InputManager : ObjOn1
{
    [SerializeField]protected float horizontal;
    public float Horizontal => horizontal;
    [SerializeField]protected bool keySpace;
    public bool KeySpace => keySpace;
    [SerializeField]protected bool leftMouse;
    public bool LeftMouse => leftMouse;

    [SerializeField]protected bool rightMouse;
    public bool RightMouse => rightMouse;

    
    public static InputManager Instance;

    protected override void Awake()
    {
        base.Awake();
        this.LoadInstance();
    }

    protected virtual void LoadInstance()
    {
        if(InputManager.Instance!=null) return;
        InputManager.Instance = this; 
    }
    
    protected virtual void Update()
    {
        this.LoadMoverments();
        this.LoadKeySpace();
        this.LoadMouse();
        this.LoadMouseRight();
    }

    protected virtual void LoadMoverments()
    {
        this.horizontal = Input.GetAxis("Horizontal");
    }

    protected virtual bool LoadKeySpace()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
             return this.keySpace = true;
        }

        return this.keySpace = false;
    }

    protected virtual bool LoadMouse()
    {
        if (Input.GetMouseButton(0))
        {
            return this.leftMouse = true;
        }
        return this.leftMouse = false;
    }

    protected virtual bool LoadMouseRight()
    {
        if (Input.GetMouseButtonDown(1))
        {
            return this.rightMouse = true;
        }
        return this.rightMouse = false;
    }
}
