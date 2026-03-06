using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayMoverment : ObjOn1
{
    [SerializeField] protected PlayerCtl playerCtl;
    [SerializeField] protected float Speed = 5f;
    [SerializeField]public float JumpPower = 5f;
    [SerializeField]protected Vector3 ClingPos;
    
    [SerializeField]protected LayerMask layerMask;

    protected override void Loadcomponents()
    {
        base.Loadcomponents();
        this.LoadPlayerCtl();
    }

    protected virtual void LoadPlayerCtl()
    {
        if(this.playerCtl != null) return;
        this.playerCtl = transform.GetComponentInParent<PlayerCtl>();
    }

    protected virtual void Update()
    {
        this.Moving();
        this.Jumping();
        this.Climbing();
        this.Clinging();
    }

    protected virtual void Moving()
    {
        float GetInitmove = InputManager.Instance.Horizontal;
        this.CheckFace(GetInitmove);    
        playerCtl.Rigi.velocity = new Vector2(GetInitmove * Speed,playerCtl.Rigi.velocity.y);
        playerCtl.SetAnimation();
    }

    protected virtual void Jumping()
    {
        playerCtl.SetGround();
        if (InputManager.Instance.KeySpace && playerCtl.IsGround)
        { 
            Vector2 JumpVt = new Vector2(playerCtl.Rigi.velocity.x,this.JumpPower);
            playerCtl.Rigi.AddForce(JumpVt,ForceMode2D.Impulse);
            playerCtl.SetAnimation();
        }
    }

    protected virtual void CheckFace(float FaceCondition)
    {
        float ScaleX = Mathf.Abs(transform.parent.localScale.x);
        Vector3 DefaultScale = new Vector3(ScaleX,transform.parent.localScale.y,transform.parent.localScale.z);
        if(FaceCondition > 0 ){
            transform.parent.localScale = DefaultScale;
        }
        else if(FaceCondition < 0) {
            transform.parent.localScale = new Vector3(ScaleX*-1,transform.parent.localScale.y,transform.parent.localScale.z);
        }
    }

    protected virtual void Climbing()
    {
        if (this.playerCtl.ClimbCondition)
        {
            float Vertical = Input.GetAxis("Vertical");
            playerCtl.Rigi.velocity = new Vector2(playerCtl.Rigi.velocity.x,Vertical * Speed);
            playerCtl.SetAnimation();
        } 
    }
    protected virtual Vector3 Clinging()
    {
        if(this.ClingRaycast()){
            if (InputManager.Instance.RightMouse)
            {
                return transform.parent.position = this.GetClingPOs();
            }
        }
        return transform.parent.position;
    }

    protected virtual bool ClingRaycast()
    {
        layerMask = LayerMask.GetMask("Ground");
        Vector3 origin = transform.parent.position + Vector3.up * 0.5f;
        Vector2 RayAway = new Vector2(1,0);
        if (Physics2D.Raycast(origin, transform.TransformDirection(RayAway),0.1f,layerMask))
        {
            Debug.DrawRay(transform.parent.position, RayAway, Color.blue); 
            return true;
        }
        
        Debug.DrawRay(transform.parent.position, RayAway * 1000, Color.white);
        return false;
    }

    protected virtual Vector3 GetClingPOs()
    {
        return this.ClingPos = transform.parent.position;
    }


}


    // protected virtual void RayvsRaycast()
    // {
    //     Debug.Log("333");
    //     //Ray2D Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //     if (Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition), 1000f))
    //     {
    //         Debug.Log("to hit");
    //     }

    // }