using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAniCtl : ObjOn1
{
    [SerializeField] protected PlayerCtl playerCtl;
    [SerializeField] protected Animator Ani;
    public Animator Animator => Ani;

    protected override void Loadcomponents()
    {
        base.Loadcomponents();
        this.LoadAnimator();
        this.LoadPlayerCtl();
    }

     protected virtual void LoadPlayerCtl()
    {
        if(this.playerCtl != null) return;
        this.playerCtl = transform.GetComponent<PlayerCtl>();
    }

    protected void LoadAnimator()
    {
        if(this.Ani != null) return;
        this.Ani = transform.GetComponent<Animator>();
    }

    public virtual void SetAnimation()
    {
        //playerCtl.Rigi.velocity.x
        bool isRuning = Mathf.Abs(InputManager.Instance.Horizontal) > 0.01f;
        this.Ani.SetBool("_Run",isRuning);

        bool isJumping = !playerCtl.IsGround;
        this.Ani.SetBool("_Jump",isJumping);

        float isClimb = Mathf.Abs(playerCtl.Rigi.gravityScale);
        if(isClimb == 0) playerCtl.SetIsGround();
        this.Ani.SetFloat("_Climb",isClimb);

        bool isAttack = InputManager.Instance.LeftMouse;
        this.Ani.SetBool("_Attack",isAttack);
    }
}
