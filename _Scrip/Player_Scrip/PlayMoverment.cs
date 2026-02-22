using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayMoverment : ObjOn1
{
    [SerializeField] protected PlayerCtl playerCtl;
    [SerializeField] protected float Speed = 5f;
    [SerializeField]public float JumpPower = 5f;


    [SerializeField]protected LayerMask GroundLayer;
    
    [SerializeField]protected bool isGround;

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
        this.SetAnimation();
    }

    protected virtual void Moving()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        this.CheckFace(Horizontal);    
        playerCtl.Rigi.velocity = new Vector2(Horizontal * Speed,playerCtl.Rigi.velocity.y);
    }

    protected virtual void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && this.isGround)
        { 
            Vector2 JumpVt = new Vector2(playerCtl.Rigi.velocity.x,this.JumpPower);
            playerCtl.Rigi.AddForce(JumpVt,ForceMode2D.Impulse);
        }

        this.isGround = Physics2D.OverlapCircle(playerCtl.GroundCheck.position,0.2f,this.GroundLayer);
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

    protected virtual void SetAnimation()
    {
        bool isJumping = !this.isGround;
        bool isRuning = Mathf.Abs(playerCtl.Rigi.velocity.x) > 0.01f;
        playerCtl.Animator.SetBool("_Run",isRuning);
        playerCtl.Animator.SetBool("_Jump",isJumping);
    }
}
